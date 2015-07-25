using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private static GameManager _instance;

	private int _clicks;
	private int _score;
	private int _currentLevel;
	private int _currentDay;

	public static bool isActive
	{
		get { return _instance != null; }
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

	public int Clicks
	{
		get { return _clicks; }
	}
	public int Score
	{
		get { return _score; }
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
			/*if(_currentLevel == -1)
			{
				Exit();
			}
			else*/
			{
				GameOver();
			}
		}

		if (Input.GetKeyDown(KeyCode.RightAlt))
		{
			NextLevel();
		}
	}

	/// <summary>
	/// Create timming slider
	/// </summary>
	/// <param name="secondsToLoose">Amount of seconds to game over (-1 to disable)</param>
	/// <param name="secondsToWin">Amount of seconds to win a level (-1 to disable)</param>
	/// <param name="cooldownBefore">Amount of seconds before timer start</param>
	/// <param name="cooldownAfter">Amount of seconds before timer end</param>
	public void StartMiniGame(float secondsToLoose, float secondsToWin, float cooldownBefore, float cooldownAfter)
	{
		Object prefab = Resources.Load("Timming");
		GameObject go = Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject;
		var timming = go.GetComponent<Timming>();
		timming.SecondsToWin = secondsToWin;
		timming.CooldownAfter = cooldownAfter;
		timming.CooldownBefore = cooldownBefore;
		timming.SecondsToLoose = secondsToLoose;
	}

	public void GameOver()
	{
		_currentLevel = -1;
		Fade.FadeThisSit("gameKurwaOver", 0.4f);
	}

	public void NextLevel()
	{
		_currentLevel++;
		if (_currentLevel >= Levels.Length)
		{
			_currentLevel = 0;
			_currentDay++;
		}

		Fade.FadeThisSit(Levels[_currentLevel].Name, Levels[_currentLevel].FadeTime);
	}

	public void ResetData()
	{
		_score = 0;
		_clicks = 0;
		_currentLevel = -1;
		_currentDay = 0;
	}

	public void Exit()
	{
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
		 Application.Quit();
#endif
	}

	public void AddScore(float gain)
	{
		_score += (int)gain;
	}

	public void AddScore(int gain)
	{
		_score += gain;
	}

	public struct LevelDesc
	{
		/// <summary>
		/// Name of the scene file
		/// </summary>
		public string Name;

		/// <summary>
		/// Time in seconds to fade in to this scene
		/// </summary>
		public float FadeTime;

		/// <summary>
		/// Configuration fir the scene (custom for every one)
		/// </summary>
		public float[] Config;
	}

	public LevelDesc[] Levels =
	{
		new LevelDesc()
		{
			Name = "WakeMeUp",
			FadeTime = 1.2f,
			Config = new []
			{
				0.0f
			}
		},
		new LevelDesc()
		{
			Name = "pickingUpGirl",
			FadeTime = 0.4f,
			Config = new []
			{
				0.0f
			}
		},
		new LevelDesc()
		{
			Name = "Bridge",
			FadeTime = 0.4f,
			Config = new []
			{
				0.0f
			}
		},
	};
}
