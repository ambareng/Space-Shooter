using UnityEngine;

public class BulletController : MonoBehaviour {
	public float bulletSpeed;
	public ScoreManager scoreManager;

	void Awake () {
		bulletSpeed = 20f;
		scoreManager = FindObjectOfType<ScoreManager> ();
	}

	void Update () {
		transform.Translate (0f, bulletSpeed * Time.deltaTime, 0f);
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.tag == "Border")
			Destroy (this.gameObject);
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Enemy") {
			scoreManager.score += 1;
		}
	}
}
