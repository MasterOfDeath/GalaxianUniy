using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelManager : MonoBehaviour {

	Animator anim;
	public float restartDelay = 2f;
	float restartTimer;

	public GameObject levelText;

	bool doItOnlyOneTime = true;


	void Awake ()
	{
		anim = GetComponent <Animator> ();
	}


	void Update ()
	{
		if(GameSetup.enemyCount == 0)
		{
			if (doItOnlyOneTime) {
				GameSetup.level++;
				SetLevelText();
				anim.SetTrigger ("NextLevel");

				//С каждым уровнем вражины стреляют всё чаще
				if (EnemyControl.chanceEnemyFire > 5) {
					EnemyControl.chanceEnemyFire -= 2;
				}
				//И двигаются всё быстрее
				if (EnemyControl.moveSpeed < 2.5f) {
					EnemyControl.moveSpeed += 0.4f;
				}

				doItOnlyOneTime = false;
			}

		

			restartTimer += Time.deltaTime;
			
			if(restartTimer >= restartDelay)
			{
				Application.LoadLevel(Application.loadedLevel);
				doItOnlyOneTime = true;
			}
		}
	}

	public void showLevel1() {
		SetLevelText();
		anim.SetTrigger ("NextLevel");
	}


	//Обновляем текст уровня
	void SetLevelText () {
		levelText.GetComponent<Text>().text = "Level: " + GameSetup.level;
	}
}
