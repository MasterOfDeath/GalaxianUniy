using UnityEngine;
using System.Collections;

public class WallControl : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D hitInfo) {
		if (hitInfo.gameObject.tag == "Bullet")
			Destroy(hitInfo.gameObject);

		if (hitInfo.gameObject.tag == "EnemyBullet")
			Destroy(hitInfo.gameObject);
	}
}
