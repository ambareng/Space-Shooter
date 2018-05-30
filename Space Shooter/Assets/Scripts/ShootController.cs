using UnityEngine;
using System.Collections;

public class ShootController : MonoBehaviour {
	public float shootCooldown;
	public GameObject bullet;
	Vector3 shootPos;
	PauseManager pauseManager;

	void Awake () {
		pauseManager = FindObjectOfType<PauseManager> ();
	}

	void Update () {
		if (pauseManager.isPlaying) {
			shootCooldown -= Time.deltaTime;
			shootPos = transform.position;

			if (shootCooldown <= 0) {
				StartCoroutine ("Shoot");
				shootCooldown = 0.25f;
			}
		}
	}

	IEnumerator Shoot () {
		GameObject bulletObj = Instantiate (bullet, shootPos, Quaternion.identity);

		bulletObj.transform.position = shootPos;
		yield return new WaitForSeconds (0.0000001f);
	}
}
