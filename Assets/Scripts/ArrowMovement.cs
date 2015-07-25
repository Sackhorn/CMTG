using System;
using UnityEngine;
using System.Collections;

public class ArrowMovement : MonoBehaviour
{
    public float ArrowSpeed;

    private void Update()
    {
        gameObject.transform.position -= new Vector3(Time.deltaTime * ArrowSpeed, 0, 0);
    }
}
