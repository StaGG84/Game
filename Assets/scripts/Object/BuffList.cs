using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuffList : MonoBehaviour {


	public class Buff  {

		public  enum	ETargetTeam				{ENEMY,FRIEND, ALL};
		public  enum	EBuffType				{HP};


		public int 								index;
		public ObjectParam 						caster;
		public EBuffType						buffType;
		public float 							value;
		public float 							duration;
		public float 							durationTimer;
		public float 							actionTime;
		public float 							actionTimeTimer;
		public ETargetTeam						buffTargetTeam;
	}

	private ObjectParam 					Params;
	public  List<Buff>		buffList 		= new List<Buff>();


	private void AddBuffToBuffList (Buff newBuff){

		bool applyBuff = false;

		if ((newBuff.caster.GetTeam() == Params.GetTeam()) | (newBuff.buffTargetTeam == Buff.ETargetTeam.FRIEND)) {
			applyBuff = true;
		}

		if ((newBuff.caster.GetTeam() != Params.GetTeam()) | (newBuff.buffTargetTeam == Buff.ETargetTeam.ENEMY)) {
			applyBuff = true;
		}

		if ((newBuff.buffTargetTeam == Buff.ETargetTeam.ALL)) {
			applyBuff = true;
		}

		if (applyBuff) {
			buffList.Add (newBuff);
		}


	}

	public void AddBuff (ObjectParam caster, Buff.EBuffType buffType, Buff.ETargetTeam buffTargetTeam, float value, float duration, float actionTime) {

		Buff newBuff 				= new Buff();
		newBuff.caster 				= caster; 
		newBuff.buffType 			= buffType;
		newBuff.value 				= value;
		newBuff.duration 			= duration;
		newBuff.durationTimer 		= Time.time;
		newBuff.actionTime 			= actionTime;
		newBuff.actionTimeTimer 	= Time.time;
		newBuff.buffTargetTeam		= buffTargetTeam;

		AddBuffToBuffList(newBuff);
	}


	void BuffListApply (){

		for (int i=0;i<buffList.Count;i++ ){


			/*Buff.EBuffType.HP*/

			if (buffList[i].buffType == Buff.EBuffType.HP) {
				if ((Time.time - buffList[i].durationTimer) >= buffList[i].duration) {
					Params.AddCurrentHealth (buffList[i].value);
					buffList[i].actionTimeTimer = Time.time;
				}
			}





			if ((Time.time - buffList[i].durationTimer) >= buffList[i].duration) {
				buffList.RemoveAt (i);
			}

		}
	}

	// Use this for initialization
	void Start () {
		Params = this.GetComponent<ObjectParam>();
	}

	// Update is called once per frame
	void Update () {
		BuffListApply();
	}
}

