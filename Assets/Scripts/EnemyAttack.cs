using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

	public float attackTime = 3f, damage = 1f;

	GameObject player;
	EnemyMotor motor;
	Animator animator;
	float attackCoolDown = 0;
	bool canAttack = true;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		motor = GetComponent<EnemyMotor> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!canAttack) {
			attackCoolDown += Time.deltaTime;
			if (attackCoolDown >= attackTime) {
				canAttack = true;
				attackCoolDown = 0;
			}
		}
		if (motor.distanceToTarget <= 3 && canAttack) {
			Attack ();
		}
	}

	void Attack(){
		canAttack = false;
		animator.SetTrigger ("attack");
	}

	void DoDamage(){
		player.GetComponent<PlayerStats> ().health -= damage;
	}
}
