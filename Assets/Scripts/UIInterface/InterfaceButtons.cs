using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceButtons : MonoBehaviour
{
    
    
    [Header("Windows")]
    [SerializeField] private GameObject soundSettingsWindow;
    [SerializeField] private GameObject exitGameWindow;
    [SerializeField] private GameObject shopWindow;
    
    //interface buttons
    //exit
    public void ExitGameWindow()
    {
        exitGameWindow.SetActive(true);    
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    //sound
    public void OpenSoundSettingsWindow()
    {
        soundSettingsWindow.SetActive(true);
    }
    public void CloseSoundSettingsWindow()
    {
        soundSettingsWindow.SetActive(false);
    }
    //shop
    public void OpenShop()
    {
        shopWindow.SetActive(true);
    }

   
    



    
    


}
