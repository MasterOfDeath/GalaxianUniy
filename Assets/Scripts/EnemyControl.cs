using UnityEngine;
using System.Collections;

public class EnemyControl : MonoBehaviour {

	public static int direction = -1;
	public static int moveLevel = 0;
	private float startY = 1;

	//Параметры сложности
	public static int chanceEnemyFire = 20;
	public static float moveSpeed = 0.8f;
	private static int curChanceEnemyFire = 0;

	public PlaneControl plane;
	public GameObject emenyBullet;
	public GameSetup GM;

	private float enemyHalfH;

	void Start () {
		curChanceEnemyFire = 0;
		startY = transform.position.y;
		moveLevel = 0;

		enemyHalfH = GetComponent<Collider2D>().bounds.size.y / 2;

		InvokeRepeating ("Move", 1f, 1f);
		InvokeRepeating ("EnemyFire", Random.Range(0.9f, 1.3f), 2f);
	}
	

	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D hitInfo) {
		if (hitInfo.gameObject.tag == "Bullet") {
			Destroy (hitInfo.gameObject);
			Destroy (gameObject);

			//Убили вражину
			GameSetup.enemyCount--;

			//Увеличиваем очки
			GM.IncrScore(100 / (moveLevel + 1));

			//Увеличиваем вероятность выстрела, т.к. врагов всё меньше
			if (EnemyControl.chanceEnemyFire > 0) {
				if (GameSetup.enemyCount > 0) {
					curChanceEnemyFire = 32 / GameSetup.enemyCount;
				}
			}
		}

		if (hitInfo.gameObject.tag == "Player") {
			Destroy (hitInfo.gameObject);
		}
	}

	void Move() {
		Vector3 pos = transform.position;
		pos.x += direction * 0.8f;
		pos.y = startY - moveLevel * GameSetup.enemySize;
		transform.position = pos;
	}

	void EnemyFire() {
		if (plane != null) {
			if (Random.Range(0, chanceEnemyFire - curChanceEnemyFire) == 0) {
				float posY = transform.position.y - enemyHalfH;
				float posX = transform.position.x;
				
				GameObject curEnemyBullet = (GameObject)Instantiate (emenyBullet,new Vector3(posX,posY,0),new Quaternion());
				curEnemyBullet.SetActive (true);

				GetComponent<AudioSource>().Play();
			}
		}
	}
}
