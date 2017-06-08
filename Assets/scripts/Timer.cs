using UnityEngine;
using System.Collections;

public class Timer {

	private 	float 		interval;
	private 	float 		tmpTime			= 0;
	public 		bool 		action			= false;


	public void SetActionTime (float actionTime){
		this.interval = actionTime;
		action = true;
		tmpTime = 0;
	}

	// Update is called once per frame
	public bool Update () {

		if (action == true) {
			action = false;
		}

		tmpTime -= Time.deltaTime;
		if (tmpTime <= 0) {
			tmpTime = interval;
			action = true;
		}

		return action;
	}
}
