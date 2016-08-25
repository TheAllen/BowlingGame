using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour {

	public float Standing = 3f;
	public float disToRaise = 40f;

	private Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
	}
	// Update is called once per frame
	void Update () {
		
	}

	public bool IsStanding(){
		
		Vector3 rotationAngle = transform.rotation.eulerAngles;

		float tiltX = Mathf.Abs(270-rotationAngle.x);
		float tiltZ = Mathf.Abs(rotationAngle.z);

		if (tiltX < Standing && tiltZ < Standing) {
			return true;
		} else {
			return false;
		}

	}

	public void RaiseIfStanding(){
		if (IsStanding ()) {
			rigidBody.useGravity = false;
			transform.Translate (new Vector3 (0, disToRaise, 0), Space.World);
			transform.rotation = Quaternion.Euler (270f, 0, 0); //resetting the rotation.
		}
	}

	public void Lower(){
		transform.Translate (new Vector3 (0, -disToRaise + 2f, 0), Space.World);
		rigidBody.useGravity = true;
	}
	
}
