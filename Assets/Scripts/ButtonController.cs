using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void onClickFirstFloorScene() 
    {
        SceneManager.LoadScene("FirstFloor");
    }

    public void onClickQuit()
    {
        Application.Quit();
    }
}
