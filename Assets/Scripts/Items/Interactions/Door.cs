using Assets.Scripts.Interactions;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    private SpriteRenderer sp;
    private BoxCollider2D bc;

    private bool opened = false;
    private bool hasKey = false;
    
    public void Start()
    {
        bc = GetComponent<BoxCollider2D>();
    }

    public void Interact()
    {
        if (opened) return;
        if (!hasKey) return;
        opened = true;

        gameObject.SetActive(false);
    }

    public string GetInteractionPrompt()
    {
        if (!hasKey) return "You need a key to open the door";

        return "Press E to use the key";
    }

    public bool CanInteract()
    {
        return !opened;
    }

    public void UnlockKey()
    {
        hasKey = true;
    }
}
