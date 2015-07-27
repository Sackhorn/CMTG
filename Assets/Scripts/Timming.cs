using System;
using UnityEngine;
using System.Collections;

public class Timming : MonoBehaviour
{
    private static Timming _timer;

    public float Time;
    public float TotalTime;

    private Material _material;
    public Action _onFinish;

    /// <summary>
    /// Create timming slider
    /// </summary>
    /// <param name="timerTime">Timer time length in seconds</param>
    public static void Start(float timerTime, Action onFinish)
    {
        if (_timer != null)
        {
            Debug.LogWarning("Duplicated timer");
            Destroy(_timer);
            _timer = null;
        }

        var prefab = Resources.Load("Timming");
        GameObject go = Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject;
        var timer = go.GetComponent<Timming>();
        timer.TotalTime = timerTime;
        timer._onFinish = onFinish;
    }

    /// <summary>
    /// Stops the timer
    /// </summary>
    public static void Stop()
    {
        Destroy(_timer);
        _timer = null;
    }

    /// <summary>
    /// Current timmer position in range [0;1]
    /// </summary>
    public static float Position
    {
        get { return _timer != null ? 1 - _timer.Time / _timer.TotalTime : 0; }
    }

    private void Start()
    {
        Time = 0;

        _material = gameObject.GetComponent<MeshRenderer>().material;
        _material.SetFloat("_ScreenWidth", Screen.width);
        _material.SetFloat("_ScreenHeight", Screen.height);

        _timer = this;
    }

    private void OnDestroy()
    {
        _timer = null;
    }

    private void Update()
    {
        Time += UnityEngine.Time.deltaTime;

        float pos = Position;

        if (pos <= 0.0f)
        {
            // End
            if (_onFinish != null)
            {
                _onFinish();
            }
            Destroy(gameObject);
        }

        var cam = Camera.main;
        if (cam != null)
        {
            var res = Screen.currentResolution;
            Vector3 camPos = cam.transform.position;
            float h = cam.orthographicSize;
            float s = 0.000916f;

            s = 100.001f;

            gameObject.transform.localScale =
                new Vector3(pos * pos * res.width * h * 0.00184f, 
                    h / 30, 1);
            gameObject.transform.position = 
                new Vector3(camPos.x, 
                    camPos.y + s * h * res.height, -1);
        }

        _material.SetFloat("_pos", pos);
    }
}
