
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class OptionsPanel : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;

    [SerializeField] private GameObject imgMusicOn, imgMusicOff;
    [SerializeField] private GameObject imgSfxOn, imgSfxOff;

    private bool musicOn, sfxOn;
    // Start is called before the first frame update
    void Start()
    {
        SetLoadData();
        
    }


    public void SetLoadData()
    {
        if (PlayerPrefs.GetInt("MUSIC", 0) == 0)
        {
            musicOn = true;
            mixer.SetFloat("music", 0);
            imgMusicOn.SetActive(true);
            imgMusicOff.SetActive(false);
        }
        else
        {
            musicOn = false;
            mixer.SetFloat("music", -80);
            imgMusicOn.SetActive(false);
            imgMusicOff.SetActive(true);
        }

        if (PlayerPrefs.GetInt("SFX", 0) == 0)
        {
            sfxOn = true;
            mixer.SetFloat("sfx", 0);
            imgSfxOn.SetActive(true);
            imgSfxOff.SetActive(false);
        }
        else
        {
            sfxOn = false;
            mixer.SetFloat("sfx", -80);
            imgSfxOn.SetActive(false);
            imgSfxOff.SetActive(true);
        }
    }

    public void SetMusicOn()
    {
        if(!musicOn)
        {
            mixer.SetFloat("music", 0);
            imgMusicOn.SetActive(true);
            imgMusicOff.SetActive(false);
            musicOn = true;
            PlayerPrefs.SetInt("MUSIC", 0);
        }
        else
        {
            mixer.SetFloat("music", -80);
            imgMusicOn.SetActive(false);
            imgMusicOff.SetActive(true);
            musicOn = false;
            PlayerPrefs.SetInt("MUSIC", 1);
        }
       
    }


    public void SetSFXOn()
    {
        if (!sfxOn)
        {
            mixer.SetFloat("sfx", 0);
            imgSfxOn.SetActive(true);
            imgSfxOff.SetActive(false);
            sfxOn = true;
            PlayerPrefs.SetInt("SFX", 0);
        }
        else
        {
            mixer.SetFloat("sfx", -80);
            imgSfxOn.SetActive(false);
            imgSfxOff.SetActive(true);
            sfxOn = false;
            PlayerPrefs.SetInt("SFX", 1);

        }
    }

    public void ResetLevel()
    {
        Scene scene = SceneManager.GetActiveScene();        
        SceneManager.LoadScene(scene.name);
    }

    public void ReturToMenu()
    {
        SceneManager.LoadScene("MapScene");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
