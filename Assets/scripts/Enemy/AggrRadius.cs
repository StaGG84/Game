using UnityEngine;
using System.Collections;

public class AggrRadius : MonoBehaviour {



	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			this.gameObject.transform.parent.gameObject.GetComponent<ObjectParam> ().SetTarget (other.gameObject);
		}
	}

}
