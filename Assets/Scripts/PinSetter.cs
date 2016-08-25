using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

	public GameObject pinSet;

	private Ball ball;
	private ActionMaster actionMaster = new ActionMaster();
	private Animator animator;
	private PinCounter pinCounter;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		pinCounter = GameObject.FindObjectOfType<PinCounter> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RaisePins(){
		Debug.Log ("Raising pins");
		foreach (Pin pins in GameObject.FindObjectsOfType<Pin>()) {
			pins.RaiseIfStanding ();
		}
	}

	public void LowerPins(){
		Debug.Log ("Lower pins");
		foreach (Pin pins in GameObject.FindObjectsOfType<Pin>()) {
			pins.Lower ();
		}
	}

	public void RenewPins(){
		Debug.Log ("Renew pins");
		GameObject newPins = Instantiate (pinSet); 
		newPins.transform.position += new Vector3 (0, 20, 0);
	}




	void OnTriggerExit(Collider collider){
		GameObject thingLeft = collider.gameObject;

		if (thingLeft.GetComponent<Pin> ()) {
			Destroy (thingLeft);
		}
	}

	public void PerformAction(ActionMaster.Action action){
		if (action == ActionMaster.Action.Tidy) {
			animator.SetTrigger ("tidyTrigger");
		} else if (action == ActionMaster.Action.EndTurn) {
			animator.SetTrigger ("resetTrigger");
			pinCounter.Reset ();
		} else if (action == ActionMaster.Action.Reset) {
			animator.SetTrigger ("resetTrigger");
			pinCounter.Reset ();
		} else if (action == ActionMaster.Action.EndGame) {
			throw new UnityException ("Don't know how to handle end game yet");
		}
	}
		
}
