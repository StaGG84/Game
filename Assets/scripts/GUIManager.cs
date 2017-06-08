using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class GUIManager : MonoBehaviour {

	private GameObject 					GameManager;
	public 	Image 						PlayerHeath;
	public 	Text  						PlayerTextHeath;
	public List<GUIObjectHealthBar> 	ObjectHealthList 	= new List<GUIObjectHealthBar>();
	public GUIObjectHealthBar 			ObjectHealthBar;
			
	public Texture	 			EnemyHeath;
	public Texture	 			EnemyHeathEmpty;

	public float playerMaxHealth;
	public float playerCurrentHealth;

	// Use this for initialization
	void Start () {
		GameManager = GameObject.Find("GameManager");
		UnityEngine.Cursor.visible = false;
		UnityEngine.Cursor.lockState = CursorLockMode.Locked;
	}


	public void DrawPlayerHealth (float playerCurrentHealth, float playerMaxHealth){
		PlayerHeath.fillAmount = (float) playerCurrentHealth / playerMaxHealth;
		PlayerTextHeath.text = ""+playerCurrentHealth;

	}

	public void AddObjectHealthBar (GameObject owner) {//float distance ,float playerCurrentHealth, float playerMaxHealth){

		Vector3 screenPos = Camera.main.WorldToScreenPoint(owner.transform.position);
		ObjectHealthBar = new GUIObjectHealthBar ();
		//ObjectHealthBar.AddGUIObjectHealthBar (owner);
		//ObjectHealthList.Add (AddObjectHealthBar);
		//GUI.DrawTexture(new Rect (screenPos.x - 25, Screen.height - screenPos.y-25, 50, 5), 	EnemyHeathEmpty, ScaleMode.ScaleToFit, true, 10.0f);
		//GUI.DrawTexture(new Rect (screenPos.x - 25, Screen.height - screenPos.y-25, 50, 5), 		EnemyHeath, ScaleMode.ScaleToFit, true, 10.0f);
	}

	public void AddObjectHealth ( GameObject Enemy) {
		//ObjectHealthList.Add(Enemy);
	}

	void OnGUI ()	{

	}

}
