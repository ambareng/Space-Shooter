using UnityEngine;

public class EnemyController : MonoBehaviour {
	public float enemySpeed;
	
	public FormationController formationController;

	void Awake () {
		formationController = FindObjectOfType<FormationController> ();
		enemySpeed = formationController.formationSpeed;
	}

	void Update () {
		transform.Translate (0f, -enemySpeed * Time.deltaTime, 0f);
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
