using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public 	ObjectParam 		Params;
	delegate 	void 			D_DrawEnemyHealth 			(float d, float i, float j);
	D_DrawEnemyHealth 			DrawEnemyCurrentHealth;

	public enum 			States					{IDLE,MOVE,ATTACK};
	public States			state 					= States.IDLE;

	// Use this for initialization
	void Start () {

		Params = this.GetComponent<ObjectParam> ();

		state = States.IDLE;
		Params.SetCurrentHealth(Params.GetMaxHealth());
		Params.SetRunSpeed(Params.GetMoveSpeed()*2f);
		Params.ActivateMoveSpeed ();
		Params.SetAttackTimer(Time.time);
		Params.SetWeapon((GameObject)Resources.Load("Weapon"));
		Params.SetAttackSpeed(Params.GetWeapon().GetComponent<Weapon> ().GetAttackSpeed ());
		Params.SetTeam(GameManager.Teams.TEAM2);


		//DrawEnemyCurrentHealth = new D_DrawEnemyHealth(GameObject.Find("GUIManager").GetComponent<GUIManager>().DrawEnemyHealth);
		UpdateEnemyHealth ();

	}

	void CheckState () {
		if (!Params.GetTarget()) {
			state = States.IDLE;
		} else {
			Debug.DrawLine (this.transform.position, Params.GetTarget().transform.position, Color.yellow);
		}
			

		if (Params.GetTarget()) {
			if ((Vector3.Distance (this.transform.position, Params.GetTarget().transform.position) > 2)) {
				state = States.MOVE;
			} else {
				state = States.ATTACK;
			}
		}
		switch (state)
		{
		case States.IDLE:
			break;
		case States.MOVE:
			Params.LookAtTarget ();
			Params.Move (Vector3.forward);
			break;
		case States.ATTACK:
			Params.LookAtTarget ();
			Params.Attack ();
			break;
		default:
			break;
		}
	}

	void UpdateEnemyHealth(){

		DrawEnemyCurrentHealth(Mathf.Abs(Vector3.Distance (Camera.main.transform.position,this.transform.position)),Params.GetCurrentHealth(),Params.GetMaxHealth());
	}




	void Update () {
		CheckState ();
		UpdateEnemyHealth ();
	}





}
