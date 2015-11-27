using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	[SerializeField]private Text _waveText;
	[SerializeField]private GameObject _enemy;
	[SerializeField]private AudioClip _startWave;
	private float _timer = 0.0f;
	private float _spawnEnemy;
	private float _secondsToWait = 90f;
	private int _totalSpawnedEnemies;
	private int _wave = 1;
	private int _toSpawnEnemies = 5;
	CameraShake _cs;
	AudioSource _as;

	public int Wave {
		get {
			return _wave;
		}
	}

	void Awake() {
		_cs = FindObjectOfType<CameraShake>();
		_as = GetComponent<AudioSource>();
	}

	void Update() {
		_waveText.text = _wave.ToString();
		_spawnEnemy += Time.deltaTime;
		_timer += Time.deltaTime;
		float seconds = Mathf.Floor(_timer% _secondsToWait + 1);

		if(_spawnEnemy >= 2 && _totalSpawnedEnemies < _toSpawnEnemies) {
			SpawnEnemy();
			_spawnEnemy = 0;
		} 

		if(seconds >= _secondsToWait) {
			_wave++;
			SetWave();
			_timer = 0;
		}
	}

	void SpawnEnemy(){
		Instantiate(_enemy, transform.position, Quaternion.identity);
		_totalSpawnedEnemies++;
//		_cs.CanShake = true;
	}

	void SetWave() {
		_totalSpawnedEnemies = 0;
		_toSpawnEnemies = Mathf.RoundToInt(0 + (5 * (_wave + Random.Range(0.0f, 1.0f))));
		_secondsToWait = 90 + 10 * _wave;
		_as.PlayOneShot(_startWave);
	}
}
