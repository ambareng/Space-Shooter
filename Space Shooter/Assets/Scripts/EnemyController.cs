using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour {
	public GameObject enemyBullet;
	int enemySpeed;
	public int difficulty;
	float shootCooldown;
	FormationController formationController;
	PauseManager pauseManager;
	ScoreManager scoreManager;
	EnemyHealthManager enemyHealthManager;
	public bool isInvincible;
	public bool canShoot;

	void Awake () {
		isInvincible = true;
		canShoot = true;
		scoreManager = FindObjectOfType<ScoreManager> ();
		formationController = FindObjectOfType<FormationController> ();
		enemyHealthManager = GetComponent<EnemyHealthManager> ();
		if (scoreManager.score <= 50) {
			difficulty = (scoreManager.score / 10);
		} else {
			difficulty = 5;
		}
		enemySpeed = formationController.formationSpeed + difficulty;
		if (difficulty < 3) {
			enemyHealthManager.enemyHealth = 1 + difficulty;
		} else {
			enemyHealthManager.enemyHealth = 3;
		}
		pauseManager = FindObjectOfType<PauseManager> ();
		shootCooldown = 0f;
	}

	void Update () {
		if (pauseManager.isPlaying) {
			transform.Translate (0f, -enemySpeed * Time.deltaTime, 0f);

			if (scoreManager.score >= 20) {
				shootCooldown -= Time.deltaTime;

				if (shootCooldown <= 0 && canShoot) {
					StartCoroutine ("Shoot");
					shootCooldown = 2f;
				}
			}
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.tag == "Border") {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Bullet") {
			if (!isInvincible) {
				enemyHealthManager.Damage (1);
			}
			Destroy (other.gameObject);
			if (enemyHealthManager.enemyHealth <= 0) {
				scoreManager.score += 1;
				Destroy (gameObject);
			}
		} else if (other.tag == "Player") {
			Destroy (other.gameObject);
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
			Destroy (gameObject);
		} else if (other.tag == "Invincibility Line") {
			isInvincible = false;
		} else if (other.tag == "No Shoot Line") {
			canShoot = false;
		}
	}

	IEnumerator Shoot () {
		int willShoot = Random.Range (0, 2);
		if (willShoot == 1) {
			GameObject enemyBulletObj = Instantiate (enemyBullet, transform.position, Quaternion.identity);
			enemyBulletObj.transform.position = transform.position;
		}

		yield return new WaitForSeconds (0.0000001f);
	}
}
