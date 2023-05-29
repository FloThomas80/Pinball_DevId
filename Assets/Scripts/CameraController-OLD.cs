using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool inCombat;
    public Transform Player;
    public float transitionSpeed;
    public AnimationCurve modificatorX;

    [Header("----- Exploration")]
    public float CameraYExp = 5;
    public float CameraZExp = 7;
    public float AngleCamXExp = 30;

    [Space]
    [Header("----- Combats")]
    public float combatXDifference;
    public float CameraZCombat;
    float BaseXValue;
    public float combatDistance;
    [Header("Animation Curve")]
    public AnimationCurve modificatorY;
    public AnimationCurve modificatorZ;
    public AnimationCurve angleCamX;


    Vector3 currentPosition;
    Vector3 newPosition;
    Vector3 currentAngle;
    Vector3 newAngle;


    //[Header("-----------Shaking")]
    private float shakingPower = 0;


    private void Awake()
    {
        if (Player == null) Player = GameObject.FindGameObjectWithTag("Player").transform;
        //Player.GetComponent<PlayerController>().CamController = this;

        BaseXValue = Player.transform.position.x;

        //Pour les phases d exploration
        CameraZCombat = this.transform.position.z;

    }

    public void CameraStop(bool Combat)
    {
        inCombat = Combat;
        if (Combat)
        {
            combatXDifference = Player.transform.position.x - BaseXValue;
            combatDistance = Player.transform.position.x;
        }
        else
        {
            // Reset angle 
            newAngle = new Vector3(AngleCamXExp, currentAngle.y, currentAngle.z);
            transform.eulerAngles = Vector3.Lerp(currentAngle, newAngle, transitionSpeed);
        }
    }
    // Update is called once per frame
    void Update()
    {
        currentPosition = transform.position;
        currentAngle = transform.eulerAngles;

        if (inCombat)
        {
            Vector3 PositionTempo = new Vector3(Player.transform.position.x - combatXDifference, Player.transform.position.y, Player.transform.position.z);
            // newPosition = new Vector3(modificatorX.Evaluate(Player.position.x), modificatorY.Evaluate(PositionTempo.z), modificatorZ.Evaluate(PositionTempo.z)+ combatDistance - CameraZGap);
            newPosition = new Vector3(modificatorX.Evaluate(Player.position.x) + combatDistance, modificatorY.Evaluate(PositionTempo.z), modificatorZ.Evaluate(PositionTempo.z) + CameraZCombat);

            transform.position = Vector3.Lerp(currentPosition, newPosition, transitionSpeed);

            newAngle = new Vector3(angleCamX.Evaluate(PositionTempo.z), currentAngle.y, currentAngle.z);
            transform.eulerAngles = Vector3.Lerp(currentAngle, newAngle, transitionSpeed);
        }
        else
        {
            /*  Vector3 PositionTempo = new Vector3(Player.transform.position.x - combatXDifference, Player.transform.position.y, Player.transform.position.z);
              // newPosition = new Vector3(modificatorX.Evaluate(Player.position.x), modificatorY.Evaluate(PositionTempo.z), modificatorZ.Evaluate(PositionTempo.z)+ combatDistance - CameraZGap);
              newPosition = new Vector3(Player.position.x, modificatorY.Evaluate(PositionTempo.z), modificatorZ.Evaluate(PositionTempo.z) + CameraZCombat);

              transform.position = Vector3.Lerp(currentPosition, newPosition, transitionSpeed);

              newAngle = new Vector3(angleCamX.Evaluate(PositionTempo.z), currentAngle.y, currentAngle.z);
              transform.eulerAngles = Vector3.Lerp(currentAngle, newAngle, transitionSpeed);
            */



            newPosition = new Vector3(modificatorX.Evaluate(Player.position.x), CameraYExp, Player.position.z - CameraZExp);
            newPosition = new Vector3(Player.position.x, CameraYExp, Player.position.z - CameraZExp);
            transform.position = Vector3.Lerp(currentPosition, newPosition, transitionSpeed * 4);

            if (transform.eulerAngles.x != AngleCamXExp)
            {
                newAngle = new Vector3(AngleCamXExp, currentAngle.y, currentAngle.z);
                transform.eulerAngles = Vector3.Lerp(currentAngle, newAngle, transitionSpeed);
            }


        }
    }


    ////////////////////////////////////////Upgrade//
    public void CamShaking(float power, float lenght)
    {
        shakingPower = power;
        InvokeRepeating("StartShaking", 0, 0.1f);

        Invoke("EndShaking", lenght);

    }
    void StartShaking()
    {
        Vector3 CamPosition = this.transform.position;

        float MvmX = Random.value * shakingPower * 2 - shakingPower;
        float MvmY = Random.value * shakingPower * 2 - shakingPower;

        CamPosition.x += MvmX;
        CamPosition.y += MvmY;

        this.transform.position = new Vector3(CamPosition.x, CamPosition.y, this.transform.position.z);
    }
    void EndShaking()
    {
        CancelInvoke("StartShaking");
    }

}