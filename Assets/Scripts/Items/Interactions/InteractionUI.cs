using TMPro;
using UnityEngine;

public class InteractionUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI interactionText;

    public void Show(string message)
    {
        interactionText.text = message;
        interactionText.gameObject.SetActive(true);
    }

    public void Hide()
    {
        interactionText.gameObject.SetActive(false);
    }
}
