using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;

public class SavePlayerPosition : MonoBehaviour
{
    private string playerPositionKey = "PlayerPosition";
    public static SavePlayerPosition instance;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        LoadPlayerPosition();
    }

   

   public void SavePlayerPositionS()
    {
        
        Vector3 playerPosition = transform.position;


        string playerPositionString = playerPosition.x.ToString(CultureInfo.InvariantCulture) + "," +
                                      playerPosition.y.ToString(CultureInfo.InvariantCulture) + "," +
                                      playerPosition.z.ToString(CultureInfo.InvariantCulture);

        PlayerPrefs.SetString(playerPositionKey, playerPositionString);

       
        PlayerPrefs.Save();

        
    }

    void LoadPlayerPosition()
    {
        // Verifica se h� uma posi��o do jogador salva
        if (PlayerPrefs.HasKey(playerPositionKey))
        {
            // Obt�m a string da posi��o salva
            string playerPositionString = PlayerPrefs.GetString(playerPositionKey);

            // Divide a string para obter as coordenadas x, y e z
            string[] positionArray = playerPositionString.Split(',');

            // Tenta converter as coordenadas de volta para floats
            float x, y, z;
            if (float.TryParse(positionArray[0], NumberStyles.Float, CultureInfo.InvariantCulture, out x) &&
                float.TryParse(positionArray[1], NumberStyles.Float, CultureInfo.InvariantCulture, out y) &&
                float.TryParse(positionArray[2], NumberStyles.Float, CultureInfo.InvariantCulture, out z))
            {
                // Define a posi��o do jogador para a posi��o salva
                transform.position = new Vector3(x, y, 0);

                
            }
            else
            {
                
            }
        }
        else
        {
            
        }

    }

    private void OnApplicationQuit()
    {
        SavePlayerPositionS();
    }
}
