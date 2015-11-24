using UnityEngine;
using System.Collections;

public class TurretSelected : MonoBehaviour {
	private bool _isSelected = false;

	void Start() {
		TurretSelected[] ts = FindObjectsOfType<TurretSelected>();
		for(int i = 0; i < ts.Length; i++) {
			ts[i].IsSelected = false;
		}
	}
	
	public bool IsSelected {
		get {
			return _isSelected;
		} set {
			_isSelected = value;
		}
	}

	public void OnClickSetBool() {

		this._isSelected = true;

	}


}
