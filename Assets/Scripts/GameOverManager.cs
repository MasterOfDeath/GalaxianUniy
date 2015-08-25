using UnityEngine;
using System.Collections;

public class GameOverManager : MonoBehaviour {

	public PlaneControl plane;
	public float restartDelay = 3f;
	
	
	Animator anim;
	float restartTimer;

	bool doItOnlyOneTime = true;

	void Awake ()
	{
		anim = GetComponent <Animator> ();
	}
	
	
	void Update ()
	{
		if(plane == null)
		{
			if (doItOnlyOneTime) {
				//Издевательский звук
				GetComponent<AudioSource>().Play();
				anim.SetTrigger ("GameOver");
				
				doItOnlyOneTime = false;
			}





			GameSetup.gameOver = true;
			
			restartTimer += Time.deltaTime;

			if(restartTimer >= restartDelay)
			{
				Application.LoadLevel(Application.loadedLevel);
				doItOnlyOneTime = true;
			}
		}
	}
}
