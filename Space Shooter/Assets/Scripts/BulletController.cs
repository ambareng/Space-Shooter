using UnityEngine;

public class BulletController : MonoBehaviour {
	public float bulletSpeed;
	private Renderer compRenderer;

	void Awake () {
		bulletSpeed = 20f;
		compRenderer = this.gameObject.GetComponent<Renderer> ();
	}

	void Update () {
		transform.Translate (0f, bulletSpeed * Time.deltaTime, 0f);
	}

	void OnTriggerExit2D (Collider2D other) {
		Destroy (this.gameObject);
	}
}
