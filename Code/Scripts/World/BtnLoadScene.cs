using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static Unity.Burst.Intrinsics.X86;

public class BtnLoadScene : MonoBehaviour
{
    [SerializeField]
    private NonogramSO data;

    [SerializeField]
    private string sceneName;

    [SerializeField]
    private int nonogramIndex;

    [SerializeField]
    private Image nonogramImagem;
    [SerializeField]
    private Text nonogramName;

    [SerializeField]
    private GameObject inicial, played;

    [SerializeField]
    private GameObject[] stars;

    

    private void OnEnable()
    {
        SetImageOfBtn();
    }

    public void SetImageOfBtn()
    {
        if(data.alredyWon == false)
        {
            played.SetActive(false);
            inicial.SetActive(true);
        }
        else
        {
            played.SetActive(true);
            inicial.SetActive(false);
            nonogramImagem.sprite = data.img;
            nonogramName.text = data.nonogramName;
            SetStars(data.stars);

        }
    }

    public void LoadScene()
    {
        SavePlayerPosition.instance.SavePlayerPositionS();
        PlayerPrefs.SetInt("SelectedLevel", nonogramIndex);
        SceneManager.LoadScene(sceneName);
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
