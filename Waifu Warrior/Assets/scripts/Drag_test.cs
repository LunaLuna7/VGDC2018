using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag_test : MonoBehaviour {

	void OnMouseDrag(){
		Vector2 mousePosition = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
		Vector2 objPosition = Camera.main.ScreenToWorldPoint (mousePosition);
		transform.position = objPosition;
	}
}