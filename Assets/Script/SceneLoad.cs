using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoad : MonoBehaviour {
	
	string scenename;
	NowScene _nowScene;
	[SerializeField] string stageName;
	[SerializeField] GameObject _se;
	void Start () {
		if (SceneManager.GetActiveScene ().name == "Gameover") {
			_nowScene = GameObject.Find ("nowScene").GetComponent<NowScene> ();
			scenename = _nowScene.scenename;
		}
	}

	void Update () {
		
	}

	public void pushContinue() {
		SceneManager.LoadScene (scenename);
	}

	public void pushTitle() {
		SceneManager.LoadScene ("Title");
	}

	public void pushStage() {
		SceneManager.LoadScene (stageName);
		_se.SetActive (true);
	}
}
