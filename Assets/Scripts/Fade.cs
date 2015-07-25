//using UnityEngine;
//using System.Collections;
//using UnityEditor;

//public class Fade : MonoBehaviour
//{
//	private float _fade;

//	private const float FadeTime = 0.4f;

//	private string NextLevelName;
//	private Material _material;

//	// Use this for initialization
//	void Start ()
//	{
//		_fade = 0.0f;

//		_material = gameObject.GetComponent<MeshRenderer>().material;
//		_material.SetFloat("_ScreenWidth", Screen.width);
//		_material.SetFloat("_ScreenHeight", Screen.height);
//	}
	
//	// Update is called once per frame
//	void Update ()
//	{
//		_fade += Time.deltaTime;

//        _material.SetFloat("_pos", 1 - _fade / FadeTime);

//		if (_fade >= FadeTime)
//		{
//			Application.LoadLevel(NextLevelName);
//		}
//	}

//	public static void FadeThisSit(string nextScene)
//	{
//		var fade = Object.FindObjectOfType(typeof(Fade)) as Fade;

//		if (fade == null)
//		{
//			Object prefab = AssetDatabase.LoadAssetAtPath("Assets/Prefarbs/Fade.prefab", typeof(GameObject));
//			GameObject go = Instantiate(prefab, new Vector3(0,0,-1.0f), Quaternion.identity) as GameObject;
//			fade = go.GetComponent<Fade>();
//			fade.NextLevelName = nextScene;
//		}
//	}
//}
