using UnityEngine;
using System.Collections;

public class WakeMeUp : MonoBehaviour
{
	//public GameObject Canvas;
	public GameObject Head;

	public float LeftEyeSpeed = 0.09f;
	public float RightEyeSpeed = 0.15f;

	private GameObject _leftEye;
	private GameObject _rightEye;

	// positions from 0 to 1
	private float _leftEyePos;
	private float _rightEyePos;

	private Vector3 _leftEyeInitPos;
	private Vector3 _rightEyeInitPos;

	// Use this for initialization
	void Start ()
	{
		// center head
	   var headSprite = Head.GetComponent<SpriteRenderer>();
		var headSpriteSize = headSprite.sprite.textureRect;
		Debug.LogWarning(headSpriteSize);
		Debug.LogWarning(Screen.width);
		Head.transform.localScale = new Vector3(Screen.width / headSpriteSize.width, Screen.height / headSpriteSize.height, 1);



	   // transform.localScale = new Vector3(1, 1, 1);

	   float width = headSprite.sprite.bounds.size.x;
		float height = headSprite.sprite.bounds.size.y;


		float worldScreenHeight = Camera.main.orthographicSize * 2f;
		float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

		Vector3 xWidth = transform.localScale;
		xWidth.x = worldScreenWidth / width * 1.1f;
		headSprite.transform.localScale = new Vector3(xWidth.x, xWidth.x);

		// cache objects
        _leftEye = Head.transform.FindChild("LeftEye").gameObject;
        _rightEye = Head.transform.FindChild("RightEye").gameObject;

		// cache eyes init positions set via editor
		_leftEyeInitPos = _leftEye.transform.position;
		_rightEyeInitPos = _rightEye.transform.position;

		// clear state
		_leftEyePos = 0;
		_rightEyePos = 0;
	}
	
	// Update is called once per frame
	private void Update()
	{
		// check if update more
		if(_rightEyePos == 100)
			return;

		// check input
		if (Input.GetKeyDown(KeyCode.A))
		{
			_leftEyePos += Time.deltaTime * LeftEyeSpeed * (15 - _leftEyePos * 3);
		}
		if (Input.GetKeyDown(KeyCode.D))
		{
			_rightEyePos += Time.deltaTime * RightEyeSpeed * (14 - _rightEyePos * 3);
		}

		// cheating
		if (Input.GetKeyDown(KeyCode.RightAlt))
		{
			_rightEyePos = _leftEyePos = 1;
		}
		
		// check game finished event
		if (_rightEyePos >= 1.0f && _leftEyePos >= 1.0f)
		{
			// Game won
			_rightEyePos = 100;
			Fade.FadeThisSit("testScene2");
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
			_leftEye.transform.position = _leftEyeInitPos + new Vector3(0, _leftEyePos * 4, 0);
			_rightEye.transform.position = _rightEyeInitPos + new Vector3(0, _rightEyePos * 4, 0);
		}
	}
}
