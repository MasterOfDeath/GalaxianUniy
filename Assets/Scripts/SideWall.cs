using UnityEngine;
using System.Collections;

public class SideWall : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D hitInfo) {
		if (hitInfo.gameObject.tag == "Enemy") {
			if (gameObject.name == "leftWall"){
				if (EnemyControl.direction == -1){
					EnemyControl.moveLevel++;
				}
				EnemyControl.direction = 1;
			}
			else{
				if (EnemyControl.direction == 1){
					EnemyControl.moveLevel++;
				}
				EnemyControl.direction = -1;
			}

		}
	}
}
