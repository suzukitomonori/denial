using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceGauge : MonoBehaviour {

	[SerializeField] GameObject _brave;
	[SerializeField] GameObject _boss;
	float _start_pos_x;

	Slider _slider;

	// Use this for initialization
	void Start () {
		//参照
		if (!_brave) {
			_brave = GameObject.Find ("Brave");
		}
		_start_pos_x = _brave.transform.position.x;
		if (!_boss) {
			_boss = GameObject.Find ("boss");
		}
		_slider = GameObject.Find ("Slider").GetComponent<Slider>();

	}
	
	// Update is called once per frame
	void Update () {
		//スライダーの移動
		_slider.value = getDistance ();
	}

	//距離の計算
	float getDistance() {
		//位置
		float nowpos = _brave.transform.position.x;
		float goal_pos = _boss.transform.position.x - _boss.GetComponent<BoxCollider>().size.x / 2;
		//距離の計算
		return ( nowpos - _start_pos_x ) / ( goal_pos - _start_pos_x );
	}
}
