using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour
{
    
    private Transform target;
    
    void Start( ) {
        target = GameObject.Find( "Brave" ).transform;
    }
    
    void Update( ) {
        transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
		if (transform.position.x < 3.0f) {
			transform.position = new Vector3( 3.0f, transform.position.y, transform.position.z);
		}
    }
}