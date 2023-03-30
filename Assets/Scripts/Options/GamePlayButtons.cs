using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayButtons : MonoBehaviour
{
    [Header("Windows")]
    [SerializeField] private GameObject pauseWindow;
    [SerializeField] private GameObject hintWindow;
    [SerializeField] private GameObject confirmWindowFromPause;
    [SerializeField] private GameObject confirmWindowFromYouLose;
    [SerializeField] private GameObject actualHint;
    [SerializeField] private GameObject playerHelpWindow;
    [SerializeField] private GameObject resumeGameWindow;
    [SerializeField] private GameObject youLoseWindow;
    [SerializeField] private GameObject soundSettingsWindow;
    [Header("Components")]
    [SerializeField] private PuzzleProgress puzzleProgress;
    [SerializeField] private Text confirmWindowPauseText;
    [SerializeField] private Text confirmWindowYouLoseText;
    [SerializeField] private PuzzleFeaturesSO puzzleFeature;
    [SerializeField] private ChooseGameType chooseGameType;
    [SerializeField] private Text resumeGameText;
    [SerializeField] private LoadingSceneSystem loadingSceneSystem;
    [Header("ButtonObjects")]
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject hintButton;
    

    private PuzzleDataSO puzzleData;
    


    private void Start()
    {
        puzzleData = chooseGameType.GetGamePuzzle();
    }


    //youLose window buttons
    public void RestartButtonYouLoseWindow()
    {
        confirmWindowFromYouLose.SetActive(true);
        confirmWindowYouLoseText.text = "Restart this puzzle?";
    }
    
    public void YesButtonConfirmationYouLoseWindow()
    {
        if (confirmWindowYouLoseText.text.Contains("Restart"))
        {
            SceneManager.LoadScene("GameScene");
        }
        else if(confirmWindowYouLoseText.text.Contains("menu"))
        {
            loadingSceneSystem.LoadSceneInSync("Interface");
        }
    }

    public void BackToMainMenu()
    {
        confirmWindowFromYouLose.SetActive(true);
        confirmWindowYouLoseText.text = "Back to main menu?";
    }
    
    //sound settingswindow
    public void SoundSettingsWindow()
    {
        soundSettingsWindow.SetActive(true);
    }

    //game buttons
    public void ResumeGameAfterHelp()
    {
        puzzleProgress.SetStopGame(false);
        puzzleProgress.SetTypeGameForResumingGame(chooseGameType.GetGameType());
        Interactable();
        resumeGameWindow.SetActive(false);
        
    }
    public void GetExtraMovesOrTime(bool pay)
    {
        if (pay == true && puzzleFeature.GetGems() >= 10)
        {
            puzzleFeature.PayGems(10,puzzleFeature);
        }
        if(chooseGameType.GetGameType() == "Time")
        {
            float time = puzzleData.GetTimer() / 4f;
            puzzleProgress.AddTime(time);
            playerHelpWindow.SetActive(false);
            youLoseWindow.SetActive(false);
            resumeGameText.text = $"You got {time.ToString("F0")} more seconds!";
            resumeGameWindow.SetActive(true);
         
        }
        else if(chooseGameType.GetGameType() == "Moves")
        {
            int moves = puzzleData.GetMoves() / 4;
            puzzleProgress.AddMoves(moves);
            playerHelpWindow.SetActive(false);
            youLoseWindow.SetActive(false);
            resumeGameText.text = $"You got another {moves} moves!";
            resumeGameWindow.SetActive(true);
        }
    }
    public void ShowHintWithGems()
    {
        actualHint.SetActive(true);
        puzzleFeature.PayGems(5,puzzleFeature);
    }
    public void PauseButton()
    {
        pauseWindow.SetActive(true);
        puzzleProgress.SetStopGame(true);
        puzzleProgress.SetTimeGamePzProgress(false);
        NonInteractable();
    }
    public void HintButton()
    {
        hintWindow.SetActive(true);
        puzzleProgress.SetStopGame(true);
        puzzleProgress.SetTimeGamePzProgress(false);
        NonInteractable();
    }

    public void ResumeGameClosePauseWindow()
    {
        pauseWindow.SetActive(false);
        puzzleProgress.SetStopGame(false);
        Interactable();
        if (puzzleProgress.GetMoveGame() != true)
        {
            puzzleProgress.SetTimeGamePzProgress(true);
        }
        
    }
    public void ResumeGameCloseHintWindow()
    {
        hintWindow.SetActive(false);
        puzzleProgress.SetStopGame(false);
        Interactable();
        if (puzzleProgress.GetMoveGame() != true)
        {
            puzzleProgress.SetTimeGamePzProgress(true);
        }
    }

    public void RestartButtonPauseWindow()
    {
        confirmWindowFromPause.SetActive(true);
        confirmWindowPauseText.text = "Restart this puzzle?";
    }
   

  
    public void YesButtonConfirmationPauseWindow()
    {
        if (confirmWindowPauseText.text.Contains("Restart"))
        {
            SceneManager.LoadScene("GameScene");
        }
        else if (confirmWindowPauseText.text.Contains("menu"))
        {
            loadingSceneSystem.LoadSceneInSync("Interface");
        }
    }

    public void YouWin()
    {
        loadingSceneSystem.LoadSceneInSync("Interface");
    }
    //main menu
    public void MainMenuButton()
    {
        confirmWindowFromPause.SetActive(true);
        confirmWindowPauseText.text = "Back to main menu?";
    }
   
    // interactable
    public void NonInteractable()
    {
        pauseButton.GetComponent<Button>().interactable = false;
        hintButton.GetComponent<Button>().interactable = false;
    }
    public void Interactable()
    {
        pauseButton.GetComponent<Button>().interactable = true;
        hintButton.GetComponent<Button>().interactable = true;
    }
    

   

}
