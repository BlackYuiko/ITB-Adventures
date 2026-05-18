using Assets.Scripts.Interactions;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private Sprite openedDoor;

    private SpriteRenderer sp;
    private BoxCollider2D bc;

    private bool opened = false;
    private bool hasKey = false;
    

    public void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
    }

    public void Interact()
    {
        if (opened) return;
        if (!hasKey) return;
        opened = true;

        sp.sprite = openedDoor; // Cambia el sprite
        bc.enabled = false; // Desactiva el collider para que el jugador pueda pasar

        // reproducir sonido
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
