using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    public static CoinUI instance;

    public TextMeshProUGUI coinText;

    private int coins = 0;

    private void Awake()
    {
        instance = this;
        UpdateUI();
    }

    public void AddCoin()
    {
        coins++;
        UpdateUI();
    }

    void UpdateUI()
    {
        coinText.text = $"{coins}/4";

    }
}
