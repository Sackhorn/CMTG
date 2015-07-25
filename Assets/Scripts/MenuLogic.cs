using UnityEngine;
using UnityEngine.UI;

public class MenuLogic : MonoBehaviour
{
	void Start ()
	{
        GameManager.Instance.StartMiniGame(0, 10.0f, -1);
	}

	public void doIt()
	{
        //Fade.FadeThisSit("WakeMeUp", 2.0f);
        GameManager.Instance.NextLevel();
	}

	public void dontDoIt()
	{
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
	}
}
