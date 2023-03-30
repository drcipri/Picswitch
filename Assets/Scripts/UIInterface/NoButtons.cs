using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoButtons : MonoBehaviour
{
    [SerializeField] private GameObject windowToClose;

    public void CloseWindow()
    {
        windowToClose.SetActive(false);
    }
}
