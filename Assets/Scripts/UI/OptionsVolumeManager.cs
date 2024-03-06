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
        masterSlider.value = 1;
        musicSlider.value = 0.3f;
        sfxSlider.value = 0.4f;
    }

    public void ChangeVolume()
    {
        Master.setVolume(masterSlider.value);
        Music.setVolume(musicSlider.value);
        SFX.setVolume(sfxSlider.value);
        //Save();
    }

    /*
    private void Start()
    {
        if (!PlayerPrefs.HasKey("MasterVolume") || !PlayerPrefs.HasKey("MusicVolume") || !PlayerPrefs.HasKey("SFXVolume"))
        {
            PlayerPrefs.SetFloat("MasterVolume",1);
            PlayerPrefs.SetFloat("MusicVolume", 1);
            PlayerPrefs.SetFloat("SFXVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }*/

    /*
    private void Load()
    {
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("MasterVolume", masterSlider.value);
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", sfxSlider.value);
    }*/
}
