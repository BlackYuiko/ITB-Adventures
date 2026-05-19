using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Estadísticas")]
    [SerializeField] private int maxVida = 100;
    [SerializeField] private float velocidad = 3f;
    private int vida;

    [Header("Detección y Movimiento")]
    [SerializeField] private float rangoPersecucion = 10f;
    [SerializeField] private float rangoParada = 1.5f;

    [Header("Ataque")]
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange = 0.5f;
    [SerializeField] private float cooldownAtaque = 1.5f;
    [SerializeField] private LayerMask playerLayer;

    private Transform playerTransform;
    private Rigidbody2D rb;
    private Animator anim;

    private float proximoAtaque = 0f;
    private float horizontalMovement = 0f;
    private bool atacando = false;
    private bool muerto = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        vida = maxVida;

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            playerTransform = playerObj.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (muerto || playerTransform == null) return;

        float distancia = Vector2.Distance(transform.position, playerTransform.position);

        if (distancia <= rangoPersecucion && distancia > rangoParada && !atacando)
        {
            anim.SetBool("correr", true);
            horizontalMovement = transform.position.x < playerTransform.position.x ? 1f : -1f;
            Flip(horizontalMovement);
        }
        else
        {
            anim.SetBool("correr", false);
            horizontalMovement = 0f;

            if (!atacando)
            {
                Flip(playerTransform.position.x > transform.position.x ? 1f : -1f);
            }
        }

        if (Time.time >= proximoAtaque && distancia <= rangoParada && !atacando)
        {
            anim.SetTrigger("ataque");
            proximoAtaque = Time.time + cooldownAtaque;
        }
    }

    private void FixedUpdate()
    {
        if (muerto || atacando)
        {
            rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
            return;
        }

        rb.linearVelocity = new Vector2(horizontalMovement * velocidad, rb.linearVelocity.y);
    }

    private void Flip(float direction)
    {
        Vector3 scale = transform.localScale;
        if (direction > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        else if (direction < 0)
        {
            scale.x = -Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }

    public void RecibirDaño(int daño)
    {
        if (muerto) return;

        vida -= daño;

        if (vida > 0)
        {
            anim.SetTrigger("hurt");
        }
        else
        {
            Morir();
        }
    }

    private void Morir()
    {
        muerto = true;
        anim.SetTrigger("muerte");
        rb.linearVelocity = Vector2.zero;
        GetComponent<Collider2D>().enabled = false;
    }

    public void FinalizarMuerte()
    {
        Destroy(gameObject);
    }

    public void Attack() 
    {
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);

        foreach (Collider2D playerHit in hitPlayers)
        {
            playerHit.GetComponent<PlayerHealth>()?.TakeDamage(1);
        }
    }
    public void Atacando() => atacando = true;
    public void NoAtacando() => atacando = false;

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}