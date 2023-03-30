using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWorks : MonoBehaviour
{
    [SerializeField] private GameObject cameraPos;
    // Start is called before the first frame update
    void Start()
    {
        
        transform.position = new Vector3(cameraPos.transform.position.x, cameraPos.transform.position.y, -3f);
    }

   
}
