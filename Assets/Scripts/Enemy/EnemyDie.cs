using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyDie : MonoBehaviour {
	[SerializeField]private Image _healthBar;
	[SerializeField]private float _health = 10;
	private float _maxHealth;
	private float _whileIgnite;
	private bool _ignite;
	PlayerResources _pr;
	Animator _anim;

	public bool Ignite {
		get {
			return _ignite;
		} set {
			_ignite = value;
		}
	}

	void Awake() {
		_pr = FindObjectOfType<PlayerResources>();
		_anim = GetComponent<Animator>();
	}

	void Start() {
		_health = 0 + (2 * FindObjectOfType<EnemySpawner>().Wave);
		_maxHealth = _health;
		_healthBar.fillAmount = (1.0f / _maxHealth) * (_health);
	}

	void Update() {
		if(_ignite) {
			Debug.Log("is true");
			_whileIgnite += Time.deltaTime;
			float seconds = Mathf.Floor(_whileIgnite%60);
			if(seconds < 2) {
				_health -= 0.01f;
				_anim.SetBool("Ignite", true);
				Die (false, 0);
			} else {
				_ignite = false;
				_anim.SetBool("Ignite", false);
				_whileIgnite = 0;
			}
		}
	}

	public void Die(bool immediateDeath, float power) {
		if(_health <= 0 || immediateDeath) {
			Destroy(this.gameObject);
			if(!immediateDeath) {
				_pr.AddResources((int)_maxHealth * 3);
			}
		} else {
			_health-=1*power;
			_healthBar.fillAmount = (1.0f / _maxHealth) * (_health);
		}
	}
}
