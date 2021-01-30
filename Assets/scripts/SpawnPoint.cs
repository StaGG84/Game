using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {


    public GameManager GM;
    public GameObject spawnObject;
    private GameManager.Teams team = GameManager.Teams.TEAM1;

    public int spawnCount = 0;

	public float spawnTimer = 0;
	public float spawnInterval = 1;

    /*Team ==========================================================================*/
    public GameManager.Teams GetTeam()
    {
        return team;
    }
    public void SetTeam(GameManager.Teams i)
    {
        team = i;
    }
    /*===============================================================================*/


    public void SpawnObject (){
        //spawnObject = (GameObject)Resources.Load("Mutant");
        GameObject go = Instantiate (spawnObject, transform.position, transform.rotation);
        go.GetComponent<ObjectParam>().SetTeam(team);
        GM.CreateEnemy(go);
        go.GetComponent<AIController>().GM = GM;
      
}

}
