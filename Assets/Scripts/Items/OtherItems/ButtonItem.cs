using Assets.Scripts.Interactions;
using UnityEngine;

public class ButtonItem : MonoBehaviour, IInteractable
{
    [SerializeField] private Sprite openedButtom;
    [SerializeField] private NotificationUI notificationUI;
    [SerializeField] private AudioClip newMusic;

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

        sp.sprite = openedButtom;

        GameObject[] redBoxes = GameObject.FindGameObjectsWithTag("RedBox");

        foreach (GameObject redBox in redBoxes)
        {
            Destroy(redBox);
        }

        GameObject squareEnemies = GameObject.FindGameObjectWithTag("SquareEnemies");
        Destroy(squareEnemies);


        MusicManager.instance.PlayMusic(newMusic);

        notificationUI.ShowNotification("Oh no, what is happening?");



    }
    public string GetInteractionPrompt()
    {
        return "Press E to use the buttom";
    }

    public bool CanInteract()
    {
        return !opened;
    }
}
