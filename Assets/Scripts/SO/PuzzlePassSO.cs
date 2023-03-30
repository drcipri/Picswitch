using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="PuzzlePassSO")]
public class PuzzlePassSO : ScriptableObject
{
    private PuzzleDataSO puzzleDataSO;
    private string gameType;

    public void SetPuzzleData(PuzzleDataSO puzzleData)
    {
        puzzleDataSO = puzzleData;
    }

    public void SetGameType(string gameT)
    {
        gameType = gameT;
    }

    public PuzzleDataSO GetPuzzleData()
    {
        return puzzleDataSO;
    }
    public string GetGameType()
    {
        return gameType;
    }


}
