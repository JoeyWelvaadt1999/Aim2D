using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIKeyPress : MonoBehaviour {
	[SerializeField]private int _currentTurretButton;
	[SerializeField]private List<GameObject> _turretButtons = new List<GameObject>();


	void Start() {
		_currentTurretButton = 0;
	}

	public void DecreaseCurrent () {
		if(_currentTurretButton > 0) {
			_currentTurretButton--;
			for(int i = 0; i < _turretButtons.Count; i++) {
				_turretButtons[i].SetActive(false);	
			}
		}

		_turretButtons[_currentTurretButton].SetActive(true);
	}

	public void IncreaseCurrent () {
		if(_currentTurretButton < _turretButtons.Count - 1) {
			_currentTurretButton++;
			for(int i = 0; i < _turretButtons.Count; i++) {
				_turretButtons[i].SetActive(false);	
			}
		}
		_turretButtons[_currentTurretButton].SetActive(true);
	}
}
