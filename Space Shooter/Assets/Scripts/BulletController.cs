using UnityEngine;

public class BulletController : MonoBehaviour {
	public float bulletSpeed;

	void Awake () {
		bulletSpeed = 20f;
	}

	void Update () {
		transform.Translate (0f, bulletSpeed * Time.deltaTime, 0f);
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.tag == "Border")
			Destroy (this.gameObject);
	}
}
