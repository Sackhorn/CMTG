using UnityEngine;
using UnityEngine.UI;

public class MenuLogic : MonoBehaviour
{
    public GameObject Logo;

    private Camera _cam;
    private Vector3 _initPos;

    private void Start()
    {
       // GameManager.Instance.StartMiniGame(10.0f, -1, 0, 0);

        _cam = GameObject.Find("Camera").GetComponent<Camera>();
        _initPos = _cam.transform.position;
    }

    private void Update()
    {
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
        //Fade.FadeThisSit("WakeMeUp", 2.0f);
        //GameManager.Instance.NextLevel();
        GameManager.Instance.ShowStory(0);
	}

	public void dontDoIt()
	{
	    GameManager.Instance.Exit();
	}
}
