using UnityEngine;

public class DualLevelManager : MonoBehaviour
{

    [SerializeField] private NotificationUI notificationUI;

    [SerializeField] private AudioClip solvedSound;

    private int activatedLevers = 0;

    private bool solved = false;

    private int requiredLevers = 2;
    public void ActivateLever()
    {
        if (solved) return;

        activatedLevers++;

        if (activatedLevers >= requiredLevers)
        {
            solved = true;

            GameObject redBoxFinal = GameObject.FindGameObjectWithTag("RedBoxFinal");

            Destroy(redBoxFinal);
           
            notificationUI.ShowNotification("Oh what was that noise?");
           
            AudioSource.PlayClipAtPoint(
                solvedSound,
                transform.position,
                4f
            );
        }
    }
}
