using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIUnsolvedList : MonoBehaviour
{
    
    [SerializeField] GameObject puzzleObject;
    [SerializeField] private List<PuzzleDataSO> unsolvedList;
    private UIPuzzle uiPuzzle;
    private void Start()
    {
        
        uiPuzzle = puzzleObject.GetComponent<UIPuzzle>();
        SpawnPuzzles();
    }
    public List<PuzzleDataSO> GetUnSolvedList()
    {
        return unsolvedList;
    }

    private void SpawnPuzzles()
    {
        foreach(var puzzle in unsolvedList)
        {
            uiPuzzle.SetPuzzleData(puzzle);
            Instantiate(puzzleObject, gameObject.transform);
        }
    }
    public void AddUnolvedPuzzles(PuzzleDataSO puzzleDataSO)
    {
        unsolvedList.Add(puzzleDataSO);
    }
}
