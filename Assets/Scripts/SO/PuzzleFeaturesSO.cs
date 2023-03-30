using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PuzzleFeature")]
public class PuzzleFeaturesSO : ScriptableObject
{
    [SerializeField] private int gems = 0;
    [SerializeField] private int puzzlesSolved = 0;
    [SerializeField] private string title;
    [SerializeField] private int rankTransitionRewards = 0;

    private PlayerRank playerRank;
    public enum PlayerRank { SMART = 9, GENIUS = 29, DAVINCI = 49, EINSTEIN = 69, STARK = 5000}
    
    //gems
    public int GetGems()
    {
        return gems;
    }
    public void PayGems(int paygems,PuzzleFeaturesSO puzzleFeaturesSO)
    {
        gems -= paygems;
        SaveSystem.SaveGemsAndPuzzlesSolved(puzzleFeaturesSO);
    }
    public void AddGems(int addgems,PuzzleFeaturesSO puzzleFeaturesSO)
    {
        gems += addgems;
        SaveSystem.SaveGemsAndPuzzlesSolved(puzzleFeaturesSO);
    }

    //title
    public void SetTitle()
    {
        if(puzzlesSolved < 10)
        {
            title = "SMART";
            playerRank = PlayerRank.SMART;
        }
        else if(puzzlesSolved < 30)
        {
            title = "GENIUS";
            playerRank = PlayerRank.GENIUS;
        }
        else if(puzzlesSolved < 50)
        {
            title = "DAVINCI";
            playerRank = PlayerRank.DAVINCI;
        }
        else if (puzzlesSolved < 70)
        {
            title = "EINSTEIN";
            playerRank = PlayerRank.EINSTEIN;
        }
        else
        {
            title = "STARK";
            playerRank = PlayerRank.STARK;
        }

    }
    public string GetTitle()
    {
        return title;
    }
    //puzzle solved
    public void PuzzleSolved(PuzzleFeaturesSO puzzleFeaturesSO)
    {
        puzzlesSolved++;
        SaveSystem.SaveGemsAndPuzzlesSolved(puzzleFeaturesSO);
    }
    public int GetPuzzlesSolved()
    {
        return puzzlesSolved;
    }

    public int GetPlayerRank()
    {
        return (int)playerRank;
    }
    //load
    public void LoadSavedGemsAndSolvedPuzzles(int savedGems, int savedPuzzlesSolved, int savedRankTransitions)
    {
        gems = savedGems;
        puzzlesSolved = savedPuzzlesSolved;
        rankTransitionRewards = savedRankTransitions;
    }
    //reward
    public int GetRankTransitionRewards()
    {
        return rankTransitionRewards; 
    }
    public void AddTransition(PuzzleFeaturesSO puzzleFeaturesSO)
    {
        rankTransitionRewards++;
        SaveSystem.SaveGemsAndPuzzlesSolved(puzzleFeaturesSO);
    }
}
