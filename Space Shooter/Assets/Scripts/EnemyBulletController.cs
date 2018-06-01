using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBulletController : MonoBehaviour {
	public float bulletSpeed;
	public GameObject player;
	PauseManager pauseManager;
	Vector3 moveDir;
	TouchMovement touchMovement;
	Vector3 playerPosition;
	EnemyController enemyController;

	void Awake () {
		enemyController = FindObjectOfType<EnemyController> ();
		bulletSpeed = 5f + enemyController.difficulty;
		pauseManager = FindObjectOfType<PauseManager> ();
		touchMovement = FindObjectOfType<TouchMovement> ();
		playerPosition = touchMovement.playerPosition;
		moveDir = (playerPosition - transform.position).normalized;
	}

	void Update () {
		if (pauseManager.isPlaying == true) {
			transform.position += moveDir * bulletSpeed * Time.deltaTime;
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.tag == "Border") {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {
			Destroy (other.gameObject);
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
			Destroy (gameObject);
		}
	}

	void OnBecameInvisible () {
		Destroy (this.gameObject);
	}
}
