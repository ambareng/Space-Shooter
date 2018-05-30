using UnityEngine;

public class EnemyController : MonoBehaviour {
	public float enemySpeed;
	FormationController formationController;
	PauseManager pauseManager;

	void Awake () {
		formationController = FindObjectOfType<FormationController> ();
		enemySpeed = formationController.formationSpeed;
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
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}
}
