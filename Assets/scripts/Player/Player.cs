using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private 	ObjectParam 	Params;
	private 	float 			oldPlayerCurrentHealth;
	delegate 	void 			D_DrawPlayerHealth 			(float i, float j);
	D_DrawPlayerHealth 			DrawPlayerCurrentHealth;

	// Use this for initialization
	void Start () {
		Params = this.GetComponent<ObjectParam>();
		oldPlayerCurrentHealth = Params.GetCurrentHealth();
		Params.SetTeam(GameManager.Teams.TEAM1);
		DrawPlayerCurrentHealth = new D_DrawPlayerHealth(GameObject.Find("GUIManager").GetComponent<GUIManager>().DrawPlayerHealth);
		UpdatePlayerHealth ();
	}

	void UpdatePlayerHealth(){

		DrawPlayerCurrentHealth(Params.GetCurrentHealth(),Params.GetMaxHealth());
	}



	// Update is called once per frame
	void Update () {

		if(Params.GetCurrentHealth()!=oldPlayerCurrentHealth){
			UpdatePlayerHealth ();
			oldPlayerCurrentHealth = Params.GetCurrentHealth();
		} 

	}
}
