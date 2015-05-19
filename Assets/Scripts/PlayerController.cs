//made by Carson Hu, Isabel Zhang, Brian Wong

using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed = 100;
	public float theX;
	public float theY;
	public float jumps = 1;
	//public GameObject persistentGameObject;
	//public MonoBehaviour persistentScript;
	// Use this for initialization
	void Start () {
		//persistentGameObject = GameObject.Find ("Persisent Object");
		//persistentScript = persistentGameObject.GetComponent (persistentScript);
		theX = transform.position.x;
		theY = transform.position.y;
	}
	//GetCompononet<Rigidbody>().AddForce(asdf)
	// Update is called once per frame
	void FixedUpdate () {

		if (this.gameObject != null) {
		/*	if (Input.GetKeyDown ("R")){
				transform.position= new Vector2(theX,theY);
				GetComponent<Rigidbody2D> ().velocity = new Vector2(0,0);
			}*/
			if (Application.loadedLevelName == "Main") {
				print (jumps);
				float horizontal = Input.GetAxis ("Horizontal");
				if (Input.GetKeyDown ("up") && jumps > 0) {
					GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, 5), ForceMode2D.Impulse);
					jumps--;
				}else if(Input.GetKeyDown (KeyCode.R)){
					transform.position= new Vector2(theX,theY);
					GetComponent<Rigidbody2D> ().velocity = new Vector2(0,0);
				}

		
				Vector3 movement = new Vector3 (horizontal, 0, 0);

			
				GetComponent<Rigidbody2D> ().AddForce (movement * speed * Time.deltaTime);
				//xVelocity = horizontal * Time.deltaTime * speed;
				//yVelocity = vertical * Time.deltaTime * speed;
				//Vector3 position = new Vector3 (horizontal * Time.deltaTime * speed, vertical * Time.deltaTime * speed, 0);
				//transform.position = transform.position + position;
				destroyHero (-10, 60);
			}else if(Application.loadedLevelName == "Level2") {
				if(Input.GetKeyDown (KeyCode.R)){
					transform.position= new Vector2(theX,theY);
					GetComponent<Rigidbody2D> ().velocity = new Vector2(0,0);
				}
				float horizontal = Input.GetAxis ("Horizontal");
				float vertical = Input.GetAxis ("Vertical");
				Vector3 movement = new Vector3 (horizontal, vertical, 0);
				
				GetComponent<Rigidbody2D> ().AddForce (movement * speed * Time.deltaTime);
				destroyHero (-100, 100);
			}else if(Application.loadedLevelName == "Level3"){



				float horizontal = Input.GetAxis ("Horizontal");
				if (Input.GetKeyDown ("down") && jumps > 0) {

					GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, 5), ForceMode2D.Impulse);
					jumps--;
				}
				if(Input.GetKeyDown (KeyCode.R)){
					transform.position= new Vector2(theX,theY);
					GetComponent<Rigidbody2D> ().velocity = new Vector2(0,0);
				}

				Vector3 movemen = new Vector3 ( -1 * horizontal, 0, 0);
				
				
				GetComponent<Rigidbody2D> ().AddForce (movemen * speed * Time.deltaTime);
				destroyHero (-50, 50);
			}else if(Application.loadedLevelName == "endScreen" || Application.loadedLevelName == "endScreen2"){
		
			}

		}
	}	
	

	void destroyHero(float a, float b){
		if (transform.position.y < a || transform.position.y > b) {
			print ("YOU LOSE YOOOOOO");
			transform.position= new Vector2(theX,theY);
			GetComponent<Rigidbody2D> ().velocity = new Vector2(0,0);
			if(this.gameObject.tag == "Hero"){
				//persistentScript.deaths++;
				//print (persistentScript.deaths);
			}
		}

	}

	void onTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Ground"){
			print ("PLEASE WORK"); //jumps are whacky - this is intentional
			jumps++;
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Ground") {
			jumps = 1;
			print ("AHHHH"); //test
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
		if (other.gameObject.tag == "Door" && Application.loadedLevelName == "Main") {
			winThings("Level2");
		}
		if (other.gameObject.tag == "Door" && Application.loadedLevelName == "Level2") {
			winThings ("Level3");
		}
		if (other.gameObject.tag == "Door" && Application.loadedLevelName == "Level3") {
			if(this.gameObject.tag == "clone"){
				winThings ("endScreen2");
			}else{
				winThings ("endScreen");
			}
		}

	}

	void winThings(string nextLevel){
		print ("heey we won");
		Application.LoadLevel (nextLevel);

	}

	void OnCollisionStay2D(Collision2D other)
	{

	}


}
