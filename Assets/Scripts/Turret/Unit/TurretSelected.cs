using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TurretSelected : MonoBehaviour {
	[SerializeField]private Image _damageText;
	[SerializeField]private Image _radiusText;
	[SerializeField]private Image _rateText;
	[SerializeField]private GameObject _showRadius;
	private bool _isSelected = false;
	TurretUnit tu;

	void Awake() {
		_damageText = GameObject.Find("UIDamageBar").GetComponent<Image>();
		_radiusText = GameObject.Find("UIRadiusBar").GetComponent<Image>();
		_rateText = GameObject.Find("UIRateBar").GetComponent<Image>();
	}

	void Start() {
		tu = GetComponent<TurretUnit>();
		TurretSelected[] ts = FindObjectsOfType<TurretSelected>();
		for(int i = 0; i < ts.Length; i++) {
			ts[i].IsSelected = false;
		}
	}

	void Update() {
		_damageText.fillAmount = (1f / 10f) * tu.Power;
		_radiusText.fillAmount = (1f / 10f) * tu.Radius;
		_rateText.fillAmount = (1f / 10f) * tu.Rate;
		if(_isSelected) {
			FindObjectOfType<SellTurret>().SetSellAmount(this.gameObject);		
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
		_isSelected = !_isSelected;
		if(_isSelected) {
			Instantiate(_showRadius, transform.position, Quaternion.identity);
			_showRadius.transform.localScale = new Vector2(1 * (tu.Radius * 2) ,1 * (tu.Radius * 2));
		} else {
			Destroy(_showRadius.gameObject);
		}
	}


}
