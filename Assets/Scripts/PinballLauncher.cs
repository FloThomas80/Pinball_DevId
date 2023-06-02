using UnityEngine;
using UnityEngine.InputSystem;


public class PinballLauncher : MonoBehaviour
{
    [Header("Inputs")]
    [SerializeField] 
    private PlayerInput _inputs;



    [Header("Power Settings")]
    [SerializeField]
    private float _powerMax = 100f;
    private float _power = 0f;
    private float _powerMin = 0f;

    [Header("Ball")]
    private Rigidbody _rb;
    private GameObject BallInLauncher = null;
    private bool BallReady = true;

    [Header("Launcher")]
    [SerializeField]
    private GameObject Launcher;
    [SerializeField]
    private GameObject _spring;

    private Vector3 _launcherOrigin;
    private Vector3 _launcherMaxPostion;

    private Vector3 _springOrigin;
    private Vector3 _springMaxPostion;

    private void Start()
    {
        _power = _powerMin;
        _launcherOrigin = Launcher.transform.position;
        _launcherMaxPostion = new (_launcherOrigin.x, _launcherOrigin.y, _launcherOrigin.z - 3);
        _springOrigin = _spring.transform.localScale;
        _springMaxPostion = new(_springOrigin.x, _springOrigin.y, _springOrigin.z + 0.7f);
    }

    private void FixedUpdate()
    {
        if (BallReady)
        {
            if (_inputs.actions["PinballLauncher"].IsPressed() && BallReady)
            {

                if (_power <= _powerMax)
                {
                    _power += 100 * Time.deltaTime;
                    Launcher.transform.position = Vector3.MoveTowards(_launcherOrigin, _launcherMaxPostion, _power/10);
                    _spring.transform.localScale = Vector3.Lerp(_springOrigin, _springMaxPostion, _power / 30);

                }
            }
            else if (_inputs.actions["PinballLauncher"].WasReleasedThisFrame())
            {
                //Debug.Log("To the moooon ! " + _rb);
                _rb.AddForce(-transform.forward * _power * 100f);
                Launcher.transform.position = Vector3.MoveTowards( _launcherMaxPostion, _launcherOrigin, 100);
                _spring.transform.localScale = Vector3.Lerp(_springMaxPostion, _springOrigin,  100);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        BallReady = true;
        BallInLauncher = other.gameObject;
        _rb = BallInLauncher.GetComponent<Rigidbody>();
    }
    private void OnTriggerExit(Collider other)
    {
        BallReady = false;
        _power = _powerMin;
        _rb = null;
    }
}

