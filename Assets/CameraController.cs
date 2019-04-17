using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public enum CameraType {
		ThirdPerson,
		FPV,
		Bystander
	}

	private bool cameraTypeChanged = true;
	private Vector3 cameraStartPosition;
	private CameraType currentCameraType;

	public Transform drone;

	public CameraType cameraType = CameraType.Bystander;

	[Header("Third person settings")]
	public float distanceBehind = 10;
	public float distanceAbove = 1;

	// Start is called before the first frame update
	void Start() {
		cameraStartPosition = transform.position;
		currentCameraType = cameraType;
	}

	// Update is called once per frame
	void Update() {
		if (cameraTypeChanged) {
			if (cameraType == CameraType.ThirdPerson) {
				transform.SetParent(drone);
				transform.localRotation = Quaternion.identity;
				transform.localPosition = new Vector3(0, distanceAbove, -distanceBehind);
			} else if (cameraType == CameraType.FPV) {
				//TODO
			} else {
				transform.SetParent(null);
				transform.rotation = Quaternion.identity;
				transform.position = cameraStartPosition;
			}
			currentCameraType = cameraType;
		}

		if (currentCameraType == CameraType.Bystander) {
			transform.LookAt(drone, Vector3.up);
		}

		if (currentCameraType!=cameraType) {
			cameraTypeChanged = true;
		}
		
	}
}
