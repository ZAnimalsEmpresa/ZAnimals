using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class LevelMusicManager : MonoBehaviour
{
    //[SerializeField]
    //private EventReference musicEvent;

    /*public void PlayMusicEvent()
    {
        RuntimeManager.PlayOneShot(musicEvent);
    }*/

    private FMOD.Studio.EventInstance levelMusicEmitter;

    private FMOD.Studio.STOP_MODE STOP_MODE;

    private void Awake ()
    {
        levelMusicEmitter = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Demo Level");
        levelMusicEmitter.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
    }

    public void PlayMusicEvent()
    {                
        levelMusicEmitter.start();
        levelMusicEmitter.release();
    }

    public void StopMusicEvent()
    {
        levelMusicEmitter.stop(STOP_MODE);
    }
}
