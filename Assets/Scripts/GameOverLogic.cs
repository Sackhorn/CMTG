using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverLogic : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{
		//gameObject.GetComponent<AudioSource>().Play();

		

        if (PlayerPrefs.GetInt("HighScore") < GameManager.Instance.Score)
        {
            PlayerPrefs.SetInt("HighScore", GameManager.Instance.Score);
        }

        GameObject.Find("UI").transform.FindChild("Info").GetComponent<Text>().text = "SCORE: " + GameManager.Instance.Score + "\nHIGHSCORE: " + PlayerPrefs.GetInt("HighScore") + "\nCLICKS: " + GameManager.Instance.Clicks;
    }
	
	// Update is called once per frame
	void Update ()
	{

	}

	public void backToMenu()
	{
	    GameManager.Instance.ResetData();
		Fade.FadeThisSit("menu");
	}
}
