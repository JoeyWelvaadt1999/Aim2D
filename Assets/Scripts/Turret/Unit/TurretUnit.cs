using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TurretUnit : MonoBehaviour {
	[SerializeField]private Text _costsText;
	[SerializeField]protected float _radius;
	[SerializeField]protected float _rate;
	[SerializeField]protected float _power;
	[SerializeField]private float _increase;
	[SerializeField]private int _maxLevel;
	[SerializeField]private Sprite[] _upgradeSprites;

	private PlayerResources _pr;
	private SpriteRenderer _sr;
	private int _level = 1;
	private int _costs;
	private float _waitTime;
	private float _time;

	[SerializeField]
	private GameObject
		_bullet;
	[SerializeField]
	private GameObject
		_nozzle;

	public float Power {
		get {
			return _power;
		}
	}

	public float Radius {
		get {
			return _radius;
		}
	}

	public float Rate {
		get {
			return _rate;
		}
	}

	void Awake() {
		_sr = GetComponent<SpriteRenderer>();
		_pr = FindObjectOfType<PlayerResources>();
		_costsText = GameObject.Find("UpgradeCosts").GetComponent<Text>();
	}

	void Update ()
	{
		Rotate ();
		Shoot ();
		_costsText.text = _costs.ToString();
	}

	private GameObject GetTarget() {
		Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _radius, LayerMask.GetMask("Enemy"));
		GameObject closestTarget = null;
		float smallestDistance = int.MaxValue;

		foreach (Collider2D coll in colliders)
		{
			float distance = Vector3.Distance(transform.position, coll.transform.position);
			if(distance < smallestDistance) {
				closestTarget = coll.gameObject;
				smallestDistance = distance;
			}
		}
		return closestTarget;
	}

	public void LevelUp() {
		_costs = 100 + 300 * (_level + (int)_power);
		Debug.Log (_costs);
		if(_pr.Resources >= _costs) {
			if(_level < _maxLevel) {
				_power += _increase;
				_rate += _increase;
				_radius += _increase;
				_level++;
				_sr.sprite = _upgradeSprites[_level - 2];
				_pr.RemoveResources(_costs);
			}
		}
	}

	private Vector2 PredictPosition(GameObject enemy, GameObject bullet, GameObject nozzle) {
		Vector2 enemyPos = enemy.transform.position;
		float bulletSpeed = bullet.GetComponent<MoveBullet>().Speed * Time.fixedDeltaTime;
		float distance = Vector2.Distance(nozzle.transform.position, enemyPos);
		float travelTime = distance / bulletSpeed;
		Vector2 velocity = enemy.GetComponent<EnemyMovement>().Velocity;
		Vector2 pre = enemyPos + velocity * travelTime;

		distance = Vector2.Distance(transform.position, pre);
		travelTime = distance / bulletSpeed;
		pre = enemyPos + velocity * travelTime;

		Debug.DrawLine(transform.position, pre);
		return pre;
	}

	private void Shoot () {
		_waitTime = (1.3f - (0.2f * _rate));

		_time += Time.deltaTime;
		if(_time >= _waitTime) {
			GameObject b = Instantiate(_bullet, _nozzle.transform.position, transform.rotation) as GameObject;
			b.GetComponent<BulletHit>().Power = _power;
			_time = 0;
		}
	}

	private float GetAngle(Vector3 target) {
		Vector3 distance = transform.position - target;
		float angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
		return angle;
	} 

	private void Rotate ()
	{
		transform.rotation = Quaternion.AngleAxis (GetAngle (PredictPosition (GetTarget (), _bullet, _nozzle)) + 90, Vector3.forward);
	}  
	
	private void OnDrawGizmos ()
	{
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere (transform.position, _radius);
	}
}
