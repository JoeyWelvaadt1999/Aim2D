using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BaseHealth : MonoBehaviour {
	[SerializeField]private Text _healthText;
	private float _health = 100;

	public void DecreaseHealth(float amount) {
		_health-=amount;
		_healthText.text = _health.ToString();
		Debug.Log(_health);
	}
}
