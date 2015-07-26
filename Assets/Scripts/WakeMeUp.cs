﻿using UnityEngine;
using System.Collections;

public class WakeMeUp : MonoBehaviour
{
	public GameObject Head;
    public GameObject Budzik;

    public float MoveDownSpeed = 0.15f;
    public float MoveUpSpeed = 0.3f;
    public float cooldown = 3;

	private GameObject _leftEye;
	private GameObject _rightEye;

	// positions from 0 to 1
	private float _leftEyePos;
	private float _rightEyePos;

	private Vector3 _leftEyeInitPos;
	private Vector3 _rightEyeInitPos;

	private const float _eyesHeight = 7.2f;

	// Use this for initialization
	private void Start()
	{
		// cache objects
		_leftEye = Head.transform.FindChild("LeftEye").gameObject;
		_rightEye = Head.transform.FindChild("RightEye").gameObject;

		// cache eyes init positions set via editor
		_leftEyeInitPos = _leftEye.transform.localPosition;
		_rightEyeInitPos = _rightEye.transform.localPosition;

		// clear state
		_leftEyePos = 0;
		_rightEyePos = 0;

        DayConfigurator(GameManager.Instance._currentDay);

        StartCoroutine("StartGame");
	}

    private void DayConfigurator(int dayNumber)
    {

    }

    public IEnumerator StartGame()
    {
        yield return new WaitForSeconds(cooldown);

		// Start timming
        Timming.Start(20.0f, onFinish);
        iTween.MoveTo(Head, Vector3.zero, 1.0f);
        Budzik.GetComponent<AudioSource>().volume = 0.4f;
	}

    void onFinish()
    {
        GameManager.Instance.GameOver();
    }

	// Update is called once per frame
	private void Update()
	{
		// check if update more
		if(_rightEyePos == 100)
			return;

		// check input
		if (Input.GetMouseButtonDown(0))
		{
            _leftEyePos += Time.deltaTime * MoveUpSpeed * (15 - _leftEyePos * 5);
		}
		if (Input.GetMouseButtonDown(1))
		{
            _rightEyePos += Time.deltaTime * MoveUpSpeed * (15 - _rightEyePos * 5);
		}
		
		// check game finished event
	    const float eyeIsUpWhen = 0.98f;
        if (_rightEyePos >= eyeIsUpWhen && _leftEyePos >= eyeIsUpWhen)
		{
			// Game won
            Budzik.GetComponent<AudioSource>().Stop();
			_rightEyePos = 100;
            GameManager.Instance.AddScore((1 - Timming.Position) * 1000.0f);
            GameManager.Instance.ShowStory(0);
           // GameManager.Instance.NextLevel();
		}
		else
		{
			// move eyes down
            _leftEyePos -= MoveDownSpeed * Time.deltaTime;
            _rightEyePos -= MoveDownSpeed * Time.deltaTime;

			// clamp eyes
			_leftEyePos = Mathf.Clamp01(_leftEyePos);
			_rightEyePos = Mathf.Clamp01(_rightEyePos);

			// move eyes
			_leftEye.transform.localPosition = _leftEyeInitPos + new Vector3(0, _leftEyePos * _eyesHeight, 0);
			_rightEye.transform.localPosition = _rightEyeInitPos + new Vector3(0, _rightEyePos * _eyesHeight, 0);
		}
	}
}
