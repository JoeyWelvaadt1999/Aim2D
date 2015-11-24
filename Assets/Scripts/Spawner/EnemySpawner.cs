using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	[SerializeField]private GameObject enemy;
	private float _timer = 0.0f;
	private float _spawnEnemy;
	private int _totalSpawnedEnemies;
	private int _wave = 1;
	private int _toSpawnEnemies = 10;

	public int Wave {
		get {
			return _wave;
		}
	}

	void Update() {
		_spawnEnemy += Time.deltaTime;
		_timer += Time.deltaTime;
		float seconds = Mathf.Floor(_timer%60);

		if(_spawnEnemy >= 2 && _totalSpawnedEnemies < _toSpawnEnemies) {
			SpawnEnemy();
			_spawnEnemy = 0;
		} 

		if(seconds > 90) {
			_wave++;
			SetWave();
			_timer = 0;
		}

		Debug.Log(seconds);
	}

	void SpawnEnemy(){
		Instantiate(enemy, transform.position, Quaternion.identity);
		_totalSpawnedEnemies++;
	}

	void SetWave() {
		_totalSpawnedEnemies = 0;
		_toSpawnEnemies = Mathf.RoundToInt(10 + (5 * (_wave + Random.Range(0.0f, 1.0f))));
	}
}
