//using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UseAbility : MonoBehaviour {
	private float radius = 4;
	private float health = 10;
	private int maxHealth = 10;
	public int lineCount = 100;
	
	static Material lineMaterial;
	[SerializeField]private Image _healthbar;
	
	void Awake () {         
		_healthbar.fillAmount = (1.0f / maxHealth) * (health + 1);
	}
	
	void Update () {      
		Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius, LayerMask.GetMask("Enemy"));
		foreach(Collider2D coll in colliders) {
			Destroy(coll.gameObject);
		}
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, radius);
	}

}
