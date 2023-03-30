using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpWithGemsButton : MonoBehaviour
{
    [SerializeField] private PuzzleFeaturesSO puzzleFeaturesSO;
    [SerializeField] private Text buttonText;
    private Button thisButton;

    private void Start()
    {
        
        SetButton();
        
    }

    public void SetButton()
    {
        thisButton = GetComponent<Button>();
        buttonText.text = puzzleFeaturesSO.GetGems().ToString();
        if (puzzleFeaturesSO.GetGems() >= 10)
        {
            thisButton.interactable = true; 
        }
        else
        {
            thisButton.interactable = false;
        }
    }

  

}
