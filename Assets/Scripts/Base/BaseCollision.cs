using UnityEngine;
using System.Collections;

public class BaseCollision : MonoBehaviour {
	BaseHealth _bd;

	void Start() {
		_bd = GetComponent<BaseHealth>();
	}

	void OnCollisionEnter2D (Collision2D coll)
	{

	}

	void OnTriggerEnter2D (Collider2D coll)
	{
		if(coll.transform.tag == "Enemy") {
			EnemyDie _ed = coll.gameObject.GetComponent<EnemyDie>();
			_ed.Die(false, 0);
			Destroy(coll.gameObject);
			_bd.DecreaseHealth(1);
		}	
	}	
}
