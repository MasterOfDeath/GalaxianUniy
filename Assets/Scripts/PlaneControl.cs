using UnityEngine;
using System.Collections;

public class PlaneControl : MonoBehaviour {

	public KeyCode moveLeft;
	public KeyCode moveRight;
	
	public int speed = 10;

	public GameObject bullet;

	private Rigidbody2D rbody;
	private float planeH;
	private float planeHalfW;
	
	void Start () {
		rbody = GetComponent<Rigidbody2D>();
		planeH = GetComponent<PolygonCollider2D>().bounds.size.y;
		planeHalfW = GetComponent<PolygonCollider2D>().bounds.size.x / 2;

		InvokeRepeating ("Fire", 1, 0.7F);
	}
	

	void Update () {
		if (Input.GetKey (moveLeft)) {
			if (transform.position.x > (-1 * GameSetup.scrHalfW + planeHalfW)) {
				rbody.velocity = Vector2.left * speed;
			}
			else {
				rbody.velocity = Vector2.zero;
			}
		} else if (Input.GetKey (moveRight)) {
			if (transform.position.x < (GameSetup.scrHalfW - planeHalfW)) {
				rbody.velocity = Vector2.right * speed;
			}
			else {
				rbody.velocity = Vector2.zero;
			}
		} else {
			rbody.velocity = Vector2.zero;
		}
	}


	void Fire(){
		float posY = transform.position.y + planeH / 2;
		float posX = transform.position.x;

		GameObject curBullet = (GameObject)Instantiate (bullet,new Vector3(posX,posY,0),new Quaternion());
		curBullet.SetActive (true);

		GetComponent<AudioSource> ().Play ();
	}
}
