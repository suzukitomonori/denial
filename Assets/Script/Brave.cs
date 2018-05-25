using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Brave : MonoBehaviour {
	[SerializeField] string nextStage;
	string gameOver = "Gameover";

	[SerializeField] GameObject fade;
	[SerializeField] GameObject boss;
	[SerializeField] GameObject bgm;
	[SerializeField] GameObject result;

	public GameObject ExploadObj;
	public GameObject ExploadPos;
	public GameObject FireObj;
	public GameObject FirePos;

	Fade _fade;
	bool bom = true;

	public AudioClip audioClip;
	[SerializeField] GameObject se;

	SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start ( ) {
		_fade = fade.gameObject.GetComponent<Fade> ();
		spriteRenderer = GetComponent<SpriteRenderer>();

	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionStay( Collision collision ) {
		if (collision.gameObject.name == "boss") {
			se.SetActive (true);
			if (bom) {
				Instantiate (ExploadObj, ExploadPos.transform.position, Quaternion.identity);
				Instantiate (FireObj, FirePos.transform.position, Quaternion.identity);
				bom = false;
				transform.position = new Vector3 (transform.position.x, transform.position.y, 100.0f);
				spriteRenderer.color = new Color (0, 0, 0, 0.0f);
				boss.gameObject.SetActive (false);
				GetComponent<Rigidbody> ().velocity = new Vector3 ();
			}
			StartCoroutine (FadeDelay(1.0f, _fade.fadeStart));
			StartCoroutine (SceneLoad (4.0f, nextStage));
		}
	}

	void OnTriggerStay( Collider col ) {
		if ( col.gameObject.tag == "terrain" || col.gameObject.name == "GameOverArea" ) {
			se.SetActive (true);
			if (bom) {
				Instantiate (ExploadObj, ExploadPos.transform.position, Quaternion.identity);
				Instantiate (FireObj, FirePos.transform.position, Quaternion.identity);
				bom = false;
				transform.position = new Vector3 (transform.position.x, transform.position.y, 100.0f);
				spriteRenderer.color = new Color (0, 0, 0, 0.0f);
			}
			StartCoroutine (FadeDelay(1.0f, _fade.fadeStart));
			StartCoroutine (SceneLoad (4.0f, gameOver));
		}
	}

	private IEnumerator SceneLoad( float time, string name ) {
		yield return new WaitForSeconds (time);

		SceneManager.LoadScene (name);
	}

	private IEnumerator FadeDelay( float time, string fadetype ) {
		yield return new WaitForSeconds (time);

		fade.gameObject.SetActive (true);
		_fade.FadeSwitch (fadetype);
	}

	private IEnumerator GameOver( GameObject bgm, GameObject result ) {
		yield return new WaitForSeconds( 3.0f );
	}
}
