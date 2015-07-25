using UnityEngine;

public class GameManager : MonoBehaviour
{
	private static GameManager _instance;

	private int _clicks;
	private int _currentLevel;
	private int _currentWeek;

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

	private void Start()
	{
		ResetData();
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
		{
			_clicks++;
		}

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			GameOver();
		}
	}

    /// <summary>
    /// Create timming slider
    /// </summary>
    /// <param name="secondsBeforeStart">Amount of seconds before timer start</param>
    /// <param name="secondsToLoose">Amount of seconds to game over (-1 to disable)</param>
    /// <param name="secondsToWin">Amount of seconds to win a level (-1 to disable)</param>
	public void StartMiniGame(float secondsBeforeStart, float secondsToLoose, float secondsToWin)
	{
		Object prefab = Resources.Load("Timming");
		GameObject go = Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject;
		var timming = go.GetComponent<Timming>();
	    timming.SecondsToWin = secondsToWin;
	    timming.SecondsBeforeStart = secondsBeforeStart;
	    timming.SecondsToLoose = secondsToLoose;
	}

	public void GameOver()
	{
		Fade.FadeThisSit("gameKurwaOver", 0.4f);
	}

	public void NextLevel()
	{

	}

	public void ResetData()
	{
		_clicks = 0;
		_currentLevel = 0;
		_currentWeek = 0;
	}

	public struct LevelDesc
	{
		/// <summary>
		/// Name of the scene file
		/// </summary>
		public string Name;

		/// <summary>
		/// Tme for level on 1st time
		/// </summary>
		public float BaseTime;

		/// <summary>
		/// Every nex time level is played it's time is multiplied by that value
		/// </summary>
		public float TimeMul;
	}

	public int Clicks
	{
		get { return _clicks; }
	}

}
