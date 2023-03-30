using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    
    private int gameGems;
    private int puzzlesSolved;
    private int rankTransitionRewards;
    private Dictionary<string, bool> solvedPuzzles;
    

    //gems and puzzlesSolved
    public GameData(PuzzleFeaturesSO puzzleFeaturesSO)
    {
        gameGems = puzzleFeaturesSO.GetGems();
        puzzlesSolved = puzzleFeaturesSO.GetPuzzlesSolved();
        rankTransitionRewards = puzzleFeaturesSO.GetRankTransitionRewards();
    }
    public int ReturnSavedGems()
    {
        return gameGems;
    }
   
    public int ReturnPuzzlesSolved()
    {
        return puzzlesSolved;   
    }
    public int ReturnRankTransitionRewards()
    {
        return rankTransitionRewards;
    }
  //puzzlesSolved
    public GameData(PuzzlesSolvedDataSO puzzlesSolvedDataSO)
    {
        solvedPuzzles = puzzlesSolvedDataSO.GetPuzzlesSolvedDataDictionary();
    }
    public Dictionary<string, bool> ReturnPuzzlesSolvedData()
    {
        return solvedPuzzles;
    }
}
