using UnityEngine;
using UnityEngine.UI;

public class MenuLogic : MonoBehaviour
{
	void Start ()
	{
	    GameObject.Find("Canvas").transform.GetChild(0).GetComponent<Text>().text = "trololo";
	}

	void Update ()
    {
	
	}

	public void doIt()
	{
	    hideUI();
        Fade.FadeThisSit("WakeMeUp", 2.0f);
	}

	public void dontDoIt()
	{
        hideUI();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
	}

    private void hideUI()
    {
        GameObject.Find("Canvas").SetActive(false);
    }
}
