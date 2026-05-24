using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] private Image[] hearts;

    private void OnEnable()
    {
        GameEvents.OnLivesChanged += UpdateLives;
    }

    private void OnDisable()
    {
        GameEvents.OnLivesChanged -= UpdateLives;
    }

    private void Start()
    {
        UpdateLives(GameManager.Instance.Lives);
    }

    public void UpdateLives(int lives)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = i < lives;
        }
    }
}
