using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;


public class Batteur_Script : MonoBehaviour
{

    [SerializeField]
    private float RotMax_Value = -45f;
    [SerializeField]
    private float Strengh = 1000f;
    [SerializeField]
    private float Damper = 1000f;

    private float Originalposition = 0;
    private HingeJoint Hinge;
    private JointSpring Spring;
 

    void Start()
    {
        
        Debug.Log("Started");
        Hinge = GetComponent<HingeJoint>();
        Hinge.useSpring = true;
        Spring.spring = Strengh;
        Spring.damper = Damper;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Spring.targetPosition = RotMax_Value;
        }
        else
        {
            Spring.targetPosition = Originalposition;
        }

        Hinge.spring = Spring;
        Hinge.useLimits = true;
    }
}
