using System;
using UnityEngine;
using System.Collections;

public class Timming : MonoBehaviour
{
    public float Time = 0;
    public float TotalTime = 30;
    public Action OnFinish;

    private Material _material;

    // Use this for initialization
    private void Start()
    {   
        _material = gameObject.GetComponent<MeshRenderer>().material;
        _material.SetFloat("_ScreenWidth", Screen.width);
        _material.SetFloat("_ScreenHeight", Screen.height);
    }

    // Update is called once per frame
    private void Update()
    {
        if(Time >= TotalTime)
            return;
        
       Time += UnityEngine.Time.deltaTime;

        if (Time >= TotalTime)
        {
            if (OnFinish != null)
            {
                OnFinish();
            }
        }

        float pos = 1 - Time / TotalTime;
        var cam = Camera.current;
        if (cam != null)
        {
            var res = Screen.currentResolution;
            float h = cam.orthographicSize;
            gameObject.transform.localScale = new Vector3(pos * pos * res.width * h * 0.00184f, h / 30, 1);
            gameObject.transform.position = new Vector3(0, 0.00091f * h * res.height, -1);
        }

        _material.SetFloat("_pos", 1 - Time * Time / TotalTime);
    }
}
