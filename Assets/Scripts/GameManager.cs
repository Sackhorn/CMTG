using UnityEngine;

public class GameManager : MonoBehaviour
{
	private static GameManager _instance;

	static public bool isActive
	{
		get
		{
			return _instance != null;
		}
	}

	public static GameManager Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = Object.FindObjectOfType(typeof(GameManager)) as GameManager;

				if (_instance == null)
				{
					GameObject go = new GameObject("_gameManager");
					DontDestroyOnLoad(go);
					_instance = go.AddComponent<GameManager>();
				}
			}
			return _instance;
		}
	}

	public void StartMiniGame(float seconds)
	{
		//Object prefab = AssetDatabase.LoadAssetAtPath("Assets/Prefarbs/Timming.prefab", typeof(GameObject));
	    Object prefab = Resources.Load("Timming");
		GameObject go = Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject;
		var timming = go.GetComponent<Timming>();
		timming.TotalTime = seconds;
		timming.OnFinish = GameOver;
	}

	public void GameOver()
	{
		Fade.FadeThisSit("gameKurwaOver", 0.4f);
	}
}
