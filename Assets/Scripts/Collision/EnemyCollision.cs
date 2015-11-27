using UnityEngine;
using System.Collections;

public class EnemyCollision : MonoBehaviour {
	BulletHit _bh;

	void OnTriggerEnter2D(Collider2D coll) {
		_bh = coll.GetComponent<BulletHit>();
		if(_bh != null) {
			_bh.Hit(this.gameObject);
			Destroy(coll.gameObject);
		}
	}
}
