using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameSetup : MonoBehaviour {

	public BoxCollider2D topWall;
	public BoxCollider2D bottomWall;
	public BoxCollider2D leftWall;
	public BoxCollider2D rightWall;

	public Camera mainCam;
	public static float scrH;
	public static float scrW;
	public static float scrHalfH;
	public static float scrHalfW;
	private float topPadding = 1.2f;

	public GameObject enemy;
	public float betweenEnemy = 0.30f;
	public static float enemySize = 0.64f;

	public static int playerScore = 0;
	public static int enemyCount = 0;

	public GameObject scoreText;
	public LevelManager levelManager;

	public static int level = 1;
	public static bool gameOver = true;

	void Start () {
		if (gameOver) {
			level = 1;
			playerScore = 0;
			levelManager.showLevel1();
			gameOver = false;
			//Восстанавливаем параметры сложности
			EnemyControl.chanceEnemyFire = 20;
			EnemyControl.moveSpeed = 0.8f;
		}

		PrintScore ();

		//Параметры экрана
		scrHalfH = mainCam.orthographicSize;
		scrHalfW = scrHalfH * Screen.width / Screen.height;

		scrH = scrHalfH * 2;
		scrW = scrHalfW * 2;

		//Расстановка стен
		topWall.size = new Vector2(scrW, 1f);
		topWall.offset = new Vector2(0f, scrHalfH - topPadding / 2 + 0.5f);

		bottomWall.size = new Vector2(scrW, 1f);
		bottomWall.offset = new Vector2(0f, -1 * scrHalfH - 0.5f);

		leftWall.size = new Vector2(1f, scrH);
		leftWall.offset = new Vector2(-1 * scrHalfW - 0.5f, 0f);
		
		rightWall.size = new Vector2(1f, scrH);
		rightWall.offset = new Vector2(scrHalfW + 0.5f, 0f);

		//Расстанока вражин
		EnemySetup ();
	}


	void Update() {
		if (Input.GetKey (KeyCode.Escape)) {
			Application.LoadLevel(0);
		}
	}


	void EnemySetup(){
		enemyCount = 0;
		Vector3 posEnemy;
		float posXEnemyStart = -1 * (betweenEnemy / 2 + enemySize / 2) - 3 * (betweenEnemy + enemySize);

		for (int i = 0; i < 4; i++) {
			float y = scrHalfH - topPadding - (i * (enemySize + betweenEnemy));
			posEnemy = new Vector3 (posXEnemyStart, y, 0f);

			for (int j = 0; j < 8; j++) {
				GameObject curEnemy = (GameObject)Instantiate (enemy, posEnemy, new Quaternion ());
				curEnemy.SetActive (true);

				enemyCount++;

				posEnemy.x += (betweenEnemy + enemySize);
			}
		}
	}

	//Увеличиваем очки, выводим на экран
	public void IncrScore(int score) {
		playerScore += score;
		PrintScore ();
	}


	//Вывод очков
	void PrintScore() {
		scoreText.GetComponent<Text>().text = "Your Score: " + playerScore;
	}



}
