using UnityEngine;
using System.Collections;

public class OnClickController : MonoBehaviour {

	public void LoadPlayLevel() {
		Application.LoadLevel (1);
	}

	public void Exit() {
		Application.Quit() ;
	}

}
