using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinCounter : MonoBehaviour {

	public Text pinDisplay;

	private bool ballOutOfPlay = false;
	private GameManager gameManager;
	private float lastChangeTime;
	private int standingCount = -1;
	private int lastSettledCount = 10;

	// Use this for initialization
	void Start () {
		gameManager = GameManager.FindObjectOfType<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		pinDisplay.text = CountStanding().ToString ();

		if (ballOutOfPlay) {
			UpdateStandingCount ();
		}
	}

	public void Reset(){
		lastSettledCount = 10;
	}

	void OnTriggerExit(Collider collider){
		if (collider.gameObject.name == "Ball") {
			ballOutOfPlay = true;
		}
	}

	void UpdateStandingCount(){
		int currentStanding = CountStanding ();

		if (currentStanding != standingCount) {
			lastChangeTime = Time.time;
			standingCount = currentStanding;
			return;
		}

		float settleTime = 3f;
		if ((Time.time - lastChangeTime) > settleTime) {
			PinsHaveSettled ();
		}
	}

	void PinsHaveSettled(){
		int standing = CountStanding ();
		int pinFall = lastSettledCount - CountStanding ();
		lastSettledCount = CountStanding ();

		gameManager.Bowl (pinFall);

		standingCount = -1;
		ballOutOfPlay = false;
		pinDisplay.color = Color.green;
	}

	int CountStanding(){
		int standing = 0;

		foreach (Pin pinNums in GameObject.FindObjectsOfType<Pin>()) {
			if (pinNums.IsStanding ()) {
				standing++;
			}
		}
		//returns 10 at the beginning.
		return standing;
	}
}
