using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject[] enemies;
	public Vector3 spawnOffset;
	public float spawnWait, spawnMostWait, spawnLeastWait, startWait, maxEnemies;

	bool stopSpawning;
	int randEnemy;

	// Use this for initialization
	void Start () {
		StartCoroutine (waitForSpawn ());
		startWait = Random.Range (spawnLeastWait, spawnMostWait + 1);
	}
	
	// Update is called once per frame
	void Update () {
		spawnWait = Random.Range (spawnLeastWait, spawnMostWait + 1);
	}

	IEnumerator waitForSpawn(){
		yield return new WaitForSeconds (startWait);

		while (!stopSpawning) {
			randEnemy = Random.Range (0, enemies.Length);

			Vector3 spawnPosition = new Vector3 (Random.Range (-spawnOffset.x + transform.position.x, spawnOffset.x + transform.position.x), transform.position.y);

			GameObject enemy = Instantiate (enemies [randEnemy], spawnPosition, Quaternion.identity) as GameObject;

			enemy.transform.parent = GameObject.FindGameObjectWithTag ("EnemyTransform").transform;

			if (GameObject.FindGameObjectWithTag ("EnemyTransform").transform.childCount >= maxEnemies) {
				stopSpawning = true;
			} else {
				stopSpawning = false;
			}

			yield return new WaitForSeconds (spawnWait);
		}
	}
}
