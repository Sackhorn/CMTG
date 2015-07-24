using UnityEngine;
using System.Collections;

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
}
