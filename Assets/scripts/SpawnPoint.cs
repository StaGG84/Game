using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {


    public GameManager GM;
    GameObject spawnObject;
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
        spawnObject = (GameObject)Resources.Load("Enemy");
        GameObject go = Instantiate (spawnObject, this.transform.position, this.transform.rotation);
        go.GetComponent<ObjectParam>().SetTeam(team);
        GM.CreateEnemy(go);
        go.GetComponent<AIController>().GM = GM;
      
}

}
