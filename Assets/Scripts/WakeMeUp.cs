using UnityEngine;
using System.Collections;

public class WakeMeUp : MonoBehaviour
{
	public GameObject Head;
    public GameObject Budzik;
	public Sprite setSprite;
	public GameObject obj;
    public GameObject AnimBudzika;

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

    private bool _isRunning;

	public float animTime;
	// Use this for initialization
	private void Start()
	{
	    _isRunning = false;

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
       AnimBudzika.GetComponent<Animator>().enabled = false;

        StartCoroutine("StartGame");
	}

    private void DayConfigurator(int dayNumber)
    {
        MoveUpSpeed = MoveUpSpeed - (dayNumber * 0.02f);
    }

    public IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1);

        Budzik.GetComponent<AudioSource>().Play();
        AnimBudzika.GetComponent<Animator>().enabled = true;

        var myszka = Head.transform.FindChild("myszka");
        var pos = myszka.localPosition;
        myszka.localPosition = new Vector3(pos.x, -60, 0);

        yield return new WaitForSeconds(cooldown - 1);

		// Start timming
        iTween.MoveTo(Head, new Vector3(0, 53, 0), 1.0f);
        Budzik.GetComponent<AudioSource>().volume = 0.4f;

        while (myszka.localPosition.y < pos.y)
        {
            myszka.localPosition += new Vector3(0, 50 * Time.deltaTime, 0);
            yield return new WaitForSeconds(0.005f);
        }

        yield return new WaitForSeconds(1.0f);

        _isRunning = true;
        Timming.Start(20.0f, onFinish);

        yield return new WaitForSeconds(1.0f);
        myszka.gameObject.SetActive(false);
    }

    public IEnumerator WakeUpAnim()
    {
        Timming.Stop();

        GameObject.Find("budzik1").GetComponent<Animator>().enabled = false;
        GameObject.Find("budzik1").GetComponent<SpriteRenderer>().sprite = setSprite;
        iTween.MoveTo(Head, new Vector3(1500, 0, 0), 2.0f);

        //yield return new WaitForSeconds(animTime);

        GameObject.Find("room").GetComponent<Animator>().enabled = true;

        yield return new WaitForSeconds(0.9f);

        Debug.Log("kutas");
        //obj.SetActive(true);

        iTween.MoveTo(obj, new Vector3(140, -39, 0), 2.0f);
        obj.GetComponent<Animator>().SetTrigger("trigger");

        yield return new WaitForSeconds(animTime - 1f);

        //GameManager.Instance.NextLevel();
        GameManager.Instance.ShowStory(2);
    }

    void onFinish()
    {
        GameManager.Instance.GameOver();

    }

	// Update is called once per frame
	private void Update()
	{
		// check if update more
        if (_rightEyePos == 100 || !_isRunning)
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
			StartCoroutine("WakeUpAnim");
            
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
