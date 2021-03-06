﻿using UnityEngine;
using System.Collections;

public class SpriteFit2Screen : MonoBehaviour
{
    public float factor;
	private SpriteRenderer _sprite;


	void Start ()
	{
		_sprite = gameObject.GetComponent<SpriteRenderer>();
	}

	void Update ()
	{
		float worldScreenWidth = Camera.main.orthographicSize * 2f / Screen.height * Screen.width;
		Vector3 xWidth = transform.localScale;
		xWidth.x = worldScreenWidth / _sprite.sprite.bounds.size.x * factor;
		transform.localScale = new Vector3(xWidth.x, xWidth.x, 1);
	}
}
