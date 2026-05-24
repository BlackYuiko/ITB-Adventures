using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Variable estática para almacenar la instancia única del GameManager.
                                        // Esto permite que otros scripts accedan al GameManager fácilmente a través de GameManager.Instance.

    [Header("Game State")]
    [SerializeField] private int lives = 3;
    [SerializeField] private int coins = 0;
    
    public int Lives => lives; // solo lectura desde otros scripts
    public int Coins => coins;

    private void Awake() //Asignamos el Singleton en el método Awake, que se llama antes de Start.
                         //Esto asegura que la instancia del GameManager esté disponible para otros scripts desde el principio.
                         //El Singleton es un patrón de diseño que garantiza que solo haya una instancia de una clase y proporciona un punto de acceso global a esa instancia.
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RemoveLife(int amount = 1)
    {
        lives -= amount;

        lives = Mathf.Clamp(lives, 0, 3);

        GameEvents.OnLivesChanged?.Invoke(lives); // Invocamos el evento para actualizar la UI u otros sistemas que dependan de las vidas.

        if (lives <= 0)
        {
            GameOver();
        }
    }
    public void AddCoin()
    {
        coins++;

        coins = Mathf.Clamp(coins, 0, 999);

        GameEvents.OnCoinsChanged?.Invoke(coins);
    }

    public void StartGame()
    {
        coins = 0;
        lives = 3;

        SceneManager.LoadScene("FirstFloor");
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void WinGame()
    {
        SceneManager.LoadScene("Final");
    }

    public void IntroScene()
    {
        SceneManager.LoadScene("Intro");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
