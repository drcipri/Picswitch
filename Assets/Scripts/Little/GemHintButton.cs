using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemHintButton : MonoBehaviour
{
    [SerializeField] private PuzzleFeaturesSO puzzleFeature;
    [SerializeField] private Text gemText;
    private Button gemHintButton;
    // Start is called before the first frame update
    void Start()
    {
        PrepareButton();
    }
    private void Update()
    {
        CheckButton();
    }

    private void PrepareButton()
    {
        gemHintButton = GetComponent<Button>();
        gemText.text = puzzleFeature.GetGems().ToString();
        if(puzzleFeature.GetGems() < 5)
        {
            gemHintButton.interactable = false;
        }
    }
    private void CheckButton()
    {
        gemText.text = puzzleFeature.GetGems().ToString();
        if(puzzleFeature.GetGems() < 5 )
        {
            gemHintButton.interactable = false;
        }
        else if(puzzleFeature.GetGems() > 5)
        {
            gemHintButton.interactable = true;
        }
        
    }
 


}
