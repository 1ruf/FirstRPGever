using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }
    public enum animationType
    {
        Idle,
        Walk,
        Run,
        Jump,
        Fall
    }
    public void PlayAnim(animationType animation)
    {
        switch (animation)
        {
            case animationType.Idle:
                Play("Idle");
                break;
            case animationType.Walk:
                Play("Walk");
                break;
            case animationType.Run:
                Play("Run");
                break;
            case animationType.Jump:
                Play("Jump");
                break;
            case animationType.Fall:
                Play("Fall");
                break;
        }
    }
    private void Play(string anim)
    {
        animator.Play(anim, -1, 0f);
    }
    void Update()
    {
        
    }
}
