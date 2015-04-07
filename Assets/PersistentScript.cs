using UnityEngine;
using System.Collections;

public class PersistentScript : MonoBehaviour {
	public float deaths;
	// Use this for initialization
	void Start () {
		deaths = 0;
	}

	void Awake() {
		
		// Do not destroy this game object:
		
		DontDestroyOnLoad(this);
		
	} 
	// Update is called once per frame
	void Update () {
	
	}
}
