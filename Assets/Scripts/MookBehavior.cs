using UnityEngine;
using System.Collections;

public class MookBehavior : MonoBehaviour {
	public float speed = 2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = transform.position + new Vector3(speed * Time.deltaTime, 0, 0);
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Zone") {
			speed = -speed;
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
			//transform.rotation = new Vector3(0, 180, 0);
		}

		
	}
}
