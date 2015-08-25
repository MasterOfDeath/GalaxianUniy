using UnityEngine;
using System.Collections;

public class BulletControl : MonoBehaviour {
	
	private Rigidbody2D rbody;
	

	void Start () {
		rbody = GetComponent<Rigidbody2D>();

		rbody.velocity = Vector2.up * 10;
	}
}
