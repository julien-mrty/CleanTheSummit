using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //public GameObject menu;
    void Start()
    {
        SceneManager.LoadScene("GameOne", LoadSceneMode.Additive);
    }

    // Function to switch scenes
    public void GoToScene(string sceneName)
    {
        //menu.SetActive(false);
        SceneManager.LoadScene(sceneName);
    }

    // Function to quit the game
    public void QuitApp()
    {
        Application.Quit();
        Debug.Log("Application has successfully quit.");
    }
}
