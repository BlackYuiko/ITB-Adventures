using Assets.Scripts.Interactions;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float velocity = 5f;
    [SerializeField] private float jumpForce = 5f;

    [Header("Floor Detection")]
    [SerializeField] private Transform groundChecker;
    [SerializeField] private float groundCheckerRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    [Header("Attack")]
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange = 0.5f;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private int attackDamage = 25;
    [SerializeField] private float attackCooldown = 0.5f;

    private Rigidbody2D rb;
    private Animator anim;
    private float horizontalMovement;
    private bool isGrounded;
    private bool canAttack = false;
    private float attackTimer;

    void Start() //Start para inicializar las referencias a los componentes del jugador.
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update() // Update para manejar la entrada del jugador y las animaciones.
    {
        CheckGround();

        horizontalMovement = Input.GetAxisRaw("Horizontal");

        attackTimer -= Time.deltaTime;

        anim.SetBool("isGrounded", isGrounded);

        if (Input.GetKeyDown("space") && isGrounded) 
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }

        Vector3 scale = transform.localScale; //Obtiene la escala actual del jugador.

        if (horizontalMovement > 0)
        {
            scale.x = Mathf.Abs(scale.x); //Mathf.Abs devuelve el valor absoluto de la escala.
            anim.SetBool("isRunning", true);
        }
        else if (horizontalMovement < 0)
        {
            scale.x = -Mathf.Abs(scale.x);
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
        transform.localScale = scale; //Aplica la escala al jugador para que mire en la dirección correcta.

        if (Input.GetKeyDown(KeyCode.Mouse0) && canAttack && attackTimer <= 0)
        {
            anim.SetTrigger("Attack");

            attackTimer = attackCooldown;
        }
    }


    private void FixedUpdate() //Usar FixedUpdate para aplicar la física al jugador.
    {
        rb.linearVelocity = new Vector2(horizontalMovement * velocity, rb.linearVelocity.y);
      

    }
    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundChecker.position, groundCheckerRadius, groundLayer);
        //Esta función utiliza Physics2D.OverlapCircle para verificar si el jugador está tocando el suelo.
        //La diferencia con un collision normal es que esta función no requiere que el jugador tenga un collider
        //específico para detectar el suelo, sino que simplemente verifica si hay algún collider en la capa de
        //suelo dentro del radio especificado alrededor del groundChecker.
    }

    public void PerformAttack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemyHit in hitEnemies)
        {
            enemyHit.GetComponent<EnemyController>()?.RecibirDaño(attackDamage);
        }
    }

    public void IncreaseJump(float amount)
    {
        jumpForce += amount;
    }

    public void UnlockAttack()
    {
        canAttack = true;
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void HurtAnimation()
    {
        anim.SetTrigger("Hurt");
    }

    public void Death()
    {
        StartCoroutine(DeathCoroutine());
    }

    private IEnumerator DeathCoroutine() //Usamos una corrutina para esperar a que termine la animación de muerte antes de cargar la escena de Game Over.
    {
        anim.SetTrigger("Die");
        rb.linearVelocity = Vector2.zero;
        enabled = false; // Desactiva el script para que el jugador no pueda moverse ni atacar durante la animación de muerte.

        yield return new WaitForSeconds(1f);

        GameEvents.OnPlayerDeath?.Invoke(); // Invocamos el evento para que otros sistemas puedan reaccionar a la muerte del jugador.

        GameManager.Instance.GameOver();
    }
}