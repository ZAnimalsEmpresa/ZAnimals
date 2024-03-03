using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAnimations
{
    private Animator _animator;

    public UnitAnimations(Animator animator)
    {
        _animator = animator;
    }

    public void PlayAnimation(string nameStratey)
    {
        switch (nameStratey)
        {
            case "AttackStrategy":
                _animator.SetBool("Walk", false);
                _animator.SetBool("Attack", true);
                break;

            case "MoveStrategy":
                _animator.SetBool("Attack", false);
                _animator.SetBool("Walk", true);
                break;

            /*case "SpawnStrategy":
                if (_animator.GetParameter(1).name == "Spawn")
                {
                    _animator.SetBool("Spawn", true);
                }                    
                break;*/

            default:
                break;
        }
    }
}
