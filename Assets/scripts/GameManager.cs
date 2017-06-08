using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public List<GameObject> ObjectList 		= new List<GameObject>();
	public List<GameObject> SpawnPoints 	= new List<GameObject>();

	public enum 			Teams				{TEAM1,TEAM2};


	// Use this for initialization
	void Start () {

		for(int i = 1; i <= 5; i++){
			SpawnPoints.Add ((GameObject)Resources.Load ("SpawnPoint"));
		}
		CreateSpawnPoint ();

	}

	public void CreatePlayer (GameObject Player) {
		ObjectList.Add(Player);
	}

	public void CreateEnemy ( GameObject Enemy) {
		ObjectList.Add(Enemy);
	}

	public void CreateSpawnPoint () {
		foreach (GameObject spawnPoint in SpawnPoints)
		{
			Instantiate (spawnPoint,new Vector3((float)Random.Range(1,20),transform.position.y, (float)Random.Range(1,20)),this.transform.rotation); 
		}
	}


	// Update is called once per frame
	void Update () {
	
	}
}
