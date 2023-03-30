using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InterfaceEngine : MonoBehaviour
{
    [Header("Data Objects")]
    [SerializeField] private PuzzleFeaturesSO puzzleFeaturesSO;
    [Header("UI Components")]
    [SerializeField] private Text gemsText;
    [SerializeField] private Text puzzlesSolvedText;
    [SerializeField] private TextMeshProUGUI titleText;
    [Header("Rank Transition")]
    [SerializeField] private GameObject rankTransitionCanvas;
    [SerializeField] private TextMeshProUGUI transitionRankText;
    [SerializeField] private SoundManagerSO soundManager;
    
    
    private void OnEnable()
    {
        gemsText.text = puzzleFeaturesSO.GetGems().ToString();
        puzzlesSolvedText.text = puzzleFeaturesSO.GetPuzzlesSolved().ToString();
        puzzleFeaturesSO.SetTitle();
        titleText.text = puzzleFeaturesSO.GetTitle();
        SetTitleTextColor();
    }
    private void Start()
    {
        UpRank();
    }
    private void Update()
    {
        gemsText.text = puzzleFeaturesSO.GetGems().ToString();
    }



    public void SetTitleTextColor()
    {
        if(puzzleFeaturesSO.GetTitle() == "SMART") { titleText.color = Color.yellow; }
        else if (puzzleFeaturesSO.GetTitle() == "GENIUS") { titleText.color = Color.green; }
        else if (puzzleFeaturesSO.GetTitle() == "DAVINCI") { titleText.color = Color.red; }
        else if (puzzleFeaturesSO.GetTitle() == "EINSTEIN") { titleText.color = Color.cyan; }
        else if (puzzleFeaturesSO.GetTitle() == "STARK") { titleText.color = Color.magenta; }
    }

    public void UpRank()
    {
        if(puzzleFeaturesSO.GetTitle() == "GENIUS" && puzzleFeaturesSO.GetRankTransitionRewards() == 0)
        {
            rankTransitionCanvas.SetActive(true);
            transitionRankText.text = puzzleFeaturesSO.GetTitle();
            transitionRankText.color = Color.green;
            puzzleFeaturesSO.AddGems(50, puzzleFeaturesSO);
            AudioSource.PlayClipAtPoint(soundManager.YouhaveMyRespect(), Camera.main.transform.position, soundManager.GetVoiceVolume());
            puzzleFeaturesSO.AddTransition(puzzleFeaturesSO);
        }
        else if(puzzleFeaturesSO.GetTitle() == "DAVINCI" && puzzleFeaturesSO.GetRankTransitionRewards() == 1)
        {
            rankTransitionCanvas.SetActive(true);
            transitionRankText.text = puzzleFeaturesSO.GetTitle();
            transitionRankText.color = Color.red;
            puzzleFeaturesSO.AddGems(50, puzzleFeaturesSO);
            AudioSource.PlayClipAtPoint(soundManager.AreYouFriend(), Camera.main.transform.position, soundManager.GetVoiceVolume());
            puzzleFeaturesSO.AddTransition(puzzleFeaturesSO);
        }
        else if (puzzleFeaturesSO.GetTitle() == "EINSTEIN" && puzzleFeaturesSO.GetRankTransitionRewards() == 2)
        {
            rankTransitionCanvas.SetActive(true);
            transitionRankText.text = puzzleFeaturesSO.GetTitle();
            transitionRankText.color = Color.cyan;
            puzzleFeaturesSO.AddGems(50, puzzleFeaturesSO);
            AudioSource.PlayClipAtPoint(soundManager.DidYouCreate(), Camera.main.transform.position, soundManager.GetVoiceVolume());
            puzzleFeaturesSO.AddTransition(puzzleFeaturesSO);
        }
        else if (puzzleFeaturesSO.GetTitle() == "STARK" && puzzleFeaturesSO.GetRankTransitionRewards() == 3)
        {
            rankTransitionCanvas.SetActive(true);
            transitionRankText.text = puzzleFeaturesSO.GetTitle();
            transitionRankText.color = Color.magenta;
            puzzleFeaturesSO.AddGems(50, puzzleFeaturesSO);
            AudioSource.PlayClipAtPoint(soundManager.IronMan(), Camera.main.transform.position, soundManager.GetVoiceVolume());
            puzzleFeaturesSO.AddTransition(puzzleFeaturesSO);
        }

    }

}
