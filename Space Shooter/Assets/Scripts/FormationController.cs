using UnityEngine;

public class FormationController : MonoBehaviour {
	public float formationSpeed;

	void Update () {
		transform.Translate (0f, -formationSpeed * Time.deltaTime, 0f);
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.tag == "Border")
			Destroy (gameObject);
	}
}
