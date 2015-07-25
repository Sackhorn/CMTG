using System;
using UnityEngine;
using System.Collections;

public class Timming : MonoBehaviour
{
    public float Time;
    public float SecondsBeforeStart;
    public float SecondsToLoose;
    public float SecondsToWin;

    private Material _material;

    // Use this for initialization
    private void Start()
    {
        Time = 0;

        _material = gameObject.GetComponent<MeshRenderer>().material;
        _material.SetFloat("_ScreenWidth", Screen.width);
        _material.SetFloat("_ScreenHeight", Screen.height);
    }

    // Update is called once per frame
    private void Update()
    {
        if ((SecondsToLoose > 0 && Time >= SecondsToLoose) || (SecondsToWin > 0 && Time >= SecondsToWin))
            return;
        
       //Time += UnityEngine.Time.deltaTime;
        Time = 0;

        float realTime = Time - SecondsBeforeStart;
        if (realTime < 0)
            realTime = 0;

        if (SecondsToWin > 0 && realTime >= SecondsToWin)
        {
            GameManager.Instance.NextLevel();
        }
        if (SecondsToLoose > 0 && realTime >= SecondsToLoose)
        {
            GameManager.Instance.GameOver();
        }

        float pos;
        if(SecondsToLoose > 0)
            pos = 1 - realTime / SecondsToLoose;
        else
            pos = 1 - realTime / SecondsToWin;

        var cam = Camera.main;
        if (cam != null)
        {
            var res = Screen.currentResolution;
            float h = cam.orthographicSize;
            gameObject.transform.localScale = new Vector3(pos * pos * res.width * h * 0.00184f, h / 30, 1);
            gameObject.transform.position = new Vector3(0, 0.00091f * h * res.height, -1);
        }

        _material.SetFloat("_pos", 1 - Time * Time / realTime);
    }
}
