using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterAnimationController : MonoBehaviour
{
    private const string RunningKnightAnimationName = "KnightIsRuning";
    private const string JumpingKnightAnimationName = "KnightIsJumping"; 
    private const string KnightDied = "KnightDied";

    private Animator _animator;

    public void Run(bool status = false)
    {
        _animator.SetBool(RunningKnightAnimationName, status);
    }

    public void Jump(bool status = false)
    {
        _animator.SetBool(JumpingKnightAnimationName, status);
    }

    public void Death()
    {
        _animator.SetTrigger(KnightDied);
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
}
