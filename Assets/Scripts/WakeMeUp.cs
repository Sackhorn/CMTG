using UnityEngine;
using System.Collections;

public class WakeMeUp : MonoBehaviour
{
    public GameObject Canvas;

    public float LeftEyeSpeed = 0.9f;
    public float RightEyeSpeed = 1.05f;

    private GameObject _leftEye;
    private GameObject _rightEye;

    // positions from 0 to 1
    private float _leftEyePos;
    private float _rightEyePos;

    private float _leftEyeInitPos;
    private float _rightEyeInitPos;

	// Use this for initialization
	void Start ()
	{
		// center head
	   /* var headSprite = Head.GetComponent<SpriteRenderer>();
	    var headSpriteSize = headSprite.sprite.textureRect;
        Debug.LogWarning(headSpriteSize);
        Debug.LogWarning(Screen.width);
        Head.transform.localScale = new Vector3(Screen.width / headSpriteSize.width, Screen.height / headSpriteSize.height, 1);*/



       // transform.localScale = new Vector3(1, 1, 1);

       /* float width = headSprite.sprite.bounds.size.x;
        float height = headSprite.sprite.bounds.size.y;


        float worldScreenHeight = Camera.main.orthographicSize * 2f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        Vector3 xWidth = transform.localScale;
        xWidth.x = worldScreenWidth / width;
        headSprite.transform.localScale = new Vector3(xWidth, );
        //transform.localScale.x = worldScreenWidth / width;
      //  Vector3 yHeight = transform.localScale;
       // yHeight.y = worldScreenHeight / height;
       // headSprite.transform.localScale = yHeight;
//        headSprite.transform.localScale.y = worldScreenHeight / height;*/

        // cache objects
	    _leftEye = Canvas.transform.FindChild("LeftEye").gameObject;
        _rightEye = Canvas.transform.FindChild("RightEye").gameObject;

        // cache eyes init positions set via editor
        _leftEyeInitPos = _leftEye

        // clear state
	    _leftEyePos = 0;
	    _rightEyePos = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
        // check input
	    if (Input.GetKeyDown(KeyCode.A))
	    {
	        _leftEyePos += Time.deltaTime * 3;
	    }
	    if (Input.GetKeyDown(KeyCode.D))
	    {
            _rightEyePos += Time.deltaTime * 3;
	    }

        // check game finished event
	    if (_rightEyePos >= 1.0f && _leftEyePos >= 1.0f)
	    {
            // Game won
	        Debug.LogWarning("Win");
	    }

        // move eyes down
	    _leftEyePos = Mathf.Clamp01(_leftEyePos - LeftEyeSpeed * Time.deltaTime);
	    _rightEyePos = Mathf.Clamp01(_rightEyePos - RightEyeSpeed * Time.deltaTime);

        // move eyes
        _rightEye.transform
	}
}
