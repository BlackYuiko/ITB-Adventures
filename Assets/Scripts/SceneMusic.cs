using UnityEngine;

public class SceneMusic : MonoBehaviour
{
    [SerializeField] private AudioClip sceneMusic;

    private void Start()
    {
        MusicManager.instance.PlayMusic(sceneMusic);
    }
}
