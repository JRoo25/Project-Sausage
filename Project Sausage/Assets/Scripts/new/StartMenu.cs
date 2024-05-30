using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void LoadLevel1() {
        SceneManager.LoadScene("CharacterSelection");
    }

    public void LoadTutorial() {
        SceneManager.LoadScene("Tutorial");
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void LeaveGame() {
        SceneManager.LoadScene("Start Scene");
    }
}