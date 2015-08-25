using UnityEngine;
using System.Collections;

public class EnemyBulletControl : MonoBehaviour {

	public PlaneControl plane;

	void Start() {
		Rigidbody2D rbody = GetComponent<Rigidbody2D> ();
		rbody.velocity = plane.transform.position;
	}
	

	void OnTriggerEnter2D (Collider2D hitInfo) {		
		if (hitInfo.gameObject.tag == "Player") {
			Destroy (hitInfo.gameObject);
		}
	}


}
