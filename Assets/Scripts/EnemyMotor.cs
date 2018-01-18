using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMotor : MonoBehaviour {

	public GameObject player;
	public float distanceToTarget, speed = .05f, climbingSpeed = 1f;

	Transform closestLadder = null;
	bool needToFindLadder = true, goToLadder = true, onPlayerY = false;
	float ladderDistance;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		distanceToTarget = (player.transform.position - transform.position).magnitude;

		if (tag == "Ghost") {
			if (distanceToTarget > 3) {
				transform.position = Vector3.MoveTowards (transform.position, player.transform.position, speed);
			} else {
				transform.position = transform.position;
			}
		} else {
			if (transform.position.y == player.transform.position.y) {
				needToFindLadder = false;
				goToLadder = false;
			}
			if (transform.position.y != player.transform.position.y && needToFindLadder) {
				closestLadder = FindNearestLadder ();
				needToFindLadder = false;
			}
			if (goToLadder) {
				transform.position = Vector3.MoveTowards (transform.position, new Vector3(closestLadder.position.x, transform.position.y), speed);
				if (transform.position.x == closestLadder.position.x) {
					goToLadder = false;
				}
			} else {
				if (transform.position.y == player.transform.position.y) {
					onPlayerY = true;
				}
				if(transform.position.y != player.transform.position.y) {
					transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, player.transform.position.y, transform.position.z), climbingSpeed); 
				}
				if (distanceToTarget > 3 && onPlayerY) {
					transform.position = Vector3.MoveTowards (transform.position, player.transform.position, speed);
				} else {
					transform.position = transform.position;
				}
			}
		}

	}

	Transform FindNearestLadder(){
		GameObject[] ladders;
		ladders = GameObject.FindGameObjectsWithTag ("Ladder");
		GameObject closest = null;
		float distance = Mathf.Infinity;
		Vector3 position = transform.position;
		foreach (GameObject ladder in ladders) {
			Vector3 difference = ladder.transform.position - position;
			float curDistance = difference.sqrMagnitude;
			if (curDistance < distance) {
				closest = ladder;
				distance = curDistance;
			}
		}
		return closest.transform;
	}
}
