using UnityEngine;

public class TouchMovement : MonoBehaviour {
	public Vector3 pos;
	PauseManager pauseManager;

	void Awake () {
		pauseManager = FindObjectOfType<PauseManager> ();
	}

	void Update () {
		if (pauseManager.isPlaying) {
			if (Application.platform == RuntimePlatform.Android) { // Checks if running at android or not
				pos = Camera.main.ScreenToWorldPoint (new Vector3 (Input.GetTouch (0).position.x, Input.GetTouch (0).position.y, 1));
			} else {
				pos = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 1));
			}

			transform.position = new Vector3 (pos.x, pos.y + 0.5f, pos.z);
		}
	}
}
