using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BelconTest : MonoBehaviour {
	
	private GameObject brave;
	private Vector3 m_mouseDownPosition;
	bool click; 
	bool over_obj;
	bool hitWall;
	const float DESTROY_TIME = 8.0f;
	float _time = 0f;
	const float CLEATE_COUNT = 3.0f;
	private float _count;

	void Start ( ) {
		m_mouseDownPosition = transform.position;
		click = true;
		over_obj = false;
		hitWall = false;
		brave = GameObject.Find( "Brave" );
	}

	void Update( ) {
		if ( click ) {
			_count += 0.1f;
			if ( Input.GetMouseButtonUp ( 0 ) || _count > CLEATE_COUNT || over_obj || hitWall ) {
				click = false;
			} else {
				Vector3 inputPosition = new Vector3 ( Input.mousePosition.x, Input.mousePosition.y, 9.5f );
				Vector3 mousePos = Camera.main.ScreenToWorldPoint ( inputPosition );
				Vector3 mediumPos = ( mousePos - m_mouseDownPosition ) / 2.0f + m_mouseDownPosition;
				float dist = Vector3.Distance ( mousePos, m_mouseDownPosition );

				transform.position = mediumPos;
				transform.localScale = new Vector3 ( 1.0f, 1.0f, dist );
				transform.LookAt ( mousePos );
			}
		}
		_time += Time.deltaTime;
		if( _time > DESTROY_TIME ) {
			Destroy( gameObject );
		}
	}
	void OnCollisionStay( Collision collision ) {
		if ( collision.gameObject.tag == "Player" && !click ) {
			Vector2 left = new Vector2 (brave.transform.position.x + 0.05f, brave.transform.position.y);
			brave.transform.position = left;	
		}
		over_obj = true;
	}
	void OnTriggerEnter( Collider col ) {
		if (col.gameObject.tag == "terrain") {
			hitWall = true;
		}
	}
}
