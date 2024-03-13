using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsVolumeManager : MonoBehaviour
{
    FMOD.Studio.Bus Master;
    FMOD.Studio.Bus Music;
    FMOD.Studio.Bus SFX;

    [SerializeField] Slider masterSlider;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;

    private void Awake()
    {
        Master = FMODUnity.RuntimeManager.GetBus("bus:/");
        Music = FMODUnity.RuntimeManager.GetBus("bus:/Music");
        SFX = FMODUnity.RuntimeManager.GetBus("bus:/SFX");

        LoadVolume();
    }

    public void ChangeVolume()
    {
        Master.setVolume(masterSlider.value);
        Music.setVolume(musicSlider.value);
        SFX.setVolume(sfxSlider.value);
        //SaveVolume();
    }
    
    private void LoadVolume()
    {
        masterSlider.value = 1;
        musicSlider.value = 0.5f;
        sfxSlider.value = 0.4f;

        /*if (!PlayerPrefs.HasKey("MasterVolume"))
        {
            PlayerPrefs.SetFloat("MasterVolume", 1);
        }
        else if (!PlayerPrefs.HasKey("MusicVolume"))
        {
            PlayerPrefs.SetFloat("MusicVolume", 1);
        }
        else if (!PlayerPrefs.HasKey("SFXVolume"))
        {
            PlayerPrefs.SetFloat("SFXVolume", 1);
        }*/

        /*Debug.Log("entra load");
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        Debug.Log("master volume Pprefs " + PlayerPrefs.GetFloat("MasterVolume"));
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        Debug.Log("music volume Pprefs " + PlayerPrefs.GetFloat("MusicVolume"));
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        Debug.Log("sfx volume Pprefs " + PlayerPrefs.GetFloat("SFXVolume"));*/
    }

    /*
    private void SaveVolume()
    {
        Debug.Log("entra save");

        PlayerPrefs.SetFloat("MasterVolume", masterSlider.value);
        Debug.Log("master slide value "+ masterSlider.value);
        PlayerPrefs.Save();

        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
        Debug.Log("music slide value " + musicSlider.value);
        PlayerPrefs.Save();

        PlayerPrefs.SetFloat("SFXVolume", sfxSlider.value);
        Debug.Log("sfx slide value " + sfxSlider.value);
        PlayerPrefs.Save();
    }*/
}
