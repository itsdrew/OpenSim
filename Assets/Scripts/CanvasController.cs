using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour {

	public static CanvasController instance = null;

	void Awake() {
		if (instance == null) {
			instance = this;
		} else {
			Destroy(this.gameObject);
		}
	}


	public Slider throttleSlider;
	public Slider yawSlider;


	// Start is called before the first frame update
	void Start() {
	
	}

	private void SetSliderValue(ref Slider slider, float val) {
		slider.value = val;
	}

	public void SetThrottleSlider(float val) {
		SetSliderValue(ref throttleSlider, val);
	}

	public void SetYawSlider(float val) {
		SetSliderValue(ref yawSlider, val);
	}


}
