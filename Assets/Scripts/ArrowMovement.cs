using System;
using UnityEngine;
using System.Collections;

public class ArrowMovement : MonoBehaviour
{

    //public Rigidbody2D _rigidbody;

    // Use this for initialization
    private void Start()
    {
       // _rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        //_rigidbody.velocity = new Vector2(_speed, 0);
        
        gameObject.transform.position -= new Vector3(Time.deltaTime * 60, 0, 0);
    }
}
