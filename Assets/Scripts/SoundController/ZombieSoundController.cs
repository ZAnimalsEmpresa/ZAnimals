using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSoundController : MonoBehaviour
{
    private FMOD.Studio.EventInstance footSteps;
    private FMOD.Studio.EventInstance dying;
    //private FMOD.Studio.EventInstance attackWeapon;
    private FMOD.Studio.EventInstance attackMelee;
    private FMOD.Studio.EventInstance giraffeSpawn;

    private void PlayFootSteps()
    {
        footSteps = FMODUnity.RuntimeManager.CreateInstance("event:/Character/Zombie Walk");
        footSteps.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        footSteps.start();
        footSteps.release();
    }

    private void PlayDeath()
    {
        dying = FMODUnity.RuntimeManager.CreateInstance("event:/Character/Zombie Dying");
        dying.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        dying.start();
        dying.release();
    }

    /*
    private void PlayAttackWaeapon()
    {
        attackWeapon = FMODUnity.RuntimeManager.CreateInstance("event:/Weapons/Machine Gun");
        attackWeapon.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        attackWeapon.start();
        attackWeapon.release();
    }*/

    private void PlayAttackMelee()
    {
        attackMelee = FMODUnity.RuntimeManager.CreateInstance("event:/Character/Zombie Attack");
        attackMelee.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        attackMelee.start();
        attackMelee.release();
    }

    private void PlayGiraffeSpawn()
    {
        giraffeSpawn = FMODUnity.RuntimeManager.CreateInstance("event:/Character/Zombie Giraffe Spawn");
        giraffeSpawn.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        giraffeSpawn.start();
        giraffeSpawn.release();
    }
}
