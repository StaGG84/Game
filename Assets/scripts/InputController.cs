using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputController : MonoBehaviour {

	private ObjectParam             Params;
    private WeaponBase              Weapon;

	// Use this for initialization
	void Start () {
		Params = this.GetComponent<ObjectParam>();

	}
	
	// Update is called once per frame
	void Update () {
		//if(Input.GetKey(KeyCode.LeftShift))
			//Params.ActivateMoveSpeed();
		//else 
			//Params.ActivateRunSpeed();
		

		if(Input.GetKey(KeyCode.A))		//Params.Move (Vector3.left);
		if(Input.GetKey(KeyCode.D))		//Params.Move (Vector3.right);
		if(Input.GetKey(KeyCode.W))		//Params.Move (Vector3.forward);
		if(Input.GetKey(KeyCode.S))		//Params.Move (Vector3.back);

		//Params.Rotate (Vector3.up);

		//if(Input.GetMouseButtonDown (0))	Weapon.Attack (this.gameObject);

		if(Input.GetKey (KeyCode.Escape)) 	Application.Quit();
	}
}
