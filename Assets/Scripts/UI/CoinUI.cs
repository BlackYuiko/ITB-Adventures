using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;

    private void OnEnable()
    {
        GameEvents.OnCoinsChanged += UpdateUI;
    }
    private void OnDisable()
    {
        GameEvents.OnCoinsChanged -= UpdateUI;
    }

    private void Start()
    {
        UpdateUI(GameManager.Instance.Coins);
    }

    void UpdateUI(int coins)
    {
        coinText.text = $"{coins}/4";

    }
}
