using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseGameType : MonoBehaviour
{
     
    [SerializeField] private PuzzlePassSO puzzlepass;
    private PuzzleDataSO puzzleDataSO;
    private string gameType;


    public PuzzleDataSO GetGamePuzzle()
    {
        puzzleDataSO = puzzlepass.GetPuzzleData();
        gameType = puzzlepass.GetGameType();
        return puzzleDataSO;
        
    }

    public void SetGameType()
    {
        puzzleDataSO.SetTypeGame(gameType);
    }
    public string GetGameType()
    {
        return gameType;
    }

  
}
