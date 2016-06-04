using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuLogic : MonoBehaviour
{
    public GameObject Logo;

    private Camera _cam;
    private Vector3 _initPos;

    public GameObject CharPrefarb;

    public GameObject top;

    private float _time;

    private List<GameObject> chars;

    private bool _firstChar = true;

    private CharScript _choosenOne;

    private bool _doing;

    private void Start()
    {
       // GameManager.Instance.StartMiniGame(10.0f, -1, 0, 0);
        
        _time = 0;
        _doing = true;

        _cam = GameObject.Find("Camera").GetComponent<Camera>();
        _initPos = _cam.transform.position;

        chars = new List<GameObject>(100);
    }

    private void Update()
    {
        if (_doing)
        {
            _time += Time.deltaTime;


            if (_time > 1.5f)
            {
                top.SetActive(true);

                _time = 0;
                GameObject newChar = (GameObject)Instantiate(CharPrefarb);
                chars.Add(newChar);
                if(_firstChar)
                {
                    _choosenOne = newChar.GetComponent<CharScript>();
                    _firstChar = false;
                }
            }
        }

        // Debug.LogWarning(_cam.transform.position);

            //Debug.LogWarning((float)Screen.width / Screen.height);

            //280, 480
            _cam.transform.position = _initPos - new Vector3(Mathf.Lerp(0, 150, 1 - Mathf.Clamp01((float)Screen.width / Screen.height - 1.0f)), 0, 0);
            //_cam.transform.position = _initPos - new Vector3(Mathf.Lerp(0, , Screen.width * 0.4f), 0, 0);

            var pos = Logo.transform.position;
            Logo.transform.position = new Vector3(_cam.transform.position.x, pos.y, pos.z);

    }

    public void doIt()
    {
        _doing = false;

        top.SetActive(false);

        foreach (var e in chars)
        {
            CharScript c;
            c = e.GetComponent<CharScript>();
            if (c != _choosenOne)
            {
                c.Fade();
            }
            else
            {
                c.Anim();
            }
        }


        //Fade.FadeThisSit("WakeMeUp", 2.0f);
        //GameManager.Instance.NextLevel();
        GameManager.Instance.ShowStory(0);
	}

	public void dontDoIt()
	{
	    GameManager.Instance.Exit();
	}

    public void addNewChoosenOne(GameObject n)
    {
        _choosenOne = n.GetComponent<CharScript>();
    }
}
