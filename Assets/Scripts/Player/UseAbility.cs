using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UseAbility : MonoBehaviour {
	[SerializeField]private GameObject _usedAbility;
	[SerializeField]private Image _coolDownBar;
	private bool _isUsingFireAbility;
	private bool _isUsingWaterAbility;
	private bool _isUsingEarthAbility;
	float _timer = 30;
	bool _canUse;

	void Start() {
		_usedAbility = Instantiate(_usedAbility, new Vector3(MousePos().x, MousePos().y, 0), Quaternion.identity) as GameObject;
		_usedAbility.SetActive(false);
	}

	Vector3 MousePos() {
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		return mousePos;
	}

	public void FireAbility() {
		if(_canUse) {
			_isUsingFireAbility = true;
			_usedAbility.SetActive(true);
		}
	}

	public void WaterAbility() {
		if(_canUse) {
			_isUsingWaterAbility = true;
			_usedAbility.SetActive(true);
		}
	}

	public void EarthAbility() {
		if(_canUse) {
			_isUsingEarthAbility = true;
			_usedAbility.SetActive(true);
		}
	}

	void Update() {
		UsingAbility();
		_timer+=Time.deltaTime;
		float seconds = Mathf.Floor(_timer%60);
		if (seconds >= 10) {
			_canUse = true;
			_timer = 30;
		} 
		_coolDownBar.fillAmount = (1f / 10f) * seconds;
	}

	void UsingAbility() {
		Collider2D[] colliders = Physics2D.OverlapCircleAll(_usedAbility.transform.position, 4, LayerMask.GetMask("Enemy"));
		_usedAbility.transform.position = new Vector3(MousePos().x, MousePos().y, 0);	
		if(_isUsingFireAbility && Input.GetMouseButtonDown(0)) {
			foreach(Collider2D coll in colliders) {
				EnemyDie ed = coll.GetComponent<EnemyDie>();
				ed.Ignite = true;
				_isUsingFireAbility = false;
				_usedAbility.SetActive(false);
				_canUse = false;
				_timer = 0;
			}
		}

		if(_isUsingWaterAbility && Input.GetMouseButtonDown(0)) {
			foreach(Collider2D coll in colliders) {
				EnemyMovement em = coll.GetComponent<EnemyMovement>();
				em.WaterSpeed = true;
				_isUsingWaterAbility = false;
				_usedAbility.SetActive(false);
				_canUse = false;
				_timer = 0;
			}
		}

		if(_isUsingEarthAbility && Input.GetMouseButtonDown(0)) {
			foreach(Collider2D coll in colliders) {
				EnemyMovement em = coll.GetComponent<EnemyMovement>();
				em.EarthSpeed = true;
				_isUsingEarthAbility = false;
				_usedAbility.SetActive(false);
				_canUse = false;
				_timer = 0;
			}
		}
	}

	void OnDrawGizmos() {
		if(_isUsingFireAbility || _isUsingWaterAbility || _isUsingEarthAbility) {
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(MousePos(), 4);
		}
	}
}
