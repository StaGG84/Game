using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectParam : MonoBehaviour {

    private float                       maxHealth;
    private float                       currentHealth;
    private float                       moveSpeed = 2f;
    private float                       attackSpeed = 1f;
    public bool                         isDead = false;
    private GameManager.Teams           team = GameManager.Teams.TEAM1;

    private float                       corpseLifeTime = 5;


    private AIController                AICon;


    private void Start()
    {
        AICon = GetComponent<AIController>();
        
        SetMaxHealth(Random.Range(100, 300));
        SetCurrentHealth(GetMaxHealth());
    }




    /*===============================================================================*/
    // Parameter processing
    /*===============================================================================*/

    void AddjustCurrentHealth() {

        if (currentHealth < 0)
            currentHealth = 0;

        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        if (currentHealth == 0)
        {
            isDead = true;
            AICon.ObjectIsDead();
        }

    }





    /*CurrentHealth =================================================================*/
    public float GetCurrentHealth() {
        return currentHealth;
    }
    public void SetCurrentHealth(float i) {
        currentHealth = i;
        AICon.ChangeHealth();
        AddjustCurrentHealth();
    }
    public void AddCurrentHealth(float i) {
        currentHealth += i;
        AICon.ChangeHealth();
        AddjustCurrentHealth();
    }
    /*===============================================================================*/



    /*MaxHealth =====================================================================*/
    public float GetMaxHealth() {
        return maxHealth;
    }
    public void SetMaxHealth(float i) {
        maxHealth = i;
        AICon.ChangeHealth();
    }
    public void AddMaxHealth(float i) {
        maxHealth += i;
        AICon.ChangeHealth();
    }
    /*===============================================================================*/
    

	/*MoveSpeed =====================================================================*/
	public float GetMoveSpeed() {
		return moveSpeed;
	}
	public void SetMoveSpeed(float i) {
		moveSpeed = i;
	}
	public void AddMoveSpeed(float i) {
		moveSpeed += i;
	}
	/*===============================================================================*/


	/*RunSpeed =====================================================================*/
	public float GetRunSpeed() {
		return moveSpeed;
	}
	public void SetRunSpeed(float i) {
		moveSpeed = i;
	}
	public void AddRunSpeed(float i) {
		moveSpeed += i;
	}
	/*===============================================================================*/


	/*AttackSpeed ===================================================================*/
	public float GetAttackSpeed() {
		return attackSpeed;
	}
	public void SetAttackSpeed(float i) {
        attackSpeed = i;
	}
	public void AddAttackSpeed(float i) {
        attackSpeed += i;
	}
	/*===============================================================================*/


	/*Team ==========================================================================*/
	public GameManager.Teams GetTeam() {
		return team;
	}
	public void SetTeam(GameManager.Teams i) {
		team = i;
	}
	/*===============================================================================*/


    /*isDead? ========================================================================*/
    public bool GetIsDead()
    {
        return isDead;
    }
    /*===============================================================================*/


    /*CorpseLifeTime ==========================================================================*/
    public float GetCorpseLifeTime()
    {
        return corpseLifeTime;
    }
    public void SetCorpseLifeTime(float i)
    {
        corpseLifeTime = i;
    }
    /*===============================================================================*/

}
