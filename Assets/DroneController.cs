using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour {


	Rigidbody rb;
	public float maxAngularVelocity = 10;
	public float angularDrag = 20;


	float minThrottle = 5;
	public float maxThrottle = 1000;
	float dItdT = 1000; //For keyboard input: how fast the input changes throttle value. Might be unecessary since props can change speed almost instantly

	public float torqueMultiplier = 15000;
	public float dIrdT = 1000; //For keyboard input: how fast the input changes a rotational value. Might be unecessary since using rigid body angular drag

	float throttle;
	float rollTorque;
	float pitchTorque;
	float yawTorque;

	//Values are -1, 0, 1: apply in negative direction, don't apply, apply in positive direction
	int rollAxisDirection;
	int pitchAxisDirection;
	int yawAxisDirection;
	int throttleDirection;

	// Start is called before the first frame update
	void Start() {
		rb = GetComponent<Rigidbody>();
		rb.maxAngularVelocity = maxAngularVelocity;
		rb.angularDrag = angularDrag;
	}

	void Throttle() {
		rb.AddForce(transform.up * throttle * Time.fixedDeltaTime);
	}

	void Rotate(Vector3 direction, float amount) {
		rb.AddTorque(direction * amount * Time.fixedDeltaTime * torqueMultiplier);
	}

	void Roll() {
		Rotate(-transform.forward, rollTorque);
	}

	void Pitch() {
		Rotate(transform.right, pitchTorque);
	}

	void Yaw() {
		Rotate(transform.up, yawTorque*2);
	}

	void ChangeThrottle(int multiplier, ref float curr) {

		//Don't change throttle if no button is pressed.
		curr = Mathf.Clamp(curr + multiplier * dItdT * Time.deltaTime, minThrottle, maxThrottle);
	}

	void ChangeRotationMagnitude(int axisMultiplier, ref float curr) {
		if (axisMultiplier == 0) {
			curr = 0;
		}

		curr = Mathf.Clamp(curr + axisMultiplier * dIrdT * Time.deltaTime, -1, 1);
	}

	void KeyboardInput() {

		if (Input.GetKey(KeyCode.LeftArrow)) {
			rollAxisDirection = -1;
		} else if (Input.GetKey(KeyCode.RightArrow)) {
			rollAxisDirection = 1;
		} else {
			rollAxisDirection = 0;
		}

		if (Input.GetKey(KeyCode.DownArrow)) {
			pitchAxisDirection = -1;
		} else if (Input.GetKey(KeyCode.UpArrow)) {
			pitchAxisDirection = 1;
		} else {
			pitchAxisDirection = 0;
		}

		if (Input.GetKey(KeyCode.A)) {
			yawAxisDirection = -1;
		} else if (Input.GetKey(KeyCode.D)) {
			yawAxisDirection = 1;
		} else {
			yawAxisDirection = 0;
		}

		if (Input.GetKey(KeyCode.S)) {
			throttleDirection = -1;
		} else if (Input.GetKey(KeyCode.W)) {
			throttleDirection = 1;
		} else {
			throttleDirection = 0;
		}
	}

	void ApplyInputs() {
		ChangeThrottle(throttleDirection, ref throttle);
		ChangeRotationMagnitude(rollAxisDirection, ref rollTorque);
		ChangeRotationMagnitude(pitchAxisDirection, ref pitchTorque);
		ChangeRotationMagnitude(yawAxisDirection, ref yawTorque);
	}

	// Update is called once per frame
	void Update() {
		KeyboardInput();
		ApplyInputs();
	}

	void FixedUpdate() {
		Throttle();
		Roll();
		Pitch();
		Yaw();
		Debug.Log("Throttle: " + throttle);
	}

}
