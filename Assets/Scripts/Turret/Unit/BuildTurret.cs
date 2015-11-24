using UnityEngine;
using System.Collections;

public class BuildTurret : MonoBehaviour {
	private bool _isBuilding = false;
	private bool _canPlace = false;
	private GameObject _selectedTurret;
	private Color _normalColor;
	SpriteRenderer[] _r;

	Vector3 MousePos() {
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 roundMousePos = new Vector2(Mathf.RoundToInt(mousePos.x), Mathf.RoundToInt(mousePos.y));
		return roundMousePos;
	}

	public void BuildUnit(GameObject turret) {
		_isBuilding = true;
		_selectedTurret = Instantiate(turret, MousePos(), Quaternion.identity) as GameObject;
		_r = _selectedTurret.GetComponentsInChildren<SpriteRenderer>();
		for(int i = 0; i < _r.Length; i++){
			_normalColor = _r[i].material.color;
		}
	}

	void Update () {
		Building();

	}

	void Building() {
		if(_isBuilding) {
			Vector3 mousePos = MousePos();
			_selectedTurret.GetComponent<TurretUnit>().enabled = false;		
			_selectedTurret.transform.position = mousePos;
			DrawRayCast();
			if(Input.GetMouseButtonDown(0) && _canPlace) {
				_isBuilding = false;
				_selectedTurret.GetComponent<TurretUnit>().enabled = true;

				for (int i = 0; i < _r.Length; i++) {
					_r[i].material.color = _normalColor;

				}
			}
		}
	}

	void DrawRayCast() {
		Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		RaycastHit2D hitWorld = Physics2D.Raycast(mousePos, Vector2.zero, Mathf.Infinity, LayerMask.GetMask("World"));
		RaycastHit2D hitTurret = Physics2D.Raycast(mousePos, Vector2.zero, Mathf.Infinity, LayerMask.GetMask("Turret"));
		for (int i = 0; i < _r.Length; i++) {
			if(!hitTurret) {
				if(hitWorld) {
					_r[i].material.color = new Color(0, 250, 0, 0.5f);
					_canPlace = true;
				} else {
					_r[i].material.color = new Color(250, 0, 0, 0.5f);
					_canPlace = false;
				}
			} else {
				_r[i].material.color = new Color(250, 0, 0, 0.5f);
				_canPlace = false;
			}
		}

	}

}
