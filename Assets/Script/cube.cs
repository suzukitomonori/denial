using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour {

    private Vector3 m_mouseDownPosition;

    // Use this for initialization
	bool click; 
    void Start () {
        m_mouseDownPosition = transform.position;
		click = true;
    }

	void Update( ) {
		if (click) {
			if ( Input.GetMouseButtonUp (0)) {
				click = false;
			} else {
				Vector3 inputPosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 9.5f);
				Vector3 mousePos = Camera.main.ScreenToWorldPoint (inputPosition);
				Vector3 mediumPos = (mousePos - m_mouseDownPosition) / 2.0f + m_mouseDownPosition;
				float dist = Vector3.Distance (mousePos, m_mouseDownPosition);

				transform.position = mediumPos;
				transform.localScale = new Vector3 (1.0f, 1.0f, dist);
				transform.LookAt (mousePos);
			}
		}
	}
}
