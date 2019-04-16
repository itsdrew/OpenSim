using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropRotator : MonoBehaviour {

	public enum Direction {
		CLOCKWISE,
		COUNTERCLOCKWISE
	}

	public Direction direction;
	private int directionMultiplier;

	public float rpm = 1500;

	private Transform parent;

	// Start is called before the first frame update
	void Start() {
		if (direction == Direction.CLOCKWISE) {
			directionMultiplier = 1;
		} else {
			directionMultiplier = -1;
		}

		parent = transform.parent;
	}

	// Update is called once per frame
	void Update() {
		transform.RotateAround(transform.position, directionMultiplier * parent.up, rpm * Time.deltaTime);
	}

}
