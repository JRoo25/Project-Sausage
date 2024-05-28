using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public GameObject FirstUI;
    public GameObject SecondUI;
    public GameObject ThirdUI;
    public GameObject FourthUI;

    void ShowFirstUI()
    {
        FirstUI.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }

    void ShowSecondUI()
    {
        SecondUI.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }

    void ShowThirdUI()
    {
        ThirdUI.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }

    void ShowFourthUI()
    {
        FourthUI.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void CloseFirstUI()
    {
        FirstUI.SetActive(false);
    }

    public void CloseSecondUI()
    {
        SecondUI.SetActive(false);
    }

    public void CloseThirdUI()
    {
        ThirdUI.SetActive(false);
    }

    public void CloseFourthUI()
    {
        FourthUI.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("First Trigger"))
        {
            ShowFirstUI();
            CloseSecondUI();
            CloseThirdUI();
            CloseFourthUI();
        }
        else if (other.gameObject.CompareTag("Second Trigger"))
        {
            ShowSecondUI();
            CloseFirstUI();
            CloseThirdUI();
            CloseFourthUI();
        }
        else if (other.gameObject.CompareTag("Third Trigger"))
        {
            ShowThirdUI();
            CloseFirstUI();
            CloseSecondUI();
            CloseFourthUI();
        }
        else if (other.gameObject.CompareTag("Finish"))
        {
            ShowFourthUI();
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            CloseFirstUI();
            CloseSecondUI();
            CloseThirdUI();

            PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
            if (playerMovement!= null)
            {
                playerMovement.DisableMovement();
            }
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Start Scene");
    }
}