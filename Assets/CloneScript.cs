using UnityEngine;
using System.Collections;

public class CloneScript : MonoBehaviour {
	public Object[] clones;
	public GameObject Hero;
	public float horiForce;
	public float vertiForce;
	// Use this for initialization
	void Start () {
		if (clones == null) {
			clones = GameObject.FindGameObjectsWithTag("clone");
		}
	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject clone in clones) {
			clone.GetComponent<Rigidbody2D> ().velocity = new Vector2(Hero.GetComponent<Rigidbody2D> ().velocity.x, Hero.GetComponent<Rigidbody2D> ().velocity.y);
		}
		if(Input.GetKeyDown (KeyCode.R)){
			foreach (GameObject clone in clones) {
				clone.transform.position = Hero.transform.position;
				clone.GetComponent<Rigidbody2D> ().velocity = new Vector2(0,0);
			}
		}
	}
}
