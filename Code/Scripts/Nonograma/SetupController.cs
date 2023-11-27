using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetupController : MonoBehaviour
{

    public void Exit()
    {
        SceneManager.LoadScene("MapScene");
    }
}
