using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartOrContinue : MonoBehaviour
{
    public void OnRestart()
    {
        // Reset any necessary variables or states here
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnContinue()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex <= SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogError("No more scenes available.");
        }
    }
}