using System;
using UnityEngine;
using System.Collections;

public class Timming : MonoBehaviour
{
    private static Timming _currenTimming;

    public float Time;
    public float CooldownBefore;
    public float CooldownAfter;
    public float SecondsToLoose;
    public float SecondsToWin;

    private Material _material;
    private bool _juzPo = false;

    // Use this for initialization
    private void Start()
    {
        Time = 0;

        _material = gameObject.GetComponent<MeshRenderer>().material;
        _material.SetFloat("_ScreenWidth", Screen.width);
        _material.SetFloat("_ScreenHeight", Screen.height);

        _currenTimming = this;
        _juzPo = false;
    }

    private void OnDestroy()
    {
        _currenTimming = null;
    }

    // Update is called once per frame
    private void Update()
    {
        Time += UnityEngine.Time.deltaTime;
        // Time = 0;

        float realTime = Time - CooldownBefore;
        if (realTime < 0)
            realTime = 0;

        if (!_juzPo)
        {
            if (SecondsToWin > 0 && realTime >= SecondsToWin + CooldownAfter)
            {
                _juzPo = true;
                GameManager.Instance.NextLevel();
            }
            if (SecondsToLoose > 0 && realTime >= SecondsToLoose + CooldownAfter)
            {
                _juzPo = true;
                GameManager.Instance.GameOver();
            }
        }

        float pos = Position;

        var cam = Camera.main;
        if (cam != null)
        {
            var res = Screen.currentResolution;
            Vector3 camPos = cam.transform.position;
            float h = cam.orthographicSize;
            gameObject.transform.localScale = new Vector3(pos * pos * res.width * h * 0.00184f, h / 30, 1);
            gameObject.transform.position = new Vector3(camPos.x, camPos.y + 0.000916f * h * res.height, -1);
        }

        _material.SetFloat("_pos", pos);
    }

    /// <summary>
    /// Timer position in range [0;1]
    /// </summary>
    public float Position
    {
        get
        {
            float realTime = Time - CooldownBefore;
            if (realTime < 0)
                realTime = 0;

            float pos;
            if ((SecondsToLoose > 0 && Time >= SecondsToLoose) || (SecondsToWin > 0 && Time >= SecondsToWin))
                pos = 1;
            else if (SecondsToLoose > 0)
                pos = 1 - realTime / SecondsToLoose;
            else
                pos = 1 - realTime / SecondsToWin;
            return pos;
        }
    }

    public static Timming Instance
    {
        get { return _currenTimming; }
    }

    /*public static bool IsFading
    {
        get { return _currenTimming.Position == 0; }
    }*/
}
