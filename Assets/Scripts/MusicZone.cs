using UnityEngine;

public class MusicZone : MonoBehaviour
{
    [SerializeField] private AudioClip newMusic;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            MusicManager.instance.PlayMusic(newMusic);
        }
    }
}
