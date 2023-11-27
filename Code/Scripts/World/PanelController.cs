using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    [SerializeField]
    private GameObject storePanel,optionsPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OpenStore()
    {
        storePanel.SetActive(true);
    }
    public void CloseStore()
    {
        storePanel.SetActive(false);
    }

    public void OpenOptionsPanel()
    {
        optionsPanel.SetActive(true);
    }

    public void CloseptionsPanel()
    {
        optionsPanel.SetActive(false);
    }


}

