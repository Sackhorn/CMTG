using UnityEngine;
using UnityEngine.UI;

public class MenuLogic : MonoBehaviour
{
    private void Start()
    {
       // GameManager.Instance.StartMiniGame(10.0f, -1, 0, 0);
    }

    public void doIt()
	{
        //Fade.FadeThisSit("WakeMeUp", 2.0f);
        //GameManager.Instance.NextLevel();
        GameManager.Instance.ShowStory(0);
	}

	public void dontDoIt()
	{
	    GameManager.Instance.Exit();
	}
}
