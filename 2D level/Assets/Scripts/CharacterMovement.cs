using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Animator))]
public class CharacterMovement : MonoBehaviour
{
    //private const string RunningKnightAnimationName = "KnightIsRuning";
    //private const string JumpingKnightAnimationName = "KnightIsJumping";

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpPower;

    //private Animator _animator;

    //private void Awake()
    //{
    //    _animator = GetComponent<Animator>();
    //}

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-_speed * Time.deltaTime, 0, 0);
            //_animator.SetBool(RunningKnightAnimationName, true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);
            //_animator.SetBool(RunningKnightAnimationName, true);
        }
        //else
        //{
        //    _animator.SetBool(RunningKnightAnimationName, false);
        //}

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(0, _jumpPower, 0);
            //_animator.SetBool(JumpingKnightAnimationName, true);
        }
        //else
        //{
        //    _animator.SetBool(JumpingKnightAnimationName, false);
        //}
    }
}