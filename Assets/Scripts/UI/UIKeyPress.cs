using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIKeyPress : MonoBehaviour {
	[SerializeField]private int _currentTurretButton;
	[SerializeField]private List<GameObject> _turretButtons = new List<GameObject>();
	private TurretStats _ts;

	void Start() {
		_currentTurretButton = 0;
		_ts = FindObjectOfType<TurretStats>();
		GetSetStats();
	}

	public void DecreaseCurrent () {
		if(_currentTurretButton > 0) {
			_currentTurretButton--;
			for(int i = 0; i < _turretButtons.Count; i++) {
				_turretButtons[i].SetActive(false);	
			}
		}

		_turretButtons[_currentTurretButton].SetActive(true);
		GetSetStats();
	}

	public void IncreaseCurrent () {
		if(_currentTurretButton < _turretButtons.Count - 1) {
			_currentTurretButton++;
			for(int i = 0; i < _turretButtons.Count; i++) {
				_turretButtons[i].SetActive(false);	
			}
		}
		_turretButtons[_currentTurretButton].SetActive(true);
		GetSetStats();
	}

	void GetSetStats() {
		if(_currentTurretButton == 0) {
			_ts.SetStats(0.5f, 3, 2);
		} else if(_currentTurretButton == 1) {
			_ts.SetStats(3,3,0);
		} else if(_currentTurretButton == 2) {
			_ts.SetStats(1.5f,3,1);
		}
	}
}
