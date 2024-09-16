using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float walkSpd;
    private PlayerAnimation plrAnim;
    private PlayerInput plrInput;
    private Rigidbody2D _rigid;

    private float beforeValue;




    private bool animChanging;
    private bool animPlaying;
    private void Awake()
    {
        plrAnim = GetComponentInChildren<PlayerAnimation>();
        plrInput = GetComponent<PlayerInput>();
        _rigid = GetComponent<Rigidbody2D>();
    }
    private void IsSameValue(float value)
    {
        animChanging = (value == beforeValue) ? false : true; //들어온값이 이전 저장값과 다르면 false 
        if (animChanging!) //들어온값이 이 전 저장된 값과 다르면
        {
            animPlaying = true;
            beforeValue = value;
        }
        if (animPlaying)
        {
            if (Mathf.Abs(value) > 3.5f)
            {
                print("run");
                plrAnim.PlayAnim(PlayerAnimation.animationType.Run);
            }
            else if (Mathf.Abs(value) > 2.5f)
            {
                print("walk");
                plrAnim.PlayAnim(PlayerAnimation.animationType.Walk);
            }
            else
            {
                plrAnim.PlayAnim(PlayerAnimation.animationType.Idle);
            }
            animPlaying = false;
        }
    }
    private void checkFlip()
    {
        if (_rigid.velocity.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (_rigid.velocity.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
    private void FixedUpdate()
    {
        checkFlip();
        _rigid.velocity = (plrInput.plrDir.normalized * walkSpd) * plrInput.sprint;
        IsSameValue(_rigid.velocity.x);
    }
}
