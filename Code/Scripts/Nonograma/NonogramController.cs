using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NonogramController : MonoBehaviour
{
    
    public NonogramSO[] data;

    
    public Button[] btn;

    [SerializeField]
    private Text[] line;
    [SerializeField]
    private Text[] colun;

    public int dataIndex;
    [SerializeField]
    private Text stageName;
    [SerializeField]
    private Image img;

    private void Awake()
    {
        dataIndex = PlayerPrefs.GetInt("SelectedLevel", 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        SetTips();
        SetBtns();
        stageName.text = data[dataIndex].stageName;
        img.sprite = data[dataIndex].img;
    }



   

    public void SetTips()
    {
        for (int i = 0; i < 5; i++)
        {
            line[i].text = data[dataIndex].lineTip[i];
            colun[i].text = data[dataIndex].colunTip[i];
        }
    }

    public void SetBtns()
    {
        for (int i = 0; i < data[dataIndex].positions.Length; i++)
        {
            btn[data[dataIndex].positions[i]].GetComponent<BtnController>().isCorrect = true;
            ColorBlock cb = btn[data[dataIndex].positions[i]].colors;
            cb.disabledColor = data[dataIndex].color[i];
            btn[data[dataIndex].positions[i]].colors = cb;
        }
    }
}
