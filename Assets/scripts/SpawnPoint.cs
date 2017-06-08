using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {


	GameObject spawnObject;

	public int spawnCount = 0;

	public float spawnTimer = 0;
	public float spawnInterval = 1;

	private int currentSpawnCount = 0;


	// Use this for initialization
	void Start () {
		spawnObject = (GameObject)Resources.Load ("Enemy");
		spawnTimer = Time.time;
	}

	void SpawnObject (){
		if ((Time.time - spawnTimer) >= spawnInterval) {
			Instantiate (spawnObject, this.transform.position, this.transform.rotation);
			spawnTimer = Time.time;
			currentSpawnCount += 1;
		}
	}


	// Update is called once per frame
	void Update () {

		if (spawnCount > 0) {
			if (spawnCount > currentSpawnCount) {
				SpawnObject ();
			} else {
				this.enabled = false;
				Debug.Log ("Disable SpawnZone:" + this.name);
			}
		}
	}
}
