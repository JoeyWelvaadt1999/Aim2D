using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyDie : MonoBehaviour {
	[SerializeField]private Image _healthBar;
	[SerializeField]private float _health = 10;
	private float _maxHealth;

	void Start() {
		_health = 5 + (5 * FindObjectOfType<EnemySpawner>().Wave);
		_maxHealth = _health;
		_healthBar.fillAmount = (1.0f / _maxHealth) * (_health + 1);
	}

	public void Die(bool immediateDeath, float power) {
		if(_health <= 0 || immediateDeath) {
			Destroy(this.gameObject);
		} else {
			_health-=1*power;
			_healthBar.fillAmount = (1.0f / _maxHealth) * (_health + 1);
		}
	}
}
