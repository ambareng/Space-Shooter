using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour {
	public bool isPlaying;
	public Text startText;
	public GameObject but_Pause;

	void Awake () {
		isPlaying = false;
		startText.enabled = true;
		but_Pause.SetActive (false);
	}

	void Update () {
		if (Input.GetMouseButtonDown (0) && isPlaying == false) {
			isPlaying = true;
			startText.enabled = false;
			but_Pause.SetActive (true);
		}
	}

	public void Pause () {
		startText.enabled = true;
		isPlaying = false;
		but_Pause.SetActive (false);
	}
}
