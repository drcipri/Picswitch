using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LocationManager : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameObject squareLocked;
    [SerializeField] private GameObject cameraPointFocus;
    [SerializeField] private PuzzleProgress puzzleProgress;

    [Header("Locations/Places")]
    [SerializeField] private List<Vector3> squareLocations;
    [SerializeField] private int squaresInPlace;

    


    //SquareLocations
    public void SetSquareLocations(Vector3 squarePosition)
    {
        squareLocations.Add(squarePosition);
    }
    public List<Vector3> GetSquaresLocations()
    {
        return squareLocations;
    }
    public void RemoveLocationFromSquareLocation(int index)
    {
        squareLocations.Remove(squareLocations[index]);
    }

    //square locked
    public void SetSquareLocked(GameObject locked)
    {
        squareLocked = locked;
    }
    public GameObject GetSquareLocked()
    {
        return squareLocked;    
    }
    public void SetSquareLockedNull()
    {
        squareLocked = null;
    }


    //camera
    public Transform GetFocusCameraLocation(PuzzleDataSO puzzleData)
    {
        
        int focusLocation = (int)Mathf.Floor(squareLocations.Count / 2);
        Vector3 focus = squareLocations[focusLocation];
        if((int)puzzleData.GetMatriceType() == 3)
        {
            focus.x = 0.57f;
            cameraPointFocus.transform.position = focus;
        }
        else if ((int)puzzleData.GetMatriceType() == 4)
        {
            focus = new Vector2(0.97f, 1.5f);
            cameraPointFocus.transform.position = focus;
        }
        else if((int)puzzleData.GetMatriceType() == 5)
        {
            focus.x = 1.31f;
            cameraPointFocus.transform.position = focus;
        }
        else if ((int)puzzleData.GetMatriceType() == 6)
        {
            focus = new Vector2(1.65f, 2.5f);
            cameraPointFocus.transform.position = focus;
        }
        else if((int)puzzleData.GetMatriceType() == 7)
        {
            focus.x = 2f;
            cameraPointFocus.transform.position = focus;
        }
        return cameraPointFocus.transform;
    }

    //square in place
   
    public void SetSquareInPlace(bool operation)
    {
        if(operation == true)
        {
            squaresInPlace++;
            puzzleProgress.EnableProgressCheck();
        }
        else if (operation == false)
        {
            squaresInPlace--;
            puzzleProgress.EnableProgressCheck();
        }
        
    }

    public float GetNumberOfSquaresInPlace()
    {
        return squaresInPlace;
    }
   
}
