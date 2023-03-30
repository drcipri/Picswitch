using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CotunaLoading : MonoBehaviour
{
    [SerializeField] private List<Image> imagesList;

    private void Start()
    {
        StartCoroutine(CotunaImage());
    }

    IEnumerator CotunaImage()
    {
        Color color = Color.white;
        color.a = 1f;
        for (int i = 0; i < 9; i++)
        {
            int random = Random.Range(0, imagesList.Count);
            imagesList[random].color = color;
            imagesList.Remove(imagesList[random]);
            yield return new WaitForSeconds(0.1f);
        }
    }

}
