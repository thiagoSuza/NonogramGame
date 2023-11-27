using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnController : MonoBehaviour
{
    public bool isCorrect;

    [SerializeField]
    private GameObject wrongX, hintX,flag;


    private void Awake()
    {
        isCorrect = false;
    }

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(BtnPressioned);
    }

    public void BtnPressioned()
    {
        if(!NonogramSceneManager.instance.flagMarker)
        {
            flag.SetActive(false);
            if (isCorrect)
            {
                Correct();
            }
            else
            {
                Wrong();
            }
            GetComponent<Button>().interactable = false;
        }
        else
        {
            flag.SetActive(true);
        }
        
    }


    private void Correct()
    {
       NonogramSceneManager.instance.VictoryCondition(GetComponent<Button>());
    }


    private void Wrong()
    {
        NonogramSceneManager.instance.WrongClick(GetComponent<Button>());
        wrongX.SetActive(true);
    }


    public void SetHint()
    {
        hintX.SetActive(true);
        GetComponent<Button>().interactable = false;
    }
}

