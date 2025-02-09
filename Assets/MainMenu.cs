using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    // Function to switch scenes
    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Function to quit the game
    public void QuitApp()
    {
        Application.Quit();
        Debug.Log("Application has successfully quit.");
    }
}
