using UnityEngine;

public class EnemyController : MonoBehaviour {
	int enemySpeed;
	int difficulty;
	FormationController formationController;
	PauseManager pauseManager;
	ScoreManager scoreManager;
	EnemyHealthManager enemyHealthManager;

	void Awake () {
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
	}

	void Update () {
		if (pauseManager.isPlaying) {
			transform.Translate (0f, -enemySpeed * Time.deltaTime, 0f);
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.tag == "Border") {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Bullet" || other.tag == "Player") {
			enemyHealthManager.Damage (1);
			Destroy (other.gameObject);
			if (enemyHealthManager.enemyHealth <= 0) {
				scoreManager.score += 1;
				Destroy (gameObject);
			}
		}
	}
}
