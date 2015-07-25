using UnityEngine;
using System.Collections;

public class DancerMovement : MonoBehaviour {

	public float movement;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void move(){
		transform.position += new Vector3(movement,0,0);
	}
}
