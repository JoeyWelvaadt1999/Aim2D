using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIButtonPress : MonoBehaviour {
	[SerializeField]private Sprite _change;
	private Sprite _startImage;

	void Start() {
		_startImage = GetComponent<SpriteRenderer>().sprite;
	}

	public void MouseDown() {
		GetComponent<SpriteRenderer>().sprite = _change;
	}

	public void MouseUp() {
		GetComponent<SpriteRenderer>().sprite = _startImage;
	}
}
