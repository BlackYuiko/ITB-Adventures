using Assets.Scripts.Interactions;
using UnityEngine;

public class Lever : MonoBehaviour, IInteractable
{
    [SerializeField] private NotificationUI notificationUI;

    [SerializeField] private Sprite openedLever;
    [SerializeField] private AudioClip openDoorSound;

    private SpriteRenderer sp;

    private bool opened = false;

    public void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    public void Interact()
    {
        if (opened) return;

        opened = true;

        sp.sprite = openedLever; // Cambia el sprite

        GiantDoor door = FindAnyObjectByType<GiantDoor>(); 
        door.OpenDoor();

        AudioSource.PlayClipAtPoint(
                openDoorSound,
                transform.position
            );

        notificationUI.ShowNotification("Oh what was that noise?");
    }

    public string GetInteractionPrompt()
    {
        return "Press E to use the lever";
    }

    public bool CanInteract()
    {
        return !opened;
    }
}
