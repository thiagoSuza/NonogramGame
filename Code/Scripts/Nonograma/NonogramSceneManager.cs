
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NonogramSceneManager : MonoBehaviour
{
    public static NonogramSceneManager instance;

    [SerializeField] private GameObject settingsPanel;
    [SerializeField]
    private NonogramController nc;

    [SerializeField]
    private HintADS hAds;

    private int lifes;
    private int hint;
    private int extralife;

    [SerializeField]
    private Text hintText;

    [SerializeField]
    private GameObject[] heartImagens;
    [SerializeField]
    private GameObject[] ExtraheartImagensF, ExtraheartImagensB;
    [SerializeField]
    private GameObject padLock;
    [SerializeField]
    private GameObject winPanel, losePanel;
    

    [SerializeField]
    private List<Button> correctBtns = new List<Button>();
    [SerializeField]
    private List<Button> wrongBtns = new List<Button>();

    [SerializeField]
    private Button hintads;

    [SerializeField]
    private int hintAux;

    private int dataIndex;

    public int stars;

    public bool flagMarker;

    private void Awake()
    {
        dataIndex = PlayerPrefs.GetInt("SelectedLevel", 0);
        if (instance != null)
        {
            
            Destroy(instance);
        }        
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        SetLife();
        Invoke("GetBtnList",.9f);
        hintAux = 0;
        stars = 3;
        flagMarker = false;
        Debug.Log(PlayerPrefs.GetInt("NoADS", 0));
        Debug.Log(extralife);


    }

    

    private void GetBtnList()
    {
        foreach(Button _button in nc.btn) 
        {
            if(_button.GetComponent<BtnController>().isCorrect == true)
            {
                correctBtns.Add(_button);
            }
            else
            {
                wrongBtns.Add(_button);
            }
        }

       
    }

    private void SetLife()
    {
        
        if (PlayerPrefs.GetInt("ExtraLifeSlot", 0) == 1)
        {
            lifes = 4;
            hint = 0;
            hintText.text = hint.ToString();
            HeartImagensActiveController();
            padLock.SetActive(false);
        }
        else
        {
            padLock.SetActive(true);
            lifes = 3;
            hint = 0;
            hintText.text = hint.ToString();
            HeartImagensActiveController();
        }

        if (PlayerPrefs.GetInt("NoADS2", 0) == 1)
        {
            foreach(var p in ExtraheartImagensF)
            {
                p.SetActive(true);
            }

            foreach (var p in ExtraheartImagensB)
            {
                p.SetActive(true);
            }

            extralife = 3;
            hint = 1;
            hintText.text = hint.ToString();
        }
        else
        {
            extralife = 0;
        }
       
    }

    public void WrongClick(Button aux)
    {
        if(extralife > 0)
        {
            extralife--;
            stars--;
            wrongBtns.Remove(aux);
            HeartExtraImagens();
        }
        else
        {
            lifes--;
            stars--;
            if (stars < 0)
            {
                stars = 0;
            }
            HeartImagensActiveController();
            wrongBtns.Remove(aux);
            if (lifes == 0)
            {
                losePanel.SetActive(true);
            }
        }
        
    }

    public void UseHint()
    {
        if( hint > 0)
        {
            hint--;
            int aux = Random.Range(0,correctBtns.Count);
            correctBtns[aux].onClick.Invoke();
            hintads.interactable = false;
        }
        else
        {
            hAds.ShowAd();
        }
        hintText.text = hint.ToString();
    }


    private void HeartExtraImagens()
    {
        // ------------------------------------------------------ AQUI
        if (extralife == 3)
        {
            ExtraheartImagensF[0].SetActive(true);
            ExtraheartImagensF[1].SetActive(true);
            ExtraheartImagensF[2].SetActive(true);
        }
        else if (extralife == 2)
        {
            ExtraheartImagensF[0].SetActive(true);
            ExtraheartImagensF[1].SetActive(true);
            ExtraheartImagensF[2].SetActive(false);
        }
        else if (extralife == 1)
        {
            ExtraheartImagensF[0].SetActive(true);
            ExtraheartImagensF[1].SetActive(false);
            ExtraheartImagensF[2].SetActive(false);
        }
        else
        {
            ExtraheartImagensF[0].SetActive(false);
            ExtraheartImagensF[1].SetActive(false);
            ExtraheartImagensF[2].SetActive(false);
        }
    }
    // ------------------------------------------------------ AQUI
    private void HeartImagensActiveController()
    {
        if(PlayerPrefs.GetInt("ExtraLifeSlot", 0) != 1)
        {
            if (lifes == 3)
            {
                heartImagens[0].SetActive(true);
                heartImagens[1].SetActive(true);
                heartImagens[2].SetActive(true);
            }
            else if (lifes == 2)
            {
                heartImagens[0].SetActive(true);
                heartImagens[1].SetActive(true);
                heartImagens[2].SetActive(false);
            }
            else if (lifes == 1)
            {
                heartImagens[0].SetActive(true);
                heartImagens[1].SetActive(false);
                heartImagens[2].SetActive(false);
            }
            else
            {
                heartImagens[0].SetActive(false);
                heartImagens[1].SetActive(false);
                heartImagens[2].SetActive(false);
            }
        }
        else
        {
            if (lifes == 4)
            {
                heartImagens[0].SetActive(true);
                heartImagens[1].SetActive(true);
                heartImagens[2].SetActive(true);
                heartImagens[3].SetActive(true);
            }
            else if (lifes == 3)
            {
                heartImagens[0].SetActive(true);
                heartImagens[1].SetActive(true);
                heartImagens[2].SetActive(true);
                heartImagens[3].SetActive(false);
            }
            else if (lifes == 2)
            {
                heartImagens[0].SetActive(true);
                heartImagens[1].SetActive(true);
                heartImagens[2].SetActive(false);
                heartImagens[3].SetActive(false);
            }
            else if (lifes == 1)
            {
                heartImagens[0].SetActive(true);
                heartImagens[1].SetActive(false);
                heartImagens[2].SetActive(false);
                heartImagens[3].SetActive(false);
            }
            else
            {
                heartImagens[0].SetActive(false);
                heartImagens[1].SetActive(false);
                heartImagens[2].SetActive(false);
                heartImagens[3].SetActive(false);
            }
        }
        
    }

    public void VictoryCondition(Button aux)
    {
        correctBtns.Remove(aux);

        if(correctBtns.Count == nc.data[dataIndex].numberOfHint[hintAux] )
        {
            int number = nc.data[dataIndex].amountOfHintPertip[hintAux];
            for(int i=0;i<number;i++)
            {
                int x = Random.Range(0, wrongBtns.Count);
                wrongBtns[x].GetComponent<BtnController>().SetHint();
                wrongBtns.Remove(wrongBtns[x]);
            }


            if(hintAux > nc.data[dataIndex].numberOfHint.Length)
            {
                hintAux++;
            }

        }

        if(correctBtns.Count == 0)
        {
            StartCoroutine(Timer());
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1f);
        winPanel.SetActive(true);
    }

    public void HintAds()
    {
        hint = 1;
        hintText.text = hint.ToString();
    }

    public void LifeAds()
    {
        if(PlayerPrefs.GetInt("ExtraLifeSlot", 0) == 1)
        {
            lifes = 4;
            HeartImagensActiveController();
            losePanel.SetActive(false);
        }
        else
        {
            lifes = 3;
            HeartImagensActiveController();
            losePanel.SetActive(false);
        }
        
    }

    public void SetFlag()
    {
        if (!flagMarker)
        {
            flagMarker = true;
        }
        else
        {
            flagMarker = false;
        }
    }
    
    public void OpneSettings()
    {
        settingsPanel.SetActive(true);
    }


    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }
}
