using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YouLose : MonoBehaviour
{
    [SerializeField] private PuzzleProgress puzzleProgress;
    [SerializeField] private ChooseGameType chooseGameType;
    [SerializeField] private Text youLoseText;
    [SerializeField] private GameObject playerHelp;
    [SerializeField] private SoundManagerSO soundManager;
    private bool playerWasHelped = false;

    private void Start()
    {
       SetLosingText();
       SetPlayerHelp();   
    }
    private void OnEnable()
    {
        SetSoundAgain();
    }
    private void SetSoundAgain()
    {
        if (playerWasHelped == true)
        {
            if (chooseGameType.GetGameType() == "Time")
            {
                AudioSource.PlayClipAtPoint(soundManager.GetTimeEnded(), Camera.main.transform.position, soundManager.GetVoiceVolume());
            }
            else if (chooseGameType.GetGameType() == "Moves")
            {
                AudioSource.PlayClipAtPoint(soundManager.GetOutOfMoves(), Camera.main.transform.position, soundManager.GetVoiceVolume());
            }
        }
    }

    private void SetLosingText()
    {
        
        if(chooseGameType.GetGameType() == "Time")
        {
            youLoseText.text = "Time Ended!";
        }
        else if(chooseGameType.GetGameType() == "Moves")
        {
            youLoseText.text = "Out of moves!";
        }
    }
    private void SetPlayerHelp()
    {

        if(puzzleProgress.GetProgress() >= 58f)
        {
            playerHelp.SetActive(true);
            AudioSource.PlayClipAtPoint(soundManager.GetTakeThatOffer(), Camera.main.transform.position, soundManager.GetVoiceVolume());
            playerWasHelped = true;
        }
        else if(chooseGameType.GetGameType() == "Time")
        {
            AudioSource.PlayClipAtPoint(soundManager.GetTimeEnded(), Camera.main.transform.position, soundManager.GetVoiceVolume());
        }
        else if(chooseGameType.GetGameType() == "Moves")
        {
            AudioSource.PlayClipAtPoint(soundManager.GetOutOfMoves(), Camera.main.transform.position, soundManager.GetVoiceVolume());
        }
        else
        {
            playerWasHelped = true;
        }
        
    }
    




}
