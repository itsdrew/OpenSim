using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour {

	public static DroneController instance = null;

	private void Awake() {
		if (instance == null) {
			instance = this;
		} else {
			Destroy(this.gameObject);
		}
	}

	Rigidbody rb;
	public float maxAngularVelocity = 10;
	public float angularDrag = 20;


	public float maxThrottle = 1000;
	float throttleMultiplier = 3000;
	public float throttleInputValue;

	public float torqueMultiplier = 15000;
	public float dIrdT = 1000; //For keyboard input: how fast the input changes a rotational value. Might be unecessary since using rigid body angular drag

	public float throttle;
	public float rollTorque;
	public float pitchTorque;
	public float yawTorque;

	//Values are -1, 0, 1: apply in negative direction, don't apply, apply in positive direction
	public int rollAxisDirection;
	public int pitchAxisDirection;
	public int yawAxisDirection;
	public int throttleDirection;

	// Start is called before the first frame update
	void Start() {
		rb = GetComponent<Rigidbody>();
		rb.maxAngularVelocity = maxAngularVelocity;
		rb.angularDrag = angularDrag;
	}

	void Throttle() {
		rb.AddForce(transform.up * throttle * throttleMultiplier * Time.fixedDeltaTime);
	}

	void Rotate(Vector3 direction, float amount) {
		rb.AddTorque(direction * amount * Time.fixedDeltaTime * torqueMultiplier);
	}

	void Roll() {
		Rotate(-transform.forward, rollTorque*2.5f);
	}

	void Pitch() {
		Rotate(transform.right, pitchTorque*1.7f);
	}

	void Yaw() {
		Rotate(transform.up, yawTorque);
	}

	//void ChangeRotationMagnitude(int axisMultiplier, ref float curr) {
	//	curr = axisMultiplier == 0 ? 0 : Mathf.Clamp(curr + axisMultiplier * dIrdT * Time.deltaTime, -1, 1);
	//}


	public void Reset() {

 		rollTorque = pitchTorque = yawTorque = throttle = 0;
		rb.velocity = rb.angularVelocity = Vector3.zero;

		transform.rotation = Quaternion.identity;
		transform.position = Vector3.up;
	}

	//void ChangeThrottle() {
	//	throttle = maxThrottle * throttleInputValue * throttleMultiplier;
	//}

	//void ApplyInputs() {
	//	//ChangeThrottle();
	//	//ChangeRotationMagnitude(rollAxisDirection, ref rollTorque);
	//	//ChangeRotationMagnitude(pitchAxisDirection, ref pitchTorque);
	//	//ChangeRotationMagnitude(yawAxisDirection, ref yawTorque);
	//}

	// Update is called once per frame
	void Update() {
		//ApplyInputs();
		Debug.Log(throttle);
	}

	void FixedUpdate() {
		Throttle();
		Roll();
		Pitch();
		Yaw();
	}

}
