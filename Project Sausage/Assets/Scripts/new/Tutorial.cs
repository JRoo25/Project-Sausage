using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject FirstUI;
    public GameObject SecondUI;
    public GameObject ThirdUI;
    public GameObject FourthUI;
    private bool uiShown = false;

    void ShowFirstUI()
    {
        if (!uiShown)
        {
            FirstUI.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            uiShown = true;
        }
    }

    void ShowSecondUI()
    {
        if (!uiShown)
        {
            SecondUI.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            uiShown = true;
        }
    }

    void ShowThirdUI()
    {
        if (!uiShown)
        {
            ThirdUI.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            uiShown = true;
        }
    }

    void ShowFourthUI()
    {
        if (!uiShown)
        {
            FourthUI.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            uiShown = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("First Trigger"))
        {
            ShowFirstUI();
        }

        else if (other.gameObject.CompareTag("Second Trigger"))
        {
            ShowSecondUI();
        }

        else if (other.gameObject.CompareTag("Third Trigger"))
        {
            ShowThirdUI();
        }

        else if (other.gameObject.CompareTag("Finish"))
        {
            ShowFourthUI();
        }
    }

    public void CloseFirstUI()
    {
        FirstUI.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        uiShown = false;
    }

    public void CloseSecondUI()
    {
        SecondUI.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        uiShown = false;
    }

    public void CloseThirdUI()
    {
        ThirdUI.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        uiShown = false;
    }

    public void CloseFourthUI()
    {
        FourthUI.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        uiShown = false;
    }
}