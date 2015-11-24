using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {
	[SerializeField]private GUIStyle gsText;
	bool _isPaused;

	void Update () {
		if(Input.GetKeyDown(KeyCode.P)) {
			_isPaused = (_isPaused) ? false : true;
			if(_isPaused) {
				Time.timeScale = 0;
			} else {
				Time.timeScale = 1;
			}
		}
	}

	void OnGUI() {
		if(_isPaused) {
			string gt = GUI.TextArea(new Rect(Screen.width / 2- 150, Screen.height / 2 - 50, 300, 100), "Paused", gsText);
			GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
		}
	}
}
