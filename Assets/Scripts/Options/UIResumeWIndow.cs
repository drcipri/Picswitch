using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIResumeWIndow : MonoBehaviour
{
    private void OnEnable()
    {
        transform.position = new Vector2(transform.position.x, -Screen.height);
        transform.LeanMoveLocalY(0, 0.3f);
    }
}
