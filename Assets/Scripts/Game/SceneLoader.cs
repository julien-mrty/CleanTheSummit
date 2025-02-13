using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public float delayBeforeNextScene = 5.0f;

    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameOne");
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("No more scenes to load!");
        }
    }

    public void AutoLoadNextScene()
    {
        Invoke("LoadNextScene", delayBeforeNextScene);
    }

    void Start()
    {
        AutoLoadNextScene();
    }
}
