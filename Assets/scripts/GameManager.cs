using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public List<GameObject> ObjectList 		= new List<GameObject>();
	public List<GameObject> SpawnPoints 	= new List<GameObject>();

    private GameObject SpawnPoint;

	public enum 			Teams				{TEAM1,TEAM2};
    public enum             GameState           {PREROUND,BATTLE,ENDBATTLE};

    GameState currentGameState;


    // Use this for initialization
    void Start () {

        SpawnPoint = (GameObject)Resources.Load("SpawnPoint");
        currentGameState = GameState.PREROUND;
        CreateSpawnPoint ();
        currentGameState = GameState.BATTLE;

    }

	public void CreatePlayer (GameObject Player) {
		ObjectList.Add(Player);
	}

	public void CreateEnemy ( GameObject Enemy) {
		ObjectList.Add(Enemy);
	}

    public GameState GetGameState() {
        return currentGameState;

    }

    public void CreateSpawnPoint () {

        

        for (int i = 0; i <= 7; i++)
        {
            GameObject go = Instantiate(SpawnPoint, new Vector3(-8, 0, 7 - i*2), this.transform.rotation);
            go.GetComponent<SpawnPoint>().SetTeam(GameManager.Teams.TEAM1);
            go.GetComponent<SpawnPoint>().GM = this;
            go.GetComponent<SpawnPoint>().SpawnObject();

            SpawnPoints.Add(go);
        }

        for (int i = 0; i <= 7; i++)
        {
            GameObject go = Instantiate(SpawnPoint, new Vector3(8, 0, 7 - i * 2), this.transform.rotation);
            go.GetComponent<SpawnPoint>().SetTeam(GameManager.Teams.TEAM2);
            go.GetComponent<SpawnPoint>().GM = this;
            go.GetComponent<SpawnPoint>().SpawnObject();
            SpawnPoints.Add(go);
        }

	}


	// Update is called once per frame
	void Update () {
	
	}
}
