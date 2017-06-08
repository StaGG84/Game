using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIObjectHealthBar : MonoBehaviour {

	public GameObject				 GUIHealthBar;
	public GameObject				 Owner;
	public Vector3					 screenPos;
	public GameObject 				 resource;

	public void AddGUIObjectHealthBar (GameObject owner, Vector3 pos){
		this.GUIHealthBar = null;
		this.Owner = owner;
		this.screenPos = pos;
		this.GUIHealthBar.transform.position = pos;
	}

	public void SetPosition (Vector3 pos){
		this.transform.position = pos;
	
	}
	// Use this for initialization
	void Start () {
		resource = (GameObject)Resources.Load ("GUIObjectHealth");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
