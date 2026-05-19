using UnityEngine;

public class CoinItem : MonoBehaviour
{
    [SerializeField] private AudioClip collectSound;

    private bool collected = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (collected) return;

        if (other.CompareTag("Player"))
        {
            collected = true;

            CoinUI.instance.AddCoin();
            
            AudioSource.PlayClipAtPoint(
                collectSound,
                transform.position,
                4f
            );

            Destroy(gameObject);
        }
    }
}
