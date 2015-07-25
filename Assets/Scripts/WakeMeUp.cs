﻿using UnityEngine;
using System.Collections;

public class WakeMeUp : MonoBehaviour
{
	//public GameObject Canvas;
	public GameObject Head;

	public float LeftEyeSpeed = 0.09f;
	public float RightEyeSpeed = 0.15f;

    public float cooldown;

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

        StartCoroutine("StartGame");
	}

    public IEnumerator StartGame()
    {
        yield return new WaitForSeconds(cooldown);

		// Start timming
		GameManager.Instance.StartMiniGame(20, -1, 0, 0);
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
			_leftEyePos += Time.deltaTime * LeftEyeSpeed * (21 - _leftEyePos * 2.8f);
		}
		if (Input.GetMouseButtonDown(1))
		{
			_rightEyePos += Time.deltaTime * RightEyeSpeed * (20.4f - _rightEyePos * 2.4f);
		}
		
		// check game finished event
		if (_rightEyePos >= 1.0f && _leftEyePos >= 1.0f)
		{
			// Game won
			_rightEyePos = 100;
            GameManager.Instance.AddScore((1 - Timming.Instance.Position) * 1000.0f);
            GameManager.Instance.NextLevel();
		}
		else
		{
			// move eyes down
			if (_leftEyePos < 1.0f)
				_leftEyePos -= LeftEyeSpeed * Time.deltaTime;
			if (_rightEyePos < 1.0f)
				_rightEyePos -= RightEyeSpeed * Time.deltaTime;

			// clamp eyes
			_leftEyePos = Mathf.Clamp01(_leftEyePos);
			_rightEyePos = Mathf.Clamp01(_rightEyePos);

			// move eyes
			_leftEye.transform.localPosition = _leftEyeInitPos + new Vector3(0, _leftEyePos * _eyesHeight, 0);
			_rightEye.transform.localPosition = _rightEyeInitPos + new Vector3(0, _rightEyePos * _eyesHeight, 0);
		}
	}
}
