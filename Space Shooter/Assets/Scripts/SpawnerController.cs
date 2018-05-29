using UnityEngine;
using System.Collections;

public class SpawnerController : MonoBehaviour {
	public float spawnCooldown;
	public GameObject[] enemy;
	Vector3 spawnPos;

	void Awake () {
		spawnPos = transform.position;
	}

	void Update () {
		spawnCooldown -= Time.deltaTime;

		if (spawnCooldown <= 0) {
			StartCoroutine ("Spawn");
			spawnCooldown = 2f;
		}
	}

	IEnumerator Spawn () {
		int formation = Random.Range (0, 6);
		GameObject enemyObj = Instantiate (enemy[formation], spawnPos, Quaternion.identity);

		enemyObj.transform.position = spawnPos;

		yield return new WaitForSeconds (0.0000001f);
	}
}
