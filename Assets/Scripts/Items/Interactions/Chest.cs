using Assets.Scripts.Interactions;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    [SerializeField] private NotificationUI notificationUI;

    [SerializeField] private Sprite openedChest;

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

        sp.sprite = openedChest;

        notificationUI.ShowNotification("You found a SWORD ('Left Click') and a KEY!");

        PlayerController player = FindAnyObjectByType<PlayerController>();
        player.UnlockAttack();
        Door door = FindAnyObjectByType<Door>();
        door.UnlockKey();

    }
    public string GetInteractionPrompt()
    {
        return "Press 'E' to open the CHESS";
    }

    public bool CanInteract()
    {
        return !opened;
    }
}
