using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
	public int highScore;
	public int score;
	public Text scoreText;
	public Text highText;

	void Awake () {
		score = 0;
		highScore = PlayerPrefs.GetInt ("High Score", 0);
		highText.text = "High Score: " + highScore;
	}

	void Update () {
		scoreText.text = "Score: " + score;

		if (score > highScore) {
			highScore = score;
			PlayerPrefs.SetInt ("High Score", highScore);	
		}
	} 
}
