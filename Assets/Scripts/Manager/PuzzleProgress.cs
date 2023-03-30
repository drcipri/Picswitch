using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using System;

public class PuzzleProgress : MonoBehaviour
{
    [Header("UI Objects")]
    [SerializeField] private GameObject youLoseWindow;
    [SerializeField] private GameObject youWinWindow;
    [Header("UIComponents")]
    [SerializeField] private Sprite timeSprite;
    [SerializeField] private Sprite movesSprite;
    [SerializeField] private Text gameTypeText;
    [SerializeField] private Text progressText;
    [SerializeField] private Image gameTypeImage;
    [Header("Components")]
    [SerializeField] private LocationManager locationManager;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private GamePlayButtons gamePlayButtons;
    [SerializeField] private SoundManagerSO soundManager;
    [SerializeField] private PuzzleFeaturesSO puzzleFeaturesSO;
    [SerializeField] private PuzzlesSolvedDataSO puzzlesSolvedDataSO;
    [Header("Effects")]
    [SerializeField] private List<GameObject> fireWorks;


   


    private PuzzleDataSO puzzleDataSO;
    private bool stopGame = false;
    private bool timeGame = false;
    private bool moveGame = false;
    private float time;
    private int moves;
    private bool shakeLose = false;
    private bool shakeWin = false;
    private float progress = 0f;
    private bool progressCheck = true;
    private bool playSound1 = true;
    private bool playSound2 = true;
    

    
    private void Start()
    {
        time = puzzleDataSO.GetTimer();
        moves = puzzleDataSO.GetMoves();
        SetTypeGameVariables();
        StartCoroutine(ShakeLose());
        StartCoroutine(ShakeWin());
        StartCoroutine(Progress());
    }


    private void Update()
    {
        SetGameType();
    }

    //active methods
    IEnumerator Progress()
    {
        float mainNumber = (int)puzzleDataSO.GetMatriceType() * (int)puzzleDataSO.GetMatriceType();
        float realTimeNumber = locationManager.GetNumberOfSquaresInPlace();
        float divide = realTimeNumber / mainNumber;
        while (true)
        {
            realTimeNumber = locationManager.GetNumberOfSquaresInPlace();
            divide = realTimeNumber / mainNumber;
            progress = divide * 100;
            progressText.text = progress.ToString("F0") + "%";
            
            if (progress >= 100f)
            {
                if (puzzleDataSO.GetPuzzlesSolvedValue() != true) { puzzleFeaturesSO.PuzzleSolved(puzzleFeaturesSO); }
                puzzleDataSO.PuzzleSolved();
                if (puzzlesSolvedDataSO.ContainsMember(puzzleDataSO.name) != true)
                {
                    puzzlesSolvedDataSO.AddPuzzlesSolved(puzzleDataSO.name, puzzleDataSO.GetPuzzlesSolvedValue(), puzzlesSolvedDataSO);
                }
                stopGame = true;
                timeGame = false;
                moveGame = false;
                shakeWin = true;
                gamePlayButtons.NonInteractable();
                progressCheck = false;

            }
            if(progress >= 50 && playSound1 == true)
            {
                int random = UnityEngine.Random.Range(0, 2);
                if (random == 0)
                {
                    AudioSource.PlayClipAtPoint(soundManager.GetYouCanMakeIt(), Camera.main.transform.position, soundManager.GetVoiceVolume());
                }
                else
                {
                    AudioSource.PlayClipAtPoint(soundManager.GetTryHarder(), Camera.main.transform.position, soundManager.GetVoiceVolume());
                }
                playSound1 = false;
            }

            progressCheck = false;
            yield return new WaitUntil(() => progressCheck == true);
        }

    }
    private void SetGameType()
    {
        if(timeGame == true)
        {
            time -= Time.deltaTime;
            TimeSpan timeInTime = TimeSpan.FromSeconds(time);
            gameTypeText.text = timeInTime.ToString().Substring(3, 5);
            gameTypeImage.sprite = timeSprite;
            if (time <= 0.1f)
            {
                stopGame = true;
                timeGame = false;
                shakeLose = true;
                gamePlayButtons.NonInteractable();

            }
            
            if(time <= 22f && playSound2 == true)
            {
                AudioSource.PlayClipAtPoint(soundManager.GetTwentySeconds(),Camera.main.transform.position, soundManager.GetVoiceVolume());
                playSound2 = false;
            }
            
        }
        else if(moveGame == true)
        {
            gameTypeText.text = moves.ToString();
            gameTypeImage.sprite = movesSprite;
            if (moves == 0)
            {
                stopGame = true;
                moveGame = false;
                shakeLose = true;
                gamePlayButtons.NonInteractable();

            }
            if (moves <= 10 && playSound2 == true)
            {
                AudioSource.PlayClipAtPoint(soundManager.GetTenMoves(), Camera.main.transform.position, soundManager.GetVoiceVolume());
                playSound2 = false;
            }
        }
    }
    public void SetTypeGameVariables()
    {

        if (puzzleDataSO.GetTimeGame() == true)
        {
            timeGame = true;
            puzzleDataSO.DisableTypeGame();
        }
        else if (puzzleDataSO.GetMoveGame() == true)
        {
            moveGame = true;
            puzzleDataSO.DisableTypeGame();
        }
        
    }

   IEnumerator ShakeLose()
   {
        
        while(true)
        {
            yield return new WaitUntil(() => shakeLose == true);
            virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 3f;
            yield return new WaitForSeconds(0.8f);
            virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0f;
            shakeLose = false;
            youLoseWindow.SetActive(true);
        }
   }
    IEnumerator ShakeWin()
    {

        while (true)
        {
            yield return new WaitUntil(() => shakeWin == true);
            SetFireWorks();
            yield return new WaitForSeconds(4.1f);
            shakeWin = false;
            youWinWindow.SetActive(true);

        }
    }
    IEnumerator PlayFireWorkSound()
    {
        float playSound = 0f;
        while (playSound < 3.5f)
        {
            AudioSource.PlayClipAtPoint(soundManager.GetFireworkSound(), Camera.main.transform.position, soundManager.GetEffectsVolume());
            float random = UnityEngine.Random.Range(0f, 0.25f);
            playSound += random;
            yield return new WaitForSeconds(random);
        }
    }

    private void SetFireWorks()
    {
        if((int)puzzleDataSO.GetMatriceType() == 3 )
        {
            int random = 0;
            fireWorks[random].SetActive(true);
            StartCoroutine(PlayFireWorkSound());
        }
        else if ((int)puzzleDataSO.GetMatriceType() == 4)
        {
            int random = UnityEngine.Random.Range(1, 3);
            fireWorks[random].SetActive(true);
            StartCoroutine(PlayFireWorkSound());
        }
        else if((int)puzzleDataSO.GetMatriceType() == 5 )
        {
            int random = UnityEngine.Random.Range(3, 5);
            fireWorks[random].SetActive(true);
            StartCoroutine(PlayFireWorkSound());
        }
        else if ((int)puzzleDataSO.GetMatriceType() == 6 || (int)puzzleDataSO.GetMatriceType() == 7)
        {
            int random = UnityEngine.Random.Range(5, 8);
            fireWorks[random].SetActive(true);
            StartCoroutine(PlayFireWorkSound());
        }
        else
        {
            Debug.Log("Matryce out of range");
        }


    }



    //SettingsMethods
    public void SetPuzzle(PuzzleDataSO puzzle)
    {
        puzzleDataSO = puzzle;
    }    
    public void SetStopGame(bool stop)
    {
        stopGame = stop;
    }
    public bool GetStopGame()
    {
        return stopGame;
    }

    public void SetMoves()
    {
        moves -= 1;
    }
    public bool GetMoveGame()
    {
        return moveGame;
    }
    public void SetTimeGamePzProgress(bool time)
    {
        timeGame = time;
    }
    public float GetProgress()
    {
        return progress;
    }

    public void AddTime(float time)
    {
        this.time += time;
    }
    public void AddMoves(int moves)
    {
        this.moves += moves;
    }
    public void SetTypeGameForResumingGame(string typeGame)
    {
        if(typeGame == "Time")
        {
            timeGame = true;
        }
        else if (typeGame == "Moves")
        {
            moveGame = true;
        }
    }
    public void EnableProgressCheck()
    {
        progressCheck = true;
    }

 
   
  
  
}
