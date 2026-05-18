using Assets.Scripts.Interactions;
using UnityEngine;

public class GiantDoor : MonoBehaviour, IInteractable
{
    [SerializeField] private Sprite openedDoor;

    private SpriteRenderer sp;

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
