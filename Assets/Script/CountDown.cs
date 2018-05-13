using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {
	const float count = 3;
	private float countDown;
	[SerializeField] Text waitText;
	[SerializeField] GameObject player;
	[SerializeField] GameObject image;


	// Use this for initialization
	void Start () {
		countDown = count;
	}
	
	// Update is called once per frame
	void Update () {
		countDown -= Time.deltaTime;
		countDown = Mathf.Max (countDown, 0, 0);
		waitText.text = "Tap To Start";
		if (((int)countDown) == (count - 1f)) {
			player.SetActive (false);
		}

		if (((int)countDown) == (count - 3f)) {
			image.SetActive (false);
			waitText.gameObject.SetActive (true);
		}

		if (Input.GetMouseButtonDown(0)) {
			player.SetActive (true);
			this.gameObject.SetActive (false);
		}

	}
}
