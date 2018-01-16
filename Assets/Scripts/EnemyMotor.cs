using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMotor : MonoBehaviour {

	public Transform player;
	public float distanceToTarget, speed = 5f;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		distanceToTarget = (player.position - transform.position).magnitude;

		if (distanceToTarget > 3) {
			transform.position = Vector3.MoveTowards (transform.position, player.position, speed);
		} else {
			transform.position = transform.position;
		}

	}
}
