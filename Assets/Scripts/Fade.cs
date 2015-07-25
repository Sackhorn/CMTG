using UnityEngine;
using System.Collections;
using UnityEditor;

[RequireComponent(typeof(Camera))]
public class Fade : MonoBehaviour
{
    public Shader Shader = null;

    private Material ccMaterial;
    private float _fade;
	private string NextLevelName;
    private float FadeTime;

	// Use this for initialization
    private void Start()
	{
		_fade = 0.0f;
        NextLevelName = null;

        ccMaterial = CheckShaderAndCreateMaterial(Shader, ccMaterial);
    }

    protected Material CheckShaderAndCreateMaterial(Shader s, Material m2Create)
    {
        if (!s)
        {
            Debug.Log("Missing shader in " + ToString());
            enabled = false;
            return null;
        }

        if (s.isSupported && m2Create && m2Create.shader == s)
            return m2Create;

        if (!s.isSupported)
        {
            Debug.Log("The shader " + s.ToString() + " on effect " + ToString() + " is not supported on this platform!");
            return null;
        }
        else
        {
            m2Create = new Material(s);
            m2Create.hideFlags = HideFlags.DontSave;
            if (m2Create)
                return m2Create;
            else return null;
        }
	}
	
    private void Update()
    {
        if (NextLevelName != null)
	{
		_fade += Time.deltaTime;

		if (_fade >= FadeTime)
		{
                var toLoad = NextLevelName;
                NextLevelName = null;
                Debug.LogWarning("Loading: " + toLoad);
                Application.LoadLevel(toLoad);
                _fade = 1.0f;
            }
		}

        ccMaterial.SetFloat("_pos", _fade / FadeTime);
	}

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
        if (_fade == 0)
            Graphics.Blit(source, destination);
        else
            Graphics.Blit(source, destination, ccMaterial);
    }

    public static void FadeThisSit(string nextScene, float fadeTime = 1.0f)
		{
        var cam = GameObject.Find("Camera");
        var fade = cam.GetComponent<Fade>();
			fade.NextLevelName = nextScene;
        fade.FadeTime = fadeTime;
	}
}
