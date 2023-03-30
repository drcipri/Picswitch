using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartPuzzle : MonoBehaviour
{
    [Header("Data Objects")]
    [SerializeField] private PuzzleFeaturesSO puzzleFeaturesSO;
    [SerializeField] private UISolvedList solvedList;
    [SerializeField] private PuzzlePassSO puzzlepass;
    [Header("Components")]
    [SerializeField] private Button selectTimeButton;
    [SerializeField] private Button selectMovesButton;
    [SerializeField] private Button startPuzzleButton;
    [SerializeField] private Text infoText;
    [SerializeField] private Image showImage;

    
    private PuzzleDataSO currentPuzzle;

    

    private void OnEnable()
    {
        
        SetButtons();
    }

    private void SetButtons()
    {
        startPuzzleButton.interactable = false;
        SetImageShow();
        if(currentPuzzle.GetPuzzleRank() <= puzzleFeaturesSO.GetPlayerRank())
        {
            selectMovesButton.interactable = true;
            selectTimeButton.interactable = true;
            infoText.text = "Select the challenge then press Start Puzzle button!";
        }
        else
        {
            infoText.text = "Rank to low!";
            selectTimeButton.interactable = false;
            selectMovesButton.interactable = false;
        }
    }

    private void SetImageShow()
    {
        Color blackTransparent = new Color(25/255f, 25/255f, 25/255f);
        
        if(solvedList.GetSolvedList().Contains(currentPuzzle) == true)
        {
            showImage.color = Color.white;
            
        }
        else
        {
            
            showImage.color = blackTransparent;
        }
    }

    public void SelectTime()
    {
        selectTimeButton.interactable = false;
        selectMovesButton.interactable = true;
        startPuzzleButton.interactable = true;
        puzzlepass.SetGameType("Time");
    }
    public void SelectMoves()
    {
        selectTimeButton.interactable = true;
        selectMovesButton.interactable = false;
        startPuzzleButton.interactable = true;
        puzzlepass.SetGameType("Moves");
    }

    public void StartPuzzleClick()
    {
        puzzlepass.SetPuzzleData(currentPuzzle);
        SceneManager.LoadScene("GameScene");
    }
   


   

    public void SetPuzzle(PuzzleDataSO puzzleData)
    {
        currentPuzzle = puzzleData;
    }

    
}
