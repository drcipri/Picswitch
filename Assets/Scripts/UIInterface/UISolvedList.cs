using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISolvedList : MonoBehaviour
{
    
    [SerializeField] GameObject puzzleObject;
    [SerializeField] private List<PuzzleDataSO> solvedList;
    [SerializeField] private Text youHaventSolvedPuzzlesYetText;
    private UIPuzzle uiPuzzle;

    private void Start()
    {
        
        uiPuzzle = puzzleObject.GetComponent<UIPuzzle>();
        SpawnPuzzles();
        

    }


    public List<PuzzleDataSO> GetSolvedList()
    {
        return solvedList;
    }
    private void SpawnPuzzles()
    {
        foreach (var puzzle in solvedList)
        {
            uiPuzzle.SetPuzzleData(puzzle);
            Instantiate(puzzleObject, gameObject.transform);
        }
        if (transform.childCount > 0)
        {
            youHaventSolvedPuzzlesYetText.gameObject.SetActive(false);
        }
    }

    public void AddSolvedPuzzles(PuzzleDataSO puzzleDataSO)
    {
        solvedList.Add(puzzleDataSO);
    }




}
