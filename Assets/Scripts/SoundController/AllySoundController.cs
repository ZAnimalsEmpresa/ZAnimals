using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllySoundController : MonoBehaviour
{
    private FMOD.Studio.EventInstance footSteps;
    private FMOD.Studio.EventInstance dying;
    private FMOD.Studio.EventInstance attackWeapon;
    private FMOD.Studio.EventInstance attackMelee;
    private FMOD.Studio.EventInstance heal;
    private FMOD.Studio.EventInstance bomb;

    private void PlayFootSteps()
    {
        footSteps = FMODUnity.RuntimeManager.CreateInstance("event:/Character/Ally Walk");
        footSteps.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        footSteps.start();
        footSteps.release();
    }

    private void PlayDeath()
    {
        dying = FMODUnity.RuntimeManager.CreateInstance("event:/Character/Ally Dying");
        dying.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        dying.start();
        dying.release();
    }

    private void PlayAttackWaeapon()
    {
        attackWeapon = FMODUnity.RuntimeManager.CreateInstance("event:/Weapons/Machine Gun");
        attackWeapon.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        attackWeapon.start();
        attackWeapon.release();
    }

    private void PlayAttackMelee()
    {
        attackMelee = FMODUnity.RuntimeManager.CreateInstance("event:/Character/Ally Attack Melee");
        attackMelee.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        attackMelee.start();
        attackMelee.release();
    }

    private void PlayHeal()
    {
        heal = FMODUnity.RuntimeManager.CreateInstance("event:/Character/Ally Healer Heal");
        heal.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        heal.start();
        heal.release();
    }

    private void PlayBomb()
    {
        bomb = FMODUnity.RuntimeManager.CreateInstance("event:/Weapons/Explosion");
        bomb.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        bomb.start();
        bomb.release();
    }
}
