using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class UpgradeTurret : MonoBehaviour {
	public void Upgrade() {
		TurretSelected[] wTurrets = GameObject.FindObjectsOfType<TurretSelected>();
		Debug.Log(wTurrets.Length);
		for (int i = 0; i < wTurrets.Length; i++) {
			if(wTurrets[i].IsSelected == true) {
				Debug.Log(wTurrets[i].IsSelected);
				wTurrets[i].GetComponent<TurretUnit>().LevelUp();
			}
		}
	}
}
