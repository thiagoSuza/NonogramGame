using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeObstacle : MonoBehaviour
{
    public GameObject panel;

    private void Awake()
    {
        if(PlayerPrefs.GetInt("AxeObstacle",0) == 1)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(collision.gameObject.GetComponent<Backpack>().axe == true)
            {
                PlayerPrefs.SetInt("AxeObstacle", 1);
                Destroy(gameObject);
            }
            else
            {
                panel.SetActive(true);

            }
        }
    }




    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
                panel.SetActive(false);

            
        }
    }
}
