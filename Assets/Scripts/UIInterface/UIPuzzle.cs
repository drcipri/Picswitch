using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class UIPuzzle : MonoBehaviour
{
    [Header("Puzzle Data")]
    [SerializeField] private PuzzleDataSO puzzleDataSO;
    [SerializeField] private PuzzleFeaturesSO puzzleFeaturesSO;
    [SerializeField] private UISolvedList solvedList;
    [SerializeField] private UIUnsolvedList unsolvedList;
    [SerializeField] private StartPuzzle startPuzzle;
    [Header("PuzzleComponents")]
    [SerializeField] private Sprite lockedSprite;
    [SerializeField] private Sprite unlockedSprite;
    [SerializeField] private TextMeshProUGUI puzzleRankText;
    [Header("StartPuzzle")]
    [SerializeField] private GameObject startPuzzleCanvas;
    [SerializeField] private Text puzzleTimeText;
    [SerializeField] private Text puzzleMovesText;
    [SerializeField] private TextMeshProUGUI puzzleRankTextShow;
    [SerializeField] private Image puzzleImageShow;

    
    private Sprite solvedSprite;
    private Image puzzleImage;

    private void Awake()
    {

        solvedSprite = puzzleDataSO.GetOriginalPicture();
        puzzleImage = gameObject.transform.GetChild(0).GetComponent<Image>();
    }
    private void Start()
    {
        SetPuzzleSprite();
    }

    private void SetPuzzleSprite()
    {
        if (solvedList.GetSolvedList().Contains(puzzleDataSO))
        {
            puzzleImage.sprite = solvedSprite;
            puzzleRankText.gameObject.transform.parent.gameObject.SetActive(false);
            return;
        }
        else if(puzzleDataSO.GetPuzzleRank() <= puzzleFeaturesSO.GetPlayerRank())
        {
            puzzleImage.sprite = unlockedSprite;
            
        }
        else if(puzzleDataSO.GetPuzzleRank() > puzzleFeaturesSO.GetPlayerRank())
        {
            puzzleImage.sprite = lockedSprite;
        }


        switch (puzzleDataSO.GetPuzzleRankAsPuzzleRank())
        {
            case PuzzleDataSO.PuzzleRank.SMART:
                puzzleRankText.text = "SMART";
                puzzleRankText.color = Color.yellow;
                break;
            case PuzzleDataSO.PuzzleRank.GENIUS:
                puzzleRankText.text = "GENIUS";
                puzzleRankText.color = Color.green;
                break;
            case PuzzleDataSO.PuzzleRank.DAVINCI:
                puzzleRankText.text = "DAVINCI";
                puzzleRankText.color = Color.red;
                break;
            case PuzzleDataSO.PuzzleRank.EINSTEIN:
                puzzleRankText.text = "EINSTEIN";
                puzzleRankText.color = Color.cyan;
                break;
            case PuzzleDataSO.PuzzleRank.STARK:
                puzzleRankText.text = "STARK";
                puzzleRankText.color = Color.magenta;
                break;

        }

        
    }


    public void OnClick()
    {
        startPuzzle.SetPuzzle(puzzleDataSO);
        SetRankPuzzleText();
        
        puzzleMovesText.text = puzzleDataSO.GetMoves().ToString();

        TimeSpan time = TimeSpan.FromSeconds(puzzleDataSO.GetTimer());
        puzzleTimeText.text = time.ToString().Substring(3, 5);
        
        puzzleImageShow.sprite = puzzleDataSO.GetOriginalPicture();
        startPuzzleCanvas.SetActive(true);
    }

    public void SetRankPuzzleText()
    {
        switch (puzzleDataSO.GetPuzzleRankAsPuzzleRank())
        {
            case PuzzleDataSO.PuzzleRank.SMART:
                puzzleRankTextShow.text = "SMART";
                puzzleRankTextShow.color = Color.yellow;
                break;
            case PuzzleDataSO.PuzzleRank.GENIUS:
                puzzleRankTextShow.text = "GENIUS";
                puzzleRankTextShow.color = Color.green;
                break;
            case PuzzleDataSO.PuzzleRank.DAVINCI:
                puzzleRankTextShow.text = "DAVINCI";
                puzzleRankTextShow.color = Color.red;
                break;
            case PuzzleDataSO.PuzzleRank.EINSTEIN:
                puzzleRankTextShow.text = "EINSTEIN";
                puzzleRankTextShow.color = Color.cyan;
                break;
            case PuzzleDataSO.PuzzleRank.STARK:
                puzzleRankTextShow.text = "STARK";
                puzzleRankTextShow.color = Color.magenta;
                break;
        }
    }

    
    public void SetPuzzleData(PuzzleDataSO puzzleData)
    {
        puzzleDataSO = puzzleData;
    }


}
