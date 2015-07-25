using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverLogic : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		//gameObject.GetComponent<AudioSource>().Play();

		GameObject.Find("UI").transform.FindChild("Info").GetComponent<Text>().text = "CLICKS: " + GameManager.Instance.Clicks;
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	public void backToMenu()
	{
	    GameManager.Instance.ResetData();
		Fade.FadeThisSit("menu", 0.8f);
	}
}
