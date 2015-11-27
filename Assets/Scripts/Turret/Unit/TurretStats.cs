using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TurretStats : MonoBehaviour {
	[SerializeField]private Image _powerImage;
	[SerializeField]private Image _radiusImage;
	[SerializeField]private Image _rateImage;
	public void SetStats(float power, float radius, float rate) {
		_powerImage.fillAmount = (1f / 10f) * power;
		_radiusImage.fillAmount = (1f / 10f) * radius;
		_rateImage.fillAmount = (1f / 10f) * rate;
	}
}
