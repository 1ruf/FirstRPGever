using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float sprintSpd;
    public float sprint { get; private set; }
    public Vector2 plrDir { get; private set; }

    private void Update()
    {
        GetKey();
        Sprint();
    }

    private void Sprint()
    {
        if (Input.GetAxisRaw("Sprint") == 0)
        {
            sprint = 1;
        }
        else
            sprint = sprintSpd;
    }

    private void GetKey()
    {
        float x = Input.GetAxisRaw("Horizontal");
        plrDir = new Vector2(x, 0);
    }
}
