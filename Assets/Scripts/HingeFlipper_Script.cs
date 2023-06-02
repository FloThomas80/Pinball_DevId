using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class HingeFlipper_Script : MonoBehaviour
{
    [Header("Inputs")]
    [SerializeField]
    private InputAction InputAction;
    //[SerializeField]
    //private GameObject LeftFlipper;
    //[SerializeField]
    //private GameObject RightFlipper;

    [Header("Flipper positions")]
    [SerializeField]
    private float _originalPosition = 0;
    [SerializeField]
    private float _maxPosition = -45f;
    [Header("Flipper forces")]
    [SerializeField]
    private float _hitForce = 10000f;
    [SerializeField]
    private float _damper = 1000f;

    [Header("MyKey")]
    [SerializeField]
    private KeyCode _keycode;

    //[SerializeField]
    //private string _flipperName;


    private HingeJoint Hinge;




    void Start()
    {

        Debug.Log("Started");
        Hinge = GetComponent<HingeJoint>();
        Hinge.useSpring = true;

    }
    void FixedUpdate()
    {
         JointSpring Spring = new JointSpring();
        Spring.spring = _hitForce;
        Spring.damper = _damper;

        if (Input.GetKey(_keycode))
        {

        //Debug.Log(_flipperName);
            Spring.targetPosition = _maxPosition;
        }
        else
        {
            Spring.targetPosition = _originalPosition;
        }

        Hinge.spring = Spring;
        Hinge.useLimits = true;
    }
}
