using UnityEngine;
using System.Collections;
using UnityEditor;

public class Fade : MonoBehaviour
{
	private float _fade;

	private const float FadeTime = 1.0f;

	private string NextLevelName;

	// Use this for initialization
	void Start ()
	{
		_fade = 0.0f;

		var mat = gameObject.GetComponent<MeshRenderer>().material;
		mat.SetFloat("_ScreenWidth", Screen.width);
		mat.SetFloat("_ScreenHeight", Screen.height);
	}
	
	// Update is called once per frame
	void Update ()
	{
		_fade += Time.deltaTime;

		if (_fade >= FadeTime)
		{
			Application.LoadLevel(NextLevelName);
		}
	}

	public static void FadeThisSit(string nextScene)
	{
		var fade = Object.FindObjectOfType(typeof(Fade)) as Fade;

		if (fade == null)
		{
			Object prefab = AssetDatabase.LoadAssetAtPath("Assets/Prefarbs/Fade.prefab", typeof(GameObject));
			GameObject go = Instantiate(prefab, new Vector3(0,0,-1.0f), Quaternion.identity) as GameObject;
			fade = go.GetComponent<Fade>();
			fade.NextLevelName = nextScene;
		}
	}
}
