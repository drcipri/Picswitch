using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundColor : MonoBehaviour
{
    [SerializeField] private PuzzleFeaturesSO puzzleFeaturesSO;
    [SerializeField] private Image sprite;

    private void Start()
    {
        
        ColorChange();
    }

    public void ColorChange()
    {
        if(puzzleFeaturesSO.GetPuzzlesSolved() < 10)
        {
            sprite.color = Color.yellow;
        }
        else if(puzzleFeaturesSO.GetPuzzlesSolved() < 30)
        {
            sprite.color = Color.green;
        }
        else if(puzzleFeaturesSO.GetPuzzlesSolved() < 50)
        {
            sprite.color = Color.red;
        }
        else if(puzzleFeaturesSO.GetPuzzlesSolved() < 70)
        {
            sprite.color = Color.cyan;
        }
        else
        {
            sprite.color = Color.magenta;
        }
    }
}
