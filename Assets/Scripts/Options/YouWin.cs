using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YouWin : MonoBehaviour
{
    [SerializeField] private Image originalPicture;
    [SerializeField] private ChooseGameType chooseGameType;
    [SerializeField] private Text puzzleSolvedText;
    [SerializeField] private Slider slider;
    [SerializeField] private GameObject mainMenuButton;
    [SerializeField] private SoundManagerSO soundManager;
    private PuzzleDataSO puzzleData;

    private void Awake()
    {
        puzzleSolvedText.transform.localRotation = Quaternion.Euler(0, 180, 0);
        puzzleData = chooseGameType.GetGamePuzzle();
        originalPicture.sprite = puzzleData.GetOriginalPicture();
    }
    private void Start()
    {
        StartCoroutine(SetWin());
    }

    private void Update()
    {
        if(slider.isActiveAndEnabled == true)
        {
            slider.value += Time.deltaTime;
        }    
    }

    IEnumerator SetWin()
    {
        bool check = true;
        if (check)
        {
            puzzleSolvedText.transform.LeanRotateY(0, 0.5f);
            yield return new WaitForSeconds(0.6f);
            slider.enabled = true;
            yield return new WaitForSeconds(1f);
            mainMenuButton.SetActive(true);

        }

    }





}
