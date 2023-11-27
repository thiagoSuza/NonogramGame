using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;

public class IAPManager : MonoBehaviour
{
    [SerializeField]
    private string noAds, extraLife;
    public void OnPurchaseComplete(Product product)
    {
        if(product.definition.id == noAds)
        {
            PlayerPrefs.SetInt("NoADS2", 1);
            Debug.Log("NoAds");
          
        }

        if (product.definition.id == extraLife)
        {
            PlayerPrefs.SetInt("ExtraLifeSlot", 1);
            Debug.Log("ExtraLifeSlot");
            
          
        }
    }

    public void OnPurchaseFailed(Product product,PurchaseFailureDescription failure)
    {
        Debug.Log("Failure");
    }
    
}
