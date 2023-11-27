using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backpack : MonoBehaviour
{
    [SerializeField]
    private BackPackSO data;
    public bool axe;
    public bool rope;

    private void Start()
    {
        SetData();
    }

    private void SetData()
    {
        axe = data.axe;
        rope = data.rope;
    } 
}
