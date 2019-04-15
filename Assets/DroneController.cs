using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour {

	Rigidbody rb;


	float maxAngularVelocity = 30;
	float dIdT = 100; //For keyboard input, di/dt, how fast the input changes the value


	float throttle;

	float rollTorque;
	float pitchTorque;
	float yawTorque;
	float torqueMultiplier = 1000;

	//Values are -1, 0, 1: apply in negative direction, don't apply, apply in positive direction
	int rollAxisMultiplier;
	int pitchAxisMultiplier;
	int yawAxisMultiplier;

	// Start is called before the first frame update
	void Start() {
		rb = GetComponent<Rigidbody>();
		rb.maxAngularVelocity = maxAngularVelocity;
	}

	void Throttle() {
		rb.AddForce(transform.up * throttle * Time.fixedDeltaTime);
	}

	void Roll() {
		rb.AddTorque(-transform.forward * rollTorque * Time.fixedDeltaTime * torqueMultiplier);
	}

	void Pitch() {
		rb.AddTorque(transform.right * pitchTorque * Time.fixedDeltaTime * torqueMultiplier);
	}

	void Yaw() {
		rb.AddTorque(transform.up * yawTorque * Time.fixedDeltaTime * torqueMultiplier);
	}

	float ChangeRotation(int axisMultiplier, float curr) {
		return Mathf.Clamp(axisMultiplier * (curr + dIdT * Time.deltaTime), -1, 1);
	}

	void KeyboardInput() {

		if (Input.GetKey(KeyCode.LeftArrow)) {
			rollAxisMultiplier = -1;
		} else if (Input.GetKey(KeyCode.RightArrow)) {
			rollAxisMultiplier = 1;
		} else {
			rollAxisMultiplier = 0;
		}

		if (Input.GetKey(KeyCode.DownArrow)) {
			pitchAxisMultiplier = -1;
		} else if (Input.GetKey(KeyCode.UpArrow)) {
			pitchAxisMultiplier = 1;
		} else {
			pitchAxisMultiplier = 0;
		}

		if (Input.GetKey(KeyCode.A)) {
			yawAxisMultiplier = -1;
		} else if (Input.GetKey(KeyCode.D)) {
			yawAxisMultiplier = 1;
		} else {
			yawAxisMultiplier = 0;
		}
	}

	void ApplyInputs() {
		rollTorque = ChangeRotation(rollAxisMultiplier, rollTorque);
		pitchTorque = ChangeRotation(pitchAxisMultiplier, pitchTorque);
		yawTorque = ChangeRotation(yawAxisMultiplier, yawTorque);
	}

	// Update is called once per frame
	void Update() {
		KeyboardInput();
		ApplyInputs();
	}

	void FixedUpdate() {
		Roll();
		Pitch();
		Yaw();
	}


}
