using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = Input.mousePosition;
		pos.z = 20;
		Debug.Log (pos.x + " " + pos.y + " " + pos.z + " ");
		pos = Camera.main.ScreenToWorldPoint(pos);
		pos.y =0;
		transform.position = pos;
	}
}
