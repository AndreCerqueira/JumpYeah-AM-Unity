using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeVolume : MonoBehaviour
{
    int gameVolumeValue;
    int musicVolumeValue;

    [SerializeField] Text gameVolumeText;
    [SerializeField] Text musicVolumeText;

    void Start() 
    {
        Screen.orientation = ScreenOrientation.Portrait;
        getDefs();
        musicVolumeText.text = atualizarText(musicVolumeValue);
        gameVolumeText.text = atualizarText(gameVolumeValue);
    }

    public void maisGameVolume()
    {
        if (gameVolumeValue < 10) {
            gameVolumeValue ++;
            gameVolumeText.text = atualizarText(gameVolumeValue);
        }
    }

    public void menosGameVolume()
    {
        if (gameVolumeValue > 0) {
            gameVolumeValue --;
            gameVolumeText.text = atualizarText(gameVolumeValue);
        }
    }

    public void maisMusicVolume()
    {
        if (musicVolumeValue < 10) {
            musicVolumeValue ++;
            musicVolumeText.text = atualizarText(musicVolumeValue);
        }
    }

    public void menosMusicVolume()
    {
        if (musicVolumeValue > 0) {
            musicVolumeValue --;
            musicVolumeText.text = atualizarText(musicVolumeValue);
        }
    }

    void Update() {
        GetComponent<AudioSource>().volume = (musicVolumeValue / 100f);
    }

    private string atualizarText(int value) 
    {
        string result = "";

        if (value > 0)
            result = "|";

        for (int i = 1; i < value; i++) {
            result += "  |";
        }

        return result;
    }

    public void goBack() 
    {
        saveDefs();
        SceneManager.LoadScene("SampleScene");
    }

    void saveDefs() {
        PlayerPrefs.SetInt("volumeGame", gameVolumeValue);
        PlayerPrefs.SetInt("volumeMusic", musicVolumeValue);
    }

    void getDefs() {
        gameVolumeValue = (PlayerPrefs.HasKey("volumeGame")) ? PlayerPrefs.GetInt("volumeGame") : 10;
        musicVolumeValue = (PlayerPrefs.HasKey("volumeMusic")) ? PlayerPrefs.GetInt("volumeMusic") : 10;
    }

}
