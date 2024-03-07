using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    FMOD.Studio.Bus Master;
    FMOD.Studio.Bus Music;
    FMOD.Studio.Bus SFX;

    [SerializeField] private float _masterVolume = 1;
    [SerializeField] private float _musicVolume = 0.3f;
    [SerializeField] private float _sfxVolume = 0.4f;

    private void Awake()
    {
        Master = FMODUnity.RuntimeManager.GetBus("bus:/");
        Music = FMODUnity.RuntimeManager.GetBus("bus:/Music");
        SFX = FMODUnity.RuntimeManager.GetBus("bus:/SFX");

        Master.setVolume(_masterVolume);
        Music.setVolume(_musicVolume);
        SFX.setVolume(_sfxVolume);        
    }
}
