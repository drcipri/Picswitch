using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Puzzle", fileName = "New Puzzle")]
public class PuzzleDataSO : ScriptableObject
{
    
    [Header("UI Components Settings")]
    [SerializeField] public List<Sprite> puzzleSprites;
    [SerializeField] private Sprite originalPicture;
    [SerializeField] private MatriceType matriceType;
    [SerializeField] private PuzzleRank puzzleRank;
    public enum MatriceType { SuperEasy = 3, Easy = 4, Medium = 5, Hard = 6, Expert = 7 }
    public enum PuzzleRank { SMART = 9, GENIUS = 29, DAVINCI = 49, EINSTEIN = 69, STARK = 5000 }
    private bool timeGame = false;
    private bool moveGame = false;

    [Header("Parameters")]
    [SerializeField] private float timer;
    [SerializeField] private int moves;
     
    [Header("Puzzle Data Editor ")]
    [SerializeField] public  bool spritesReordered = false;

    [Header("IsPuzzleSolved")]
    [SerializeField]private bool solved = false;

    




    //parameters
    public float GetTimer()
    {
        return timer;
    }
   
    public int GetMoves()
    {
        return moves;
    }
    
    public void SetTypeGame(string type)
    {
        if (type == "Time")
        {
            timeGame = true;
        }
        else if (type == "Moves")
        {
            moveGame = true;
        }
    }
    public void DisableTypeGame()
    {
        timeGame = false;
        moveGame = false;
    }
    public bool GetMoveGame()
    {
        return moveGame;
    }
    public bool GetTimeGame()
    {
        return timeGame;    
    }
    

    //Main
    public Sprite GetPuzzleSprites(int index)
    {
        return puzzleSprites[index];
    }
    public MatriceType GetMatriceType()
    {
        return matriceType;
    }
    public Sprite GetOriginalPicture()
    {
        return originalPicture;
    }
    public void SetMatriceType(int matriceType)
    {
        this.matriceType = (MatriceType)matriceType;
    }

    //puzzleRank
    public int GetPuzzleRank()
    {
        return (int)puzzleRank;
    }
    public PuzzleRank GetPuzzleRankAsPuzzleRank()
    {
        return puzzleRank;
    }
    //puzzleSolved
    public void PuzzleSolved()
    {
        solved = true;
    }
    public bool GetPuzzlesSolvedValue()
    {
        return solved;
    }
    public void SetSolved(bool isSolved)
    {
        solved = isSolved;
    }


    
}
