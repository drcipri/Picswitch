using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameLoader : MonoBehaviour
{
    [SerializeField] private PuzzleFeaturesSO puzzleFeaturesSO;
    [SerializeField] private PuzzlesSolvedDataSO solvedDataSO;
    [SerializeField] private UISolvedList solvedList;
    [SerializeField] private UIUnsolvedList unsolvedList;
    [SerializeField] private List<PuzzleDataSO> puzzlesList;

    private Dictionary<string, bool> puzzlesSolved;
    

    private void Awake()
    {
        LoadGemsAndPuzzlesSolved();
        LoadPuzzlesDataDictionary();
        puzzlesSolved = solvedDataSO.GetPuzzlesSolvedDataDictionary();
        SetPuzzlesSolved();
        SetPuzzlesUnsolved();
        
    }

    private void LoadGemsAndPuzzlesSolved()
    {
        string path = Application.persistentDataPath + "/Gems.cotuna";
        if (File.Exists(path))
        {
            GameData gameData = SaveSystem.LoadGemsAndPuzzlesSolved();
            puzzleFeaturesSO.LoadSavedGemsAndSolvedPuzzles(gameData.ReturnSavedGems(), 
                                                           gameData.ReturnPuzzlesSolved(),gameData.ReturnRankTransitionRewards());
        }
    }

    private void LoadPuzzlesDataDictionary()
    {
        string path = Application.persistentDataPath + "/PuzzlesSolved.cotuna";
        if (File.Exists(path))
        {
            GameData gameData = SaveSystem.LoadPuzzlesSolvedData();
            solvedDataSO.LoadPuzzlesSolvedData(gameData.ReturnPuzzlesSolvedData());
        }
    }

    private void SetPuzzlesSolved()
    {
        if(puzzlesSolved.Count != 0 && puzzlesSolved != null)
        {
            foreach(var keyValuePairs in puzzlesSolved)
            {
                foreach(var member in puzzlesList)
                {
                    if(keyValuePairs.Key == member.name)
                    {
                        member.SetSolved(keyValuePairs.Value);
                        solvedList.AddSolvedPuzzles(member);
                        break;
                    }
                }
            }

        }
    }
    public void SetPuzzlesUnsolved()
    {
        foreach(var member in puzzlesList)
        {
            if(member.GetPuzzlesSolvedValue() == false)
            {
                unsolvedList.AddUnolvedPuzzles(member);
            }
        }
    }


}
