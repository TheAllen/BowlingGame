using UnityEngine;
using System.Collections;

[RequireComponent(typeof (Ball))]
public class BallDragLaunch : MonoBehaviour {

	private Vector3 dragStart, dragEnd;
	private float startTime, endTime;
	private Vector3 direction;
	private Ball ball;

	// Use this for initialization
	void Start () {
		ball = GetComponent<Ball> ();
	}

	public void MoveStart(float amount){
		if (!ball.inPlay) {
			float xPos = Mathf.Clamp (ball.transform.position.x + amount, -50f, 50f);
			float yPos = ball.transform.position.y;
			float zPos = ball.transform.position.z;
			ball.transform.position = new Vector3 (xPos, yPos, zPos);
		}
	}
	
	public void DragStart(){
		//capture time and position of drag start
		//direction = new Vector3(Input.mousePosition.x - 577.0f, 0.0f, ball.launchVelocity.z);
		if (!ball.inPlay) {
			dragStart = Input.mousePosition;
			startTime = Time.time;
		}
	}

	public void DragEnd(){
		//launch the ball

		if (!ball.inPlay) {
			dragEnd = Input.mousePosition;
			endTime = Time.time;

			float dragDuration = endTime - startTime;

			float launchSpeedX = (dragEnd.x - dragStart.x) / dragDuration;
			float launchSpeedZ = (dragEnd.y - dragStart.y) / dragDuration;

			direction = new Vector3 (launchSpeedX, ball.launchVelocity.y, launchSpeedZ);

			ball.Launch(direction);
		}
	}


}
