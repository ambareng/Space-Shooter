using UnityEngine;

public class FormationController : MonoBehaviour {
	public int formationSpeed;
	PauseManager pauseManager;

	void Awake () {
		pauseManager = FindObjectOfType<PauseManager> ();
	}

	void Update () {
		if (pauseManager.isPlaying) {
			transform.Translate (0f, -formationSpeed * Time.deltaTime, 0f);
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.tag == "Border")
			Destroy (gameObject);
	}

	void OnBecameInvisible () {
		Destroy (gameObject);
	}
}
