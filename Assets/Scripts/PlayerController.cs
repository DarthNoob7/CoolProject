using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed = 1000;
	public float xVelocity;
	public float yVelocity;
	// Use this for initialization
	void Start () {
		
	}
	//GetCompononet<Rigidbody>().AddForce(asdf)
	// Update is called once per frame
	void FixedUpdate () {
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical;
		if (yVelocity == 0) {
			vertical = Input.GetAxis ("Vertical");
		} else {
			vertical = 0;
		}
		xVelocity = horizontal;
		yVelocity = vertical;
		
		Vector3 movement = new Vector3 (horizontal, vertical, 0);
		
		
		GetComponent<Rigidbody2D> ().AddForce (movement * speed * Time.deltaTime);
		//xVelocity = horizontal * Time.deltaTime * speed;
		//yVelocity = vertical * Time.deltaTime * speed;
		//Vector3 position = new Vector3 (horizontal * Time.deltaTime * speed, vertical * Time.deltaTime * speed, 0);
		//transform.position = transform.position + position;
		
		if (transform.position.x < -30) {
			transform.position = new Vector3(10, 0, 0);
		}
		

	}
	
	//void onTriggerEnter(Collider other){
	//	if (other.gameObject.tag == "")
	//		;
	//}
}
