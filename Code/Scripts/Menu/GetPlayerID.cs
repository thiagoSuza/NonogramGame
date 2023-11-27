using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetPlayerID : MonoBehaviour
{
    [SerializeField]
    private Text id;


    private void OnEnable()
    {
        id.text = "PLAYER ID: " + PlayerPrefs.GetString("Pid", "Null");
    }
}
