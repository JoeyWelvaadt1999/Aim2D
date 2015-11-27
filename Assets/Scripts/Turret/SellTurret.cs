using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SellTurret : MonoBehaviour {
	[SerializeField]private Text _sellText;
	private float _sellAmount;
	private PlayerResources _pr;

	void Start() {
		_pr = FindObjectOfType<PlayerResources>();
	}

	public void Sell () {
		TurretSelected[] wTurrets = GameObject.FindObjectsOfType<TurretSelected>();
		for (int i = 0; i < wTurrets.Length; i++) {
			if(wTurrets[i].IsSelected == true) {
				_pr.AddResources(_sellAmount);
				Destroy(wTurrets[i].gameObject);
				_sellText.text = "";
			}
		}
	}

	public void SetSellAmount(GameObject go) {
		TurretUnit tu = go.GetComponent<TurretUnit>();
		_sellAmount = 20 * tu.Power;
		_sellText.text = _sellAmount.ToString() + "$";
	}
}
