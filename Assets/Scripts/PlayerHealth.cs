using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int lives = 3;
    [SerializeField] private UIManager uiManager;

    private bool isInvulnerable = false;

    private void Start()
    {
        uiManager.UpdateLives(lives);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage();
        }
    }

    public void TakeDamage(int damage = 1)
    {
        PlayerController player = FindAnyObjectByType<PlayerController>();

        if (isInvulnerable) return;

        lives--;
        uiManager.UpdateLives(lives);

        if (lives <= 0)
        {
            if (player != null) player.Death();
        }
        else
        {
            player.HurtAnimation();
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
