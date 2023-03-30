using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWindowAnimation3 : MonoBehaviour
{
    private void OnEnable()
    {
        transform.position = new Vector2(-Screen.width, transform.position.y);
        transform.LeanMoveLocalX(0, 0.3f);
    }
}
