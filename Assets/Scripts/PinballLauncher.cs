using UnityEngine;
using UnityEngine.InputSystem;

public class PinballLauncher : MonoBehaviour
{
    [SerializeField] private PlayerInput _inputs;

    private Vector3 _origin;
    private Vector3 _tensionMax;
    private float _recoilLength = 1f;

    private float _power;
    //private float _powerTest = 5f;

    private Vector3 _currentPosition;


    private Rigidbody _rb;

    private bool _isLaunching;
    void Start()
    {
        _origin = transform.position;
        _rb = GetComponent<Rigidbody>();
        _rb.Sleep();
        _tensionMax.z = transform.position.z - _recoilLength;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isLaunching)
        {

            if (_inputs.actions["PinballLauncher"].IsPressed() && transform.position.z >= _tensionMax.z)
            {
                transform.Translate(-Vector3.up * Time.deltaTime);
                _currentPosition.z = transform.position.z;
                _power = _origin.z - _currentPosition.z;
            }
            else if (_inputs.actions["PinballLauncher"].WasReleasedThisFrame())
            {
                _isLaunching = true;
                _rb.AddForce(Vector3.forward * _power * 100, ForceMode.Impulse);
            }
        }
        else
        {
            if (transform.position.z < _origin.z)
            {
                transform.Translate(Vector3.up * Time.deltaTime);
            }
            else
            {
                _isLaunching = false;
                _rb.Sleep();
            }
        }
    }
}
