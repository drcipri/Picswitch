using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWindowsAnimation2 : MonoBehaviour
{
    private void OnEnable()
    {
        transform.localPosition = new Vector2(0, Screen.height);
        transform.LeanMoveLocalY(0, 0.3f);
    }

    public void CloseWindow()
    {
        transform.LeanMoveLocalY(Screen.height, 0.3f).setOnComplete(OnComplete);
    }
    private void OnComplete()
    {
        gameObject.SetActive(false);
    }
}
