using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	private float 			damage 			= -10f;
	private float 			actionTime 		= 0.5f;
	private float 			cooldown	 	= 0.5f;

	private ObjectParam 			Params;

	// Use this for initialization
	void Start () {
		transform.localPosition=Vector3.forward*1.05f;
		Params = this.GetComponentInParent<ObjectParam>();
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.GetComponent<BuffList>()){
			other.gameObject.GetComponent<BuffList>().AddBuff(Params,BuffList.Buff.EBuffType.HP, BuffList.Buff.ETargetTeam.ENEMY,damage,0,0);
		}
		Destroy (gameObject);

	}

	// Update is called once per frame
	void FixedUpdate () {
		Destroy (gameObject);
	}

	public float GetAttackSpeed (){
		return (actionTime + cooldown);
	}

}
