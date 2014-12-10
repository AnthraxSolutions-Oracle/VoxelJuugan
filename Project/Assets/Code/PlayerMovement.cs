using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}

	public float width;
	public float length;
	public float friction;
	public float maxForwardSpeed;
	public float forwardAcc;
	public float maxSidewaySpeed;
	public float sidewayAcc;
	public float maxBackwardSpeed;
	public float backwardAcc;
	//Playing filed limits
	public Transform topLeft;
	public Transform bottomRight;



	private float xSpeed = 0;
	private float ySpeed = 0;



	// Update is called once per frame
	void FixedUpdate () {
		if (xSpeed > 0) {
			xSpeed -= friction;
			if(xSpeed < 0){
				xSpeed = 0;
			}
		}else if(xSpeed < 0){
			xSpeed += friction;
			if(xSpeed > 0){
				xSpeed = 0;
			}
		}
		if (ySpeed > 0) {
			ySpeed -= friction;
			if(ySpeed < 0){
				ySpeed = 0;
			}
		}else if(ySpeed < 0){
			ySpeed += friction;
			if(ySpeed > 0){
				ySpeed = 0;
			}
		}
		
		if (!(Input.GetKey (KeyCode.D) && Input.GetKey (KeyCode.A))) {
			if(Input.GetKey(KeyCode.D)){
				xSpeed +=  forwardAcc;
				if(xSpeed > maxForwardSpeed){
					xSpeed = maxForwardSpeed;
				}
			}else if(Input.GetKey(KeyCode.A)){
				xSpeed -= backwardAcc;
				if(xSpeed < (maxBackwardSpeed *-1)){
					xSpeed = (maxBackwardSpeed * -1);
				}
			}
		}

		if(!(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))){
			if(Input.GetKey(KeyCode.W)){
				ySpeed += sidewayAcc;
				if(ySpeed > maxSidewaySpeed){
					ySpeed = maxSidewaySpeed;
				}
			}
			if(Input.GetKey(KeyCode.S)){
				ySpeed -= sidewayAcc;
				if(ySpeed < (maxSidewaySpeed * -1)){
					ySpeed = (maxSidewaySpeed * -1);
				}
			}
		}
		Vector3 pos = transform.position;
		pos.x += xSpeed;
		pos.z += ySpeed;
		if (pos.x < topLeft.position.x + length) {
			pos.x = topLeft.position.x + length;
		}else if(pos.x > bottomRight.position.x - length){
			pos.x = bottomRight.position.x - length;
		}

		if(pos.z > topLeft.position.z - width){
			pos.z = topLeft.position.z - width;
		}else if(pos.z < bottomRight.position.z + width){
			pos.z = bottomRight.position.z + width;
		}
		transform.position = pos;
	}
}
