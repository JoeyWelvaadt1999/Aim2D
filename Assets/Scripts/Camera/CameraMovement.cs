using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	float moveSpeed = 0.25f;


	void Update() {
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");
		float xPos = transform.position.x;
		float yPos = transform.position.y;

		if(x != 0) {
			xPos += moveSpeed * x;
		}

		if(z != 0) {
			yPos += moveSpeed * z;
		}

		xPos = Mathf.Clamp(xPos, -7.7f, 10.7f);
		yPos = Mathf.Clamp(yPos, -5, 5);
		Vector3 newPos = new Vector3(xPos, yPos, -10);
		transform.position = newPos;
	}
}
