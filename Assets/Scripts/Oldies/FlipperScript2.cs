using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlipperScript2 : MonoBehaviour
{
    private float _limitY = -120f;
    private float _originY;

    private Rigidbody _rb;

    [SerializeField] private PlayerInput _playerInput;
    private bool _isFlipping;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _originY = transform.localEulerAngles.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (!_isFlipping) { 
        if (_playerInput.actions["Flipper"].IsPressed() && transform.localEulerAngles.y >= _limitY)
        {
                _isFlipping = true;
            
                _rb.AddTorque(transform.up * -140f, ForceMode.Acceleration);
           
        }
        else if (_playerInput.actions["Flipper"].WasReleasedThisFrame())
        {
                 
            //_rb.AddTorque(transform.up * _torqueForce, ForceMode.Force);
        }
            else
            {
                if(transform.localEulerAngles.y < _originY)
                {
                    transform.Translate(Vector3.forward * Time.deltaTime);
                }
                else
                {
                    _isFlipping = false;
                    _rb.Sleep();
                }
            }

        }

    }
}
