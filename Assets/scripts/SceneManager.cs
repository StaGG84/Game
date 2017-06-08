using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {

	GameObject goGameManager = new GameObject();


	// Use this for initialization
	void Avake () {
		goGameManager = GameObject.Find("GameManager");
		goGameManager.GetComponent<GameManager>().CreatePlayer (GameObject.Find("Player"));
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
