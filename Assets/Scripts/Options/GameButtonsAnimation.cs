using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButtonsAnimation : MonoBehaviour
{
    private void Awake()
    {
        transform.localScale = Vector2.zero;
    }
    private void OnEnable()
    {
        transform.localScale = Vector2.zero;
        transform.LeanScale(Vector2.one, 0.25f);
        
    }
   
}
