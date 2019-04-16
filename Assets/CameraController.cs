using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

	public Transform drone;
	public float distanceBehind = 10;
	public float distanceAbove = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		transform.position = new Vector3(
			drone.position.x,
			drone.position.y + distanceAbove,
			drone.position.z - distanceBehind
		);
    }
}
