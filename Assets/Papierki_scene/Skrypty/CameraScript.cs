using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//Debug.Log("Odpalam corutyne");
		//StartCoroutine (GameObject.Find("tablica").GetComponent<TablicaScript>().StartMoving());
		StartCoroutine (GameObject.Find ("Player").GetComponent<Player_Script> ().AnimatePlayer ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
