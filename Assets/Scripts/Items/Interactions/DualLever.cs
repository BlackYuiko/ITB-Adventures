using Assets.Scripts.Interactions;
using UnityEngine;
using UnityEngine.U2D.IK;

public class DualLever : MonoBehaviour, IInteractable
{
    [SerializeField] private Sprite openedLever;

    [SerializeField] private DualLevelManager dualLevel;

    private SpriteRenderer sp;

    private bool opened = false;

    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    public void Interact()
    {
        if (opened) return;

        opened = true;

        sp.sprite = openedLever;

        dualLevel.ActivateLever();
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
