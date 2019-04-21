using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		
    }

	Vector2 leftStick;
	Vector2 rightStick;

    // Update is called once per frame
    void Update()
    {
		leftStick.x = Input.GetAxis("HorizLeft");
		leftStick.y = Input.GetAxis("VertLeft");
		rightStick.x = Input.GetAxis("HorizRight");
		rightStick.y = Input.GetAxis("VertRight");

		DroneController.instance.throttle = leftStick.y + 1;
		DroneController.instance.yawTorque = leftStick.x;

		DroneController.instance.pitchTorque = rightStick.y;
		DroneController.instance.rollTorque = rightStick.x;

		//Debug.Log("Left: " + leftStick + " --- Right: " + rightStick);

		
    }
}
