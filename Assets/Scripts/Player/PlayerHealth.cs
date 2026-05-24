using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private bool isInvulnerable = false;
    private PlayerController player;

    private void Start()
    {
        player = GetComponent<PlayerController>();

        GameEvents.OnLivesChanged?.Invoke(GameManager.Instance.Lives);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage();
        }
    }

    public void TakeDamage(int damage = 1) // Cuando el jugador recibe daño se llama a TakeDamage() desde PlayerHealth.
                                           // PlayerHealth no modifica directamente la UI ni las vidas visuales,
                                           // sino que delega la lógica global al GameManager mediante
                                           // GameManager.Instance.RemoveLife().
                                           //
                                           // El GameManager reduce el número de vidas y lanza el evento
                                           // GameEvents.OnLivesChanged pasando el nuevo valor de vidas.
                                           //
                                           // El UIManager está suscrito a ese evento mediante OnEnable(),
                                           // por lo que automáticamente recibe el nuevo valor y ejecuta
                                           // UpdateLives().
                                           //
                                           // UpdateLives() recorre el array de corazones y activa o desactiva
                                           // las imágenes dependiendo de cuántas vidas quedan.
                                           //
                                           // De esta manera el Player no conoce la UI directamente,
                                           // la comunicación queda desacoplada mediante eventos y el
                                           // GameManager actúa como servicio central del juego.
    {
        PlayerController player = FindAnyObjectByType<PlayerController>();

        if (isInvulnerable) return;

        if (GameManager.Instance.Lives <= 0)
        {
            player.Death();
        }
        else
        {
            player.HurtAnimation();
            GameManager.Instance.RemoveLife(); 
            StartCoroutine(Invulnerability());
        }
    }
    public IEnumerator Invulnerability()
    {
        isInvulnerable = true;

        yield return new WaitForSeconds(0.5f);

        isInvulnerable = false;
    }
}
