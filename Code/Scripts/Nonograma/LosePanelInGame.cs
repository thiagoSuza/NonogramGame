using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LosePanelInGame : MonoBehaviour
{
    [SerializeField] private GameObject AdsBtn, returnBtn;
    private void OnEnable()
    {
        if(PlayerPrefs.GetInt("NoADS2", 0) == 1)
        {
            AdsBtn.SetActive(false);
            returnBtn.SetActive(true);
        }
        else
        {
            AdsBtn.SetActive(true);
            returnBtn.SetActive(false);
        }
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MapScene");
    }
}
