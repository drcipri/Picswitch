using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnsolvedAndSolvedButtons : MonoBehaviour
{
    [SerializeField] private GameObject puzzlePanelOne;
    [SerializeField] private GameObject puzzlePanelTwo;
    [SerializeField] private Button buttonOne;
    [SerializeField] private Button buttonTwo;
    [SerializeField] private GameObject puzzlesSolvedNumber;


    private void Start()
    {
        SetButton();
        buttonOne.onClick.AddListener(OnClick);
    }
    private void SetButton()
    {
        if (puzzlePanelOne.activeSelf == true)
        {
            buttonOne.interactable = false;
        }
    }

    public void OnClick()
    {
        puzzlePanelOne.SetActive(true);
        puzzlePanelTwo.SetActive(false);
        buttonOne.interactable = false;
        buttonTwo.interactable = true;

    }
    public void OnClickSolved()
    {
        puzzlesSolvedNumber.SetActive(true);
    }
    public void OnClickUnsolved()
    {
        puzzlesSolvedNumber.SetActive(false);
    }
}
