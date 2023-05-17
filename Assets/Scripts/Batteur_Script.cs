using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Netcode;


public class Batteur_Script : NetworkBehaviour
{
    [Header("Input")]

    [SerializeField]
    private PlayerInput InputSystem;

    [Header("Flipper Prefs")]

    [SerializeField]
    private float RotMax_Value = -45f;
    [SerializeField]
    private float Strengh = 1000f;
    [SerializeField]
    private float Damper = 1000f;

    private float Originalposition = 0;
    private HingeJoint Hinge;
    private JointSpring Spring;

    [SerializeField]
    private string _inputButtonName;
    


    void Start()
    {

        Hinge = GetComponent<HingeJoint>();
        Hinge.useSpring = true;
        Spring.spring = Strengh;
        Spring.damper = Damper;
    }
    void Update()
    {
        //if (!IsOwner)
        //    return;


        if (InputSystem.actions["Flipper"].IsPressed())
        {
            if (IsHost)
            {
                Spring.targetPosition = RotMax_Value;
            }
            else if (IsClient)
            { 
                Debug.Log("i'm the client !");
                Spring.targetPosition = -RotMax_Value;
            }
        }
        else
        {
            Spring.targetPosition = Originalposition;
        }

        Hinge.spring = Spring;
        Hinge.useLimits = true;
    }
}
