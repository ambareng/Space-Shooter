using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour {
	public bool isPlaying;
	public Text startText;

	void Awake () {
		isPlaying = false;
		startText.enabled = true;
	}

	void Update () {
		if (Input.GetMouseButtonDown (0) && isPlaying == false) {
			isPlaying = true;
			startText.enabled = false;
		}
	}

	public void Pause () {
		startText.enabled = true;
		isPlaying = false;
	}
}
