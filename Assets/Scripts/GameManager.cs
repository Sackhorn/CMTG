using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private static GameManager _instance;

	private int _clicks;
	private int _score;
	private int _currentLevel = -1;
	public int _currentDay;

    public int LastStoryIndex;

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
				_instance = Object.FindObjectOfType<GameManager>();

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

    private void Awake()
    {
        LastStoryIndex = -1;

        ResetData();

        // get current level
        for (int i = 0; i < Levels.Length; i++)
        {
            if (Levels[i].Name == Application.loadedLevelName)
            {
                _currentLevel = i;
                break;
            }
        }
        
        Debug.LogWarning("Awake: " + Application.loadedLevelName + ", id: " + _currentLevel);
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

	public void GameOver()
	{
		_currentLevel = -1;
        Debug.LogWarning("GameOver");
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

        Debug.LogWarning("NextLevel: " + Levels[_currentLevel].Name + ", id: " + _currentLevel);

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

    public void ShowStory(int storyIndex)
    {
        LastStoryIndex = storyIndex;
        Camera.main.cullingMask = 0;
        Application.LoadLevel("StoryText");
    }

    public void NextStory()
    {

        LastStoryIndex = _currentLevel;
        Camera.main.cullingMask = 0;
        Application.LoadLevel("StoryText");
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
		public object[] Config;
	}

	public LevelDesc[] Levels =
	{
		new LevelDesc()
		{
			Name = "WakeMeUp",
			FadeTime = 1.2f,
			Config = new object[]
			{
				0.0f
			}
		},
		new LevelDesc()
		{
			Name = "Korpo_scena",
			FadeTime = 0.2f,
			Config = new object[]
			{
				0.0f
			}
		},
		new LevelDesc()
		{
			Name = "pickingUpGirl",
			FadeTime = 0.4f,
			Config = new object[]
			{
				0.0f
			}
		},
		new LevelDesc()
		{
			Name = "Bridge",
			FadeTime = 0.4f,
			Config = new object[]
			{
				0.0f
			}
		},
	};

    public string[] Stories = new[]
    {
        @"Who: CorpoMan
Where: Each City
Target: wake up, earn money, survive",
    };
}
