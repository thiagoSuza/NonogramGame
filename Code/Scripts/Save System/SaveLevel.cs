using UnityEngine;

using System.Collections;

public class LevelDataController : MonoBehaviour
{
    public NonogramController nc;

    private void OnEnable()
    {
        nc.data[nc.dataIndex].alredyWon = true;
        nc.data[nc.dataIndex].stars = NonogramSceneManager.instance.stars;
    }

}