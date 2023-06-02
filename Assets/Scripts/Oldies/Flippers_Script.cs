using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Netcode;


public class Flippers_Script : NetworkBehaviour
{

    [Header("Setup")]
    [SerializeField]
    private float rotationForce = 100f;
    [SerializeField]
    private float rotationThreshold = 90f;
    [SerializeField]
    private GameObject LeftFlip;
    [SerializeField]
    private GameObject RightFlip;

    private bool rotateObject = false;
    private Quaternion initialRotation;
    private Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialRotation = rb.rotation; //recupere sa position originale
    }

    private void Update()
    {
        //if (IsHost)
        //{
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rotateObject = true;
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                rotateObject = false;
                rb.angularVelocity = Vector3.zero; // plus de vitesse
                rb.rotation = initialRotation; //retour a la position originale
            }
        //}
    }

    private void FixedUpdate()
    {
        //if (IsHost)
        //{
            rb = LeftFlip.GetComponent<Rigidbody>();

            if (rotateObject)
            {
                rb.AddTorque(Vector3.up * rotationForce); //si la touche est pressée et donc le bool true alors : on add torque 

                // Check if rotation threshold is reached
                if (Quaternion.Angle(rb.rotation, initialRotation) >= rotationThreshold) //si l'angle maximum est atteinte alors on stop la vitesse
                {
                    rotateObject = false;
                    rb.angularVelocity = Vector3.zero;
                }
            }
        //}
    }
}
    
    //[SerializeField] private PlayerInput _playerInput;
    //[SerializeField] private float _speed = 500.0f;
    ////[SerializeField] private float _returnSpeed = 5.0f;
    //[SerializeField] private float _rotation;
    //[SerializeField] private float _torqueForce;
    //private Quaternion _initialRotation;
    //private Quaternion _targetRotation;
    //private Rigidbody _rb;
    //private bool firstPassage = true;

    //void Start()
    //{
    //    _initialRotation = transform.rotation;
    //    _targetRotation = _initialRotation;
    //    _rb = GetComponent<Rigidbody>();
    //    _rb.mass = 1000f;
    //}

    //void FixedUpdate()
    //{


    //    if (_playerInput.actions["Flipper"].IsPressed())
    //    {
    //        if(firstPassage)
    //        { 
    //        _rb.AddTorque(transform.up * _torqueForce, ForceMode.Acceleration);
    //        }
    //    }
    //    else if (_playerInput.actions["Flipper"].WasReleasedThisFrame())
    //    {
    //        //_rb.constraints = RigidbodyConstraints.None;
    //        //_rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

    //        //_rb.AddTorque(transform.up * _torqueForce, ForceMode.Force);
    //        firstPassage = false;
    //        transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetRotation, _speed * Time.deltaTime);
    //    }

    //    //transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetRotation, _speed * Time.deltaTime);
    //}

    //private void OnTriggerEnter(Collider blocks)
    //{
    //    if (blocks.gameObject.layer == LayerMask.NameToLayer("Blocks"))
    //    {
    //        Debug.Log("i'm in dude !");
    //        firstPassage = false;
    //        _rb.angularVelocity = Vector3.zero;
    //    }
    //    }
    ////private void OnTriggerExit()
    ////{
    ////    Debug.Log("i'm out moth#{@^é'+er !");
    ////    firstPassage = true;
    ////    _rb.constraints = RigidbodyConstraints.FreezeAll;
        
    ////}


//    [Header("Input")]
