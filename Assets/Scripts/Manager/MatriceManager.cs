using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MatriceManager : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private float spaceBetweenSquares = 0f;
    [Header("Objects")]
    [SerializeField] private GameObject square;
    [SerializeField] private GameObject matriceManager;
    [Header("Components")]
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private LocationManager locationManager;
    [SerializeField] private PuzzleProgress puzzleProgress;
    [SerializeField] private SoundManagerSO soundManager;
    
    private ChooseGameType chooseGameType;
    private PuzzleDataSO puzzleData;
    private int columns;
    private int rows;
    private List<GameObject> squares = new List<GameObject>();

    //sprite index of puzzleData
    private int spriteIndex = 0;


    private void Awake()
    {
        SetGame();
        GenerateMatrice();
        FocusCamera();
        RandomizePuzzle();
        puzzleProgress.SetPuzzle(puzzleData);
    }
    private void Start()
    {
        AudioSource.PlayClipAtPoint(soundManager.GetPuzzleStart(), Camera.main.transform.position, soundManager.GetVoiceVolume());
    }

    private void FocusCamera()
    {
        
        if ((int)puzzleData.GetMatriceType() == 3)
        {

            virtualCamera.Follow = locationManager.GetFocusCameraLocation(puzzleData);
            virtualCamera.m_Lens.OrthographicSize = 1.6f;
        }
        else if ((int)puzzleData.GetMatriceType() == 4)
        {

            virtualCamera.Follow = locationManager.GetFocusCameraLocation(puzzleData);
            virtualCamera.m_Lens.OrthographicSize = 2.12f;
        }
        else if ((int)puzzleData.GetMatriceType() == 5)
        {

            virtualCamera.Follow = locationManager.GetFocusCameraLocation(puzzleData);
            virtualCamera.m_Lens.OrthographicSize = 2.7f;
        }
        else if ((int)puzzleData.GetMatriceType() == 6)
        {

            virtualCamera.Follow = locationManager.GetFocusCameraLocation(puzzleData);
            virtualCamera.m_Lens.OrthographicSize = 3.2f;
        }
        else if ((int)puzzleData.GetMatriceType() == 7)
        {

            virtualCamera.Follow = locationManager.GetFocusCameraLocation(puzzleData);
            virtualCamera.m_Lens.OrthographicSize = 3.8f;
        }


    }

    public void GenerateMatrice()
    {
        columns = (int)puzzleData.GetMatriceType();
        rows = (int)puzzleData.GetMatriceType();
        float spaceBetweenWidth = 0f;
        float spaceBetweenHeight = 0f;
        for (int x = 0; x < columns; x++)
        {

            if (x != 0) { spaceBetweenWidth += spaceBetweenSquares; }
            for (int y = 0; y < rows; y++)
            {

                if (y != 0) { spaceBetweenHeight += spaceBetweenSquares; }
                var puzzle = Instantiate(square, new Vector3(x + spaceBetweenWidth, y + spaceBetweenHeight),
                                         Quaternion.identity, matriceManager.transform);
                puzzle.name = $"Square {x}{y}";
                puzzle.GetComponent<SquareBehaviour>().SetSprite(puzzleData.GetPuzzleSprites(spriteIndex));
                puzzle.GetComponent<SquareBehaviour>().StoreOriginalLocation(puzzle.transform.position); 
                
                locationManager.SetSquareLocations(puzzle.transform.position);

                squares.Add(puzzle);

                if (y == rows - 1) { spaceBetweenHeight = 0f; }
                spriteIndex++;
            }
        }
    }

    private void RandomizePuzzle()
    {
        bool loop = true;
        foreach(var square in squares)
        {
            loop = true;
            while(loop == true)
            {
                int random = Random.Range(0, locationManager.GetSquaresLocations().Count);
                if(square.transform.position == locationManager.GetSquaresLocations()[random])
                {
                    if(locationManager.GetSquaresLocations().Count == 1) //for last place bug
                    {
                        int anotherPlace = Random.Range(0, squares.Count - 1);
                        Vector3 buggedSquare = square.transform.position;
                        square.transform.position = squares[anotherPlace].transform.position;
                        squares[anotherPlace].transform.position = buggedSquare;
                        loop = false;
                    }
                    else if(random == 0) { random += 1; }
                    else if (random == locationManager.GetSquaresLocations().Count - 1) { random -= 1; }
                    else { random += 1; }

                }
                
                if (square.transform.position != locationManager.GetSquaresLocations()[random] && loop == true)
                {
                    square.transform.position = locationManager.GetSquaresLocations()[random];
                    locationManager.RemoveLocationFromSquareLocation(random);
                    loop = false;
                }
               
            }
        }
    }
    
  

    //Sets
    private void SetGame()
    {
        chooseGameType = GameObject.FindGameObjectWithTag("GameType").GetComponent<ChooseGameType>();
        puzzleData = chooseGameType.GetGamePuzzle();
        chooseGameType.SetGameType();

    }
}
