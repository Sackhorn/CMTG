using UnityEngine;
using System.Collections;

public class WakeMeUp : MonoBehaviour
{
	public GameObject Head;
	public GameObject Budzik;
	public Sprite setSprite;
	public GameObject obj;
	public GameObject AnimBudzika;
    public GameObject timeBar;
    public float gameTime = 20.0f;


    private float timmerWidth;
    private bool isLeftEyeUp;
    private bool isRightEyeUp;

    private EyeColliderScript leftEyeScript;
    private EyeColliderScript rightEyeScript;

    private Rigidbody2D leftRigidBody;
    private Rigidbody2D rightRigidBody;

	private GameObject _leftEye;
	private GameObject _rightEye;

	private bool _isRunning;

	public float animTime;
    private bool gameWon;

    // Use this for initialization
    private void Start()
	{
        gameWon = false;
        isLeftEyeUp = false;
        isRightEyeUp = false;
		_isRunning = false;
        timeBar.GetComponent<UnityEngine.UI.Image>().canvasRenderer.SetAlpha(0f);
        var timeBarRectTrans = timeBar.transform as RectTransform;
        timmerWidth = timeBarRectTrans.sizeDelta.x;
        // cache objects
        _leftEye = Head.transform.FindChild("LeftEye").gameObject;
		_rightEye = Head.transform.FindChild("RightEye").gameObject;

        //cache eye collider scripts
        rightEyeScript = Head.transform.FindChild("RightTopCollider").GetComponent<EyeColliderScript>();
        leftEyeScript = Head.transform.FindChild("LeftTopCollider").GetComponent<EyeColliderScript>();

        //get eye rigidBodies2D
        rightRigidBody = Head.transform.FindChild("RightEye").GetComponent<Rigidbody2D>();
        leftRigidBody = Head.transform.FindChild("LeftEye").GetComponent<Rigidbody2D>();

		//DayConfigurator(GameManager.Instance._currentDay);
	   AnimBudzika.GetComponent<Animator>().enabled = false;

		StartCoroutine("StartGame");
	}

	private void DayConfigurator(int dayNumber)
	{
		//MoveUpSpeed = MoveUpSpeed - (dayNumber * 0.02f);
	}

	public IEnumerator StartGame()
	{
		yield return new WaitForSeconds(1);

		Budzik.GetComponent<AudioSource>().Play();
		AnimBudzika.GetComponent<Animator>().enabled = true;

		var myszka = Head.transform.FindChild("myszka");
		var pos = myszka.localPosition;
		myszka.localPosition = new Vector3(pos.x, -60, 0);

		yield return new WaitForSeconds(2);

		// Start timming
		iTween.MoveTo(Head, new Vector3(0, 53, 0), 1.0f);
		Budzik.GetComponent<AudioSource>().volume = 0.4f;

		while (myszka.localPosition.y < pos.y)
		{
			myszka.localPosition += new Vector3(0, 50 * Time.deltaTime, 0);
			yield return new WaitForSeconds(0.005f);
		}
        timeBar.GetComponent<UnityEngine.UI.Image>().canvasRenderer.SetAlpha(1f);
        yield return new WaitForSeconds(1.0f);

		_isRunning = true;
		Timming.Start(gameTime, onFinish);

		yield return new WaitForSeconds(1.0f);
        StartCoroutine("slideMouseIconOutOfTheScreeen");
	}

    public IEnumerator slideMouseIconOutOfTheScreeen()
    {
        var myszka = Head.transform.FindChild("myszka");
        iTween.MoveBy(myszka.gameObject, new Vector3(0, -1000), 10.0f);
        yield return null;
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
        
        // check if to update
        if (!_isRunning || gameWon)
			return;

        //Update time
        var timeBarRectTrans = timeBar.transform as RectTransform;
        timeBarRectTrans.sizeDelta = new Vector2(timmerWidth*Timming.Position,timeBarRectTrans.sizeDelta.y);
        // Timming.Position*

        //check eyes states
        isRightEyeUp = rightEyeScript.getIsEyeUp();
        isLeftEyeUp = leftEyeScript.getIsEyeUp();

        // check input
        if (Input.GetMouseButtonDown(0))
		{ 
           leftRigidBody.AddForce(Vector2.up * 30, ForceMode2D.Impulse);
        }
        if (Input.GetMouseButtonDown(1))
        {
            rightRigidBody.AddForce(Vector2.up * 30, ForceMode2D.Impulse);
        }


        //Checks if the game is finished
        if (isRightEyeUp && isLeftEyeUp)
        {
            gameWon = true;
            Budzik.GetComponent<AudioSource>().Stop();
            _isRunning = false; //should work
            GameManager.Instance.AddScore((1 - Timming.Position) * 1000.0f);
            StartCoroutine("WakeUpAnim");
        }
    }
}
