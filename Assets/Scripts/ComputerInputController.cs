using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerInputController : MonoBehaviour {


	public DroneController droneController;

	public Vector2 mouseOrigin;

	// Start is called before the first frame update
	void Start() {

	}

	void KeyboardInput() {

		if (Input.GetKey(KeyCode.LeftArrow)) {	
			droneController.rollAxisDirection = -1;
		} else if (Input.GetKey(KeyCode.RightArrow)) {
			droneController.rollAxisDirection = 1;
		} else {	
			droneController.rollAxisDirection = 0;
		}

		if (Input.GetKey(KeyCode.DownArrow)) {
			droneController.pitchAxisDirection = -1;
		} else if (Input.GetKey(KeyCode.UpArrow)) {
			droneController.pitchAxisDirection = 1;
		} else {
			droneController.pitchAxisDirection = 0;
		}

		if (Input.GetKeyDown(KeyCode.Space)) {
			droneController.Reset();
		}
	}

	public void SetMouseOrigin() {
		mouseOrigin = MouseScreenPosition();
	}

	private Vector2 MouseScreenPosition() {
		return Camera.main.ScreenToViewportPoint(Input.mousePosition);
	}


	public void MouseInput() {
		//TODO
	}

	public void Update() {
		MouseInput();
		KeyboardInput();
	}
}
