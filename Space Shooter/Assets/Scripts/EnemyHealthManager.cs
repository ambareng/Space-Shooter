using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {
	public int enemyHealth;

	public void Damage (int damage) {
		enemyHealth -= damage;
	}
}
