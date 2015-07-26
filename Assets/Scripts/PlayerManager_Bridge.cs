﻿using UnityEngine;
using System.Collections;

public class PlayerManager_Bridge : MonoBehaviour
{
    public float startTimeToFall;
    public float angleToFall;

    public float timeToFall;
    private bool falling;
    private bool gameOver = false;
    private Quaternion rotation;
    public float kupa;

    public bool Faiiling
    {
        get { return falling; }
    }

    // Use this for initialization
    private void Start()
    {
        Timming.Start(12, onFinish);
    }

    private void onFinish()
    {
        GameManager.Instance.NextLevel();
    }

    // Update is called once per frame
    private void Update()
    {
        //Mathf.PingPong(Time.time,kupa);
        if (timeToFall > startTimeToFall)
        {
            // Przegrana
            gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            gameOver = true;
            GameManager.Instance.GameOver();
        }
        else if (falling && !gameOver)
        {
            timeToFall += Time.deltaTime;
        }
        else if (gameOver)
        {
            gameObject.transform.rotation = Quaternion.Euler(0f, 0f, angleToFall);
        }

        gameObject.transform.rotation = Quaternion.Euler(0f, 0f, (timeToFall / startTimeToFall) * angleToFall * (Mathf.PingPong(Time.time, 2) - 1));
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
