using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	public void Change(int scene) {
		Application.LoadLevel(scene);
	}

	public void Stop() {
		Application.Quit();
	}
}
