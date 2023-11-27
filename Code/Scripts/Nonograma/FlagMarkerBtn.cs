using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagMarkerBtn : MonoBehaviour
{
    [SerializeField]
    private GameObject on, off;
    // Start is called before the first frame update
    void Start()
    {
        if (NonogramSceneManager.instance.flagMarker)
        {
            on.SetActive(true);
            off.SetActive(false);

        }
        else
        {
            on.SetActive(false);
            off.SetActive(true);
        }
    }

    public void SetActive()
    {
        NonogramSceneManager.instance.SetFlag();
        if (NonogramSceneManager.instance.flagMarker)
        {
            on.SetActive(true);
            off.SetActive(false);

        }
        else
        {
            on.SetActive(false);
            off.SetActive(true);
        }
    }
}
