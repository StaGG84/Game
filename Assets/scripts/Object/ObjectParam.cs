using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectParam : MonoBehaviour {

	private float 			 maxHealth 			= 100;
	private float 			 currentHealth 		= 100;
	private float 			 moveSpeed 			= 2f;
	private float 			 runSpeed			= 4f;
	private float 			 speedMultiplier	= 1f;
	private float 			 rotateSpeed 		= 3f;
	private float 			 attackSpeed 		= 1f;
	private float 			 attackTimer		= 0f;
	private float 			 AggrRadius  		= 10f;
	private GameManager.Teams team 				= GameManager.Teams.TEAM1;
							 
	private GameObject 		 target;
	private GameObject 		 weapon;
							 
	/*Target ========================================================================*/
	public GameObject GetTarget(){
		return target;
	}
	public void SetTarget(GameObject go){
		target = go;
	}
	/*===============================================================================*/


	/*Weapon ========================================================================*/
	public GameObject GetWeapon(){
		return weapon;
	}
	public void SetWeapon(GameObject go){
		weapon = go;
	}
	/*===============================================================================*/


	/*===============================================================================*/
	// Parameter processing
	/*===============================================================================*/

	void AddjustCurrentHealth ( float adj) {
		currentHealth = adj;

		if (currentHealth < 0)
			currentHealth = 0;
		
		if (currentHealth > maxHealth)
			currentHealth = maxHealth;

		if (currentHealth == 0)
			ObjectDestroy();
	}


	public void ObjectDestroy() {
		Debug.Log (this.gameObject);//Destroy (this.gameObject);
	}

	/*CurrentHealth =================================================================*/
	public float GetCurrentHealth() {
		return currentHealth;
	}
	public void SetCurrentHealth(float i) {
		currentHealth = i;
	}
	public void AddCurrentHealth(float i) {
		currentHealth += i;
	}
	/*===============================================================================*/


	/*MaxHealth =====================================================================*/
	public float GetMaxHealth() {
		return maxHealth;
	}
	public void SetMaxHealth(float i) {
		maxHealth = i;
	}
	public void AddMaxHealth(float i) {
		maxHealth += i;
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
		return moveSpeed;
	}
	public void SetAttackSpeed(float i) {
		moveSpeed = i;
	}
	public void AddAttackSpeed(float i) {
		moveSpeed += i;
	}
	/*===============================================================================*/

	/*AttackTimer ===================================================================*/
	public float GetAttackTimer() {
		return attackTimer;
	}
	public void SetAttackTimer(float i) {
		attackTimer = i;
	}
	public void AddAttackTimer(float i) {
		attackTimer += i;
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


	/*Attack ========================================================================*/
	public void Attack() {
		if((Time.time-attackTimer) >= attackSpeed){
			Instantiate (weapon,transform,false);
			attackTimer = Time.time;
		}
	}
	/*===============================================================================*/


	/*Movement And Rotation =========================================================*/
	public void ActivateMoveSpeed () {
		speedMultiplier = moveSpeed;
	}

	public void ActivateRunSpeed () {
		speedMultiplier = runSpeed;
	}

	public void Move (Vector3 move) {
		this.transform.Translate(move*speedMultiplier*Time.deltaTime);
	}

	public void Rotate (Vector3 rotate) {
		transform.Rotate (rotate * Input.GetAxis("Mouse X")*rotateSpeed);
	}

	public void LookAtTarget (){
		this.transform.LookAt (target.transform);
	}
	/*===============================================================================*/


	// Use this for initialization
	void Avake () {
	}
	
	// Update is called once per frame
	void Update () {
		AddjustCurrentHealth (currentHealth);


	}
}
