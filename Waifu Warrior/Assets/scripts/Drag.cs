using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour {

	public GameObject gameObjectTodrag;

	public Vector3 GOcenter;
	public Vector3 touchPosition;
	public Vector3 offset;
	public Vector3 newGOCenter;

	RaycastHit hit2d;

	public bool draggingMode = false;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		foreach (Touch touch in Input.touches)
		{
			switch(touch.phase)
			{
			case TouchPhase.Began:
				Ray ray = Camera.main.ScreenPointToRay (touch.position);

				if (Physics.SphereCast (ray, 0.3f, out hit2d)) {
					gameObjectTodrag = hit2d.collider.gameObject;
					GOcenter = gameObjectTodrag.transform.position;
					touchPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
					offset = touchPosition - GOcenter;
					draggingMode = true;


				}
				break;

			case TouchPhase.Moved:
				if (draggingMode)
				{
					touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
					newGOCenter = touchPosition - offset;
					gameObjectTodrag.transform.position = new Vector3 (newGOCenter.x, newGOCenter.y, GOcenter.z);

		
	}
				break;

			case TouchPhase.Ended:
				draggingMode = true;

				break;
			}
		}
	}
}
