using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class UIFit2Screen : MonoBehaviour
{
	private RectTransform _transform;

	public float Position = -0.2f;

	void Start ()
	{
		_transform = gameObject.GetComponent<RectTransform>();
	}

	void Update ()
	{
		/*float worldScreenWidth = Camera.main.orthographicSize * 2f / Screen.height * Screen.width;
		Vector3 xWidth = transform.localScale;
		xWidth.x = worldScreenWidth / _sprite.sprite.bounds.size.x * 1.1f;
		transform.localScale = new Vector3(xWidth.x, xWidth.x, 1);*/

		_transform.anchoredPosition = new Vector2(Screen.width * Position, _transform.anchoredPosition.y);
	}
}
