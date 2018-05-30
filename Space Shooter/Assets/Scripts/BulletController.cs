using UnityEngine;

public class BulletController : MonoBehaviour {
	public float bulletSpeed;
	PauseManager pauseManager;

	void Awake () {
		bulletSpeed = 20f;
		pauseManager = FindObjectOfType<PauseManager> ();
	}

	void Update () {
		if (pauseManager.isPlaying == true) {
			transform.Translate (0f, bulletSpeed * Time.deltaTime, 0f);
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.tag == "Border")
			Destroy (this.gameObject);
	}
}
