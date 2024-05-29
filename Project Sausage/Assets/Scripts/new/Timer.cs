using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Text timerText;
    public Text totalTime;
    public static bool isGameComplete = false;
    public GameObject levelCompleteUI;
    static float timer;

    private AudioManager audioManager;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        int minutes = Mathf.FloorToInt(timer/60);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);

        string time = string.Format("{0} minutes, {1} seconds", minutes, seconds);

        timerText.text = time;
    }

    void ShowLevelComplete() {

        levelCompleteUI.SetActive(true);
        isGameComplete = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        timerText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) {

        totalTime.text = "Total Time: " + timerText.text;
        ShowLevelComplete();
    }

    public static void ResetTimer()
    {
        timer = 0;
    }
}
