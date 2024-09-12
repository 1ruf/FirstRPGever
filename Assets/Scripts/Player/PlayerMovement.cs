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




    private bool wtfTesting;
    private void Awake()
    {
        plrAnim = GetComponentInChildren<PlayerAnimation>();
        plrInput = GetComponent<PlayerInput>();
        _rigid = GetComponent<Rigidbody2D>();
    }
    private void IsSameValue(float value)
    {
        if (value == beforeValue)
        {
            if (Mathf.Abs(_rigid.velocity.x) > 2.5f)
            {
                plrAnim.PlayAnim(PlayerAnimation.animationType.Walk);
            }
            else
            {
                //Idle
            }
        }
        else
        {
            beforeValue = value;
            //움직이고있는
        }
    }
    private void FixedUpdate()
    {
        IsSameValue(plrInput.plrDir.x);
        _rigid.velocity = (plrInput.plrDir.normalized * walkSpd) * plrInput.sprint;
    }
}
