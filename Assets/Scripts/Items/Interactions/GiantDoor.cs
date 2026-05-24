using Assets.Scripts.Interactions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GiantDoor : MonoBehaviour, IInteractable
{
    [SerializeField] private Sprite openedDoor;

    private SpriteRenderer sp;

    public Transform destino;

    private bool leverUsed = false;
    private bool canEnter = false;

    public void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    public void Interact()
    {
        if (!leverUsed) return;

        canEnter = true;

        PlayerController player  = FindAnyObjectByType<PlayerController>();
        player.transform.position = destino.position;
    }

    public string GetInteractionPrompt()
    {
        if (!leverUsed) return "This door doesn't have a dook";

        return "Press 'E' to enter";
    }

    public bool CanInteract()
    {
        return !canEnter;
    }

    public void OpenDoor()
    {
        leverUsed = true;
        sp.sprite = openedDoor;
    }
}
