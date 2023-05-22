using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Netcode;


public class Flippers_Script : NetworkBehaviour
{
    
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private float _speed = 500.0f;
    [SerializeField] private float _returnSpeed = 5.0f;
    [SerializeField] private float rotation;
    [SerializeField] private int flipperId;
    private Quaternion _initialRotation;
    private Quaternion _targetRotation;

    void Start()
    {
        _initialRotation = transform.rotation;
        _targetRotation = _initialRotation;

        Debug.Log(transform.rotation.z);
        Debug.Log(transform.localEulerAngles);
        Debug.Log(transform.localRotation);
        Debug.Log(transform.eulerAngles);
        Debug.Log(transform.rotation.eulerAngles);
        Debug.Log(transform.rotation.normalized);
        Debug.Log(transform.rotation.ToEuler());
        Debug.Log(transform.rotation.ToEulerAngles());
    }

    void FixedUpdate()
    {
        if (_playerInput.actions["Flipper"].IsPressed())

                _targetRotation = Quaternion.Euler(270, rotation, 0);

        else if (_playerInput.actions["Flipper"].WasReleasedThisFrame())
        {
            _targetRotation = _initialRotation;
        }

            transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetRotation, _speed * Time.deltaTime);

    }
    
}
//    [Header("Input")]
//    private float time = 0;
//    [SerializeField]
//    private PlayerInput InputSystem;

//    [Header("Flipper Prefs")]
//    [SerializeField]
//    private AnimationCurve FlippersAnim;
//    [SerializeField]
//    private float RotMax_Value = -45f;
//    [SerializeField]
//    private float _speed = 0.1f;

//    [SerializeField]
//    private string _inputButtonName;



//    void Start()
//    {
//        FlippersAnim = new AnimationCurve();
//        //FlippersAnim.ClearKeys();

//        float minAnimValue = transform.localEulerAngles.z;

//        Debug.Log("local euler : " + transform.localRotation.eulerAngles);

//        float maxAnimValue = transform.localEulerAngles.z + RotMax_Value;

//        FlippersAnim.AddKey(0, minAnimValue);
//        FlippersAnim.AddKey(1, (maxAnimValue));

//        Debug.Log("my first key is : " + FlippersAnim.Evaluate(0));
//        Debug.Log("my last key is : " + FlippersAnim.Evaluate(1));
//    }
//    void Update()
//    {
//        if (InputSystem.actions["Flipper"].IsPressed())
//        {
//            if (time < 1)
//            {
//                time += _speed * Time.deltaTime;

//                transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, FlippersAnim.Evaluate(time));
//            }
//            else
//                time = 1;
//        }
//    }
//}
