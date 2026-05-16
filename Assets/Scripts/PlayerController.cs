using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float velocity = 5f;

    private Rigidbody2D rb;
    private Animator anim;
    private float horizontalMovement;

    [SerializeField]
    private float jumpForce = 5f;

    [Header("Detección de Suelo")]
    [SerializeField] private Transform groundChecker;
    [SerializeField] private float groundCheckerRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    private bool isGrounded;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update() //Usar Update para leer el input del jugador.
    {
        CheckGround();

        horizontalMovement = Input.GetAxisRaw("Horizontal");

        anim.SetBool("isGrounded", isGrounded);

        if (Input.GetKeyDown("space") && isGrounded) 
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }

        Vector3 scale = transform.localScale; //Obtiene la escala actual del jugador.

        if (horizontalMovement > 0)
        {
            scale.x = Mathf.Abs(scale.x);
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
    }


    private void FixedUpdate() //Usar FixedUpdate para aplicar la física al jugador.
    {
        rb.linearVelocity = new Vector2(horizontalMovement * velocity, rb.linearVelocity.y);
      

    }
    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundChecker.position, groundCheckerRadius, groundLayer);
    }
}