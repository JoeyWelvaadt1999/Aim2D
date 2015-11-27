using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerResources : MonoBehaviour {
	[SerializeField]private Text _resourcesText;
	private float _resources = 500;
	public float Resources {
		get {
			return _resources;
		}
	}

	void Start() {
		_resourcesText.text = _resources.ToString();
	}

	public void AddResources(float amount) {
		_resources += amount;
		Mathf.RoundToInt(_resources);
		_resourcesText.text = _resources.ToString();
	}

	public void RemoveResources(float amount) {
		_resources -= amount;
		Mathf.RoundToInt(_resources);
		_resourcesText.text = _resources.ToString();
	}
}
