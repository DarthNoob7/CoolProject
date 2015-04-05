using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed = 200;
	public float xVelocity;
	public float yVelocity;
	public float jumps = 1;
	// Use this for initialization
	void Start () {
		
	}
	//GetCompononet<Rigidbody>().AddForce(asdf)
	// Update is called once per frame
	void FixedUpdate () {
		print (jumps);
		float horizontal = Input.GetAxis ("Horizontal");
		if (Input.GetKeyDown("space") && jumps > 0) {
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
			jumps--;
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
	
	void onTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Ground"){
			print ("PLEASE WORK");
			jumps++;
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Ground") {
			jumps = 1;
			print ("AHHHH");
		}

	}
	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == "Ground") {
			jumps = 1;
			print ("AHHHHHH");
		}
		if (other.gameObject.tag == "Enemy") {
		
		}
	}

	void OnCollisionStay2D(Collision2D other)
	{

	}


}
