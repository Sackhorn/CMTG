using UnityEngine;
using UnityEngine.UI;

public class MenuLogic : MonoBehaviour
{
	void Start ()
	{
        GameManager.Instance.StartMiniGame(10.0f);
	}

	public void doIt()
	{
        Fade.FadeThisSit("WakeMeUp", 2.0f);
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
