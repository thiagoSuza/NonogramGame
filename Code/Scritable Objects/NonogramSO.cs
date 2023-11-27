using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nonogram 1", menuName = "ScriptableObjects/Nonogram")]
public class NonogramSO : ScriptableObject
{
    public string[] lineTip, colunTip;
    public Color[] color;
    public int[] positions;
    public int[] numberOfHint;
    public int[] amountOfHintPertip;
    public Sprite img;
    public string nonogramName;
    public string stageName;
   

    [Header("Salvamento")]
    public bool alredyWon =false;
    public int stars;
    

    
}