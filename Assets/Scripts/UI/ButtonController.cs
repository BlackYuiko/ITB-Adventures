using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void onClickFirstFloorScene() 
    {
        GameManager.Instance.StartGame();
    }
    public void onClickIntroScene()
    {
        GameManager.Instance.IntroScene();
    }

    public void onClickQuit()
    {
        GameManager.Instance.ExitGame();
    }
}
