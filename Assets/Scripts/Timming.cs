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
        gameObject.transform.localScale = new Vector3(pos * pos * Screen.width * 0.0791f, 1, 1);
        gameObject.transform.position = new Vector3(0, 0.00158f * Camera.main.orthographicSize * Screen.height, -1);

        _material.SetFloat("_pos", 1 - Time * Time / TotalTime);
    }
}
