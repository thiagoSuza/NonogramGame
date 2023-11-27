using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualStarController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] stars;



    private void OnEnable()
    {
        SetStars(NonogramSceneManager.instance.stars);
    }

    public void SetStars(int aux)
    {
        if (aux == 1)
        {
            stars[0].SetActive(true);
            stars[1].SetActive(false);
            stars[2].SetActive(false);

        }
        else if (aux == 2)
        {
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(false);
        }
        else if (aux == 3)
        {
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
        }
        else
        {
            stars[0].SetActive(false);
            stars[1].SetActive(false);
            stars[2].SetActive(false);
        }
    }

}
