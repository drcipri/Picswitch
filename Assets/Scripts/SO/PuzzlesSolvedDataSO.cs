using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PuzzlesSolvedData")]
public class PuzzlesSolvedDataSO : ScriptableObject
{
    private Dictionary<string, bool> puzzlesSolvedData = new Dictionary<string, bool>();

    public void AddPuzzlesSolved(string key, bool value,PuzzlesSolvedDataSO puzzlesSolvedDataSO)
    {
        puzzlesSolvedData.Add(key,value);
        SaveSystem.SavePuzzlesSolvedData(puzzlesSolvedDataSO);
    }

    public Dictionary<string,bool> GetPuzzlesSolvedDataDictionary()
    {
        return puzzlesSolvedData;
    }
    public void LoadPuzzlesSolvedData(Dictionary<string, bool> puzzlesSolvedDataDictionary)
    {
        puzzlesSolvedData = puzzlesSolvedDataDictionary;
    }

    public bool ContainsMember(string key)
    {
        if(puzzlesSolvedData.ContainsKey(key))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
