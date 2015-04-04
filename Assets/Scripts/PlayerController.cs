using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed = 200;
	public float xVelocity;
	public float yVelocity;
	public bool canJump = true;
	// Use this for initialization
	void Start () {
		
	}
	//GetCompononet<Rigidbody>().AddForce(asdf)
	// Update is called once per frame
	void FixedUpdate () {

		float horizontal = Input.GetAxis ("Horizontal");
		//float vertical;
		if (Input.GetKeyDown ("space") && canJump == true) {
			canJump = false;
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 7), ForceMode2D.Impulse);
		}


		
		Vector3 movement = new Vector3 (horizontal, 0, 0);

		
		GetComponent<Rigidbody2D> ().AddForce (movement * speed * Time.deltaTime);
		//xVelocity = horizontal * Time.deltaTime * speed;
		//yVelocity = vertical * Time.deltaTime * speed;
		//Vector3 position = new Vector3 (horizontal * Time.deltaTime * speed, vertical * Time.deltaTime * speed, 0);
		//transform.position = transform.position + position;
		
		if (transform.position.y < -10) {
			print ("YOU LOSE YOOOOOO");
			Destroy (this);
		}


	}
	
	void onTriggerEnter(Collider other){
		if (other.gameObject.tag == "Ground"){
			canJump = true;
		}
	//		
	}
}
