using Assets.Scripts.Interactions;
using UnityEngine;

public class potion : MonoBehaviour, IInteractable
{
    [SerializeField] private NotificationUI notificationUI;

    [SerializeField] private float jumpBoost = 3f;

    private SpriteRenderer sp;

    private bool taken = false;

    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    public void Interact()
    {
        if (taken) return;

        taken = true;

        gameObject.SetActive(false);

        notificationUI.ShowNotification("You found a Jump Potion!\nJump increased!");

        PlayerController player = FindAnyObjectByType<PlayerController>();

        player.IncreaseJump(jumpBoost);

    }

    public string GetInteractionPrompt()
    {
        return "Press 'E' to drink the potion";
    }

    public bool CanInteract()
    {
        return !taken;
    }
}
