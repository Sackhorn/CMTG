using UnityEngine;
using System.Collections;

public class ArrowMovement : MonoBehaviour {

	public Rigidbody2D _rigidbody;
	public float _speed;
	// Use this for initialization
	void Start () {
		_rigidbody = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		_rigidbody.velocity = new Vector2(_speed,0);
	}
}
