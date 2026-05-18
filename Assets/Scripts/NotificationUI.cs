using System.Collections;
using TMPro;
using UnityEngine;

public class NotificationUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI notificationText;

    public void ShowNotification(string message)
    {
        StopAllCoroutines();

        StartCoroutine(ShowRoutine(message));

    }

    private IEnumerator ShowRoutine(string message)
    {
        notificationText.text = message;

        notificationText.gameObject.SetActive(true);

        yield return new WaitForSeconds(4f);

        notificationText.gameObject.SetActive(false);
    }
}
