using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuildTurret : MonoBehaviour {
	[SerializeField]private GameObject _road;
	[SerializeField]private Text _costsText;
	private bool _isBuilding = false;
	private bool _canPlace = false;
	private GameObject _selectedTurret;
	private Color _normalColor;
	private float _costs;
	SpriteRenderer _r;
	PlayerResources _pr;

	void Start() {
		_pr = FindObjectOfType<PlayerResources>();
	}

	Vector3 MousePos() {	
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 roundMousePos = new Vector2(mousePos.x,mousePos.y);
		return roundMousePos;
	}

	public void BuildUnit(GameObject turret) {
		_costs = 100 * turret.GetComponent<TurretUnit>().Power;
		if(_pr.Resources >= _costs) {
			_isBuilding = true;
			_selectedTurret = Instantiate(turret, MousePos(), Quaternion.identity) as GameObject;
			_r = _selectedTurret.GetComponent<SpriteRenderer>();
			_normalColor = _r.material.color;
			_r.sortingOrder = 5;
			_pr.RemoveResources(_costs);
		}
	}

	void Update () {
		Building();
		_costsText.text = _costs.ToString();
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
				_r.material.color = _normalColor;
				_r.sortingOrder = 3;
			}
		}
	}

	void DrawRayCast() {
		Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		RaycastHit2D hitWorld = Physics2D.Raycast(mousePos, Vector2.zero, Mathf.Infinity, LayerMask.GetMask("World"));
		RaycastHit2D hitTurret = Physics2D.Raycast(mousePos, Vector2.zero, Mathf.Infinity, LayerMask.GetMask("Turret"));
		Collider2D collider = Physics2D.OverlapCircle(mousePos, 1, LayerMask.GetMask("Road"));
		if(collider) {
			if(!hitTurret) {
				if(hitWorld) {
					_r.material.color = new Color(0, 250, 0, 0.5f);
					_canPlace = true;
				} else {
					_r.material.color = new Color(250, 0, 0, 0.5f);
					_canPlace = false;
				}
			} else {
				_r.material.color = new Color(250, 0, 0, 0.5f);
				_canPlace = false;
			}
		} else {
			_r.material.color = new Color(250, 0, 0, 0.5f);
			_canPlace = false;
		}
	}
}
