using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hint : MonoBehaviour
{
    [SerializeField] private Slider slider2;
    [SerializeField] private Slider slider;
    [SerializeField] private ChooseGameType chooseGameType;
    [SerializeField] private Image hintSprite;
    [SerializeField] private float timeWatch = 2f;
    [SerializeField] private float timeWatch2 = 3f;
    [SerializeField] private GameObject youWinWindow;
    [SerializeField] private PuzzleFeaturesSO puzzleFeaturesSO;
    private PuzzleDataSO puzzle;
    bool playHint = true;
    bool hintFromAds = false;
    
    

    private void Start()
    {
        puzzle = chooseGameType.GetGamePuzzle();
        hintSprite.sprite = puzzle.GetOriginalPicture();
        
    }
    private void Update()
    {
        PlayHint();
    }

    private void PlayHint()
    {
        if (playHint == true)
        {
            int random = Random.Range(0, 5);
            switch (random)
            {
                case 0:
                    hintSprite.fillMethod = Image.FillMethod.Horizontal;
                    playHint = false;
                    break;
                case 1:
                    hintSprite.fillMethod = Image.FillMethod.Vertical;
                    playHint = false;
                    break;
                case 2:
                    hintSprite.fillMethod = Image.FillMethod.Radial360;
                    playHint = false;
                    break;
                case 3:
                    hintSprite.fillMethod = Image.FillMethod.Radial180;
                    playHint = false;
                    break;
                case 4:
                    hintSprite.fillMethod = Image.FillMethod.Radial90;
                    playHint = false;
                    break;

            }
        }
        slider.maxValue = timeWatch;
        slider.value += Time.deltaTime;
        if (slider.value == slider.maxValue)
        {
            StartCoroutine(FewSeconds());
          
        }
        

    }
    IEnumerator FewSeconds()
    {
        
        slider2.maxValue = timeWatch2;
        slider2.enabled = true;
        slider2.value += Time.deltaTime;
        yield return new WaitForSeconds(timeWatch2);
        gameObject.SetActive(false);
        slider.value = 0;
        playHint = true;
        slider2.enabled = false;
        slider2.value = 0;
        if (hintFromAds == true)
        {
            WinGemsForWatchingAds();
        }
        
        
    }
    private void WinGemsForWatchingAds()
    {
        int randomGems = Random.Range(5, 21);
        puzzleFeaturesSO.AddGems(randomGems, puzzleFeaturesSO);
        youWinWindow.transform.GetChild(0).gameObject.GetComponent<Text>().text = $"You won {randomGems} gems!";
        youWinWindow.SetActive(true);
        hintFromAds = false;
    }
    public void SetHintFromAdsTrue()
    {
        hintFromAds = true;
    }
    
    

}
