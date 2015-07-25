using UnityEngine;
using System.Collections;

public class PlayerManager_Bridge : MonoBehaviour {
    
    public float startTimeToFall;
    public float angleToFall;

    public float timeToFall;
    private bool falling;
    private bool gameOver = false;
    private Quaternion rotation;
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
        if (timeToFall > startTimeToFall)
        {
            //Przegrana
            gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            gameOver = true;
        }
        else if (falling && !gameOver)
        {
            timeToFall += Time.deltaTime;
            gameObject.transform.rotation = Quaternion.Euler(0f, 0f, (timeToFall / startTimeToFall) * angleToFall);
        }
        else if (gameOver)
        {
            gameObject.transform.rotation = Quaternion.Euler(0f, 0f, angleToFall);
        }
    }
            

    public void StartFalling()
    {
        falling = true;
    }

    public void StopFalling()
    {
        falling = false;
    }

}
