using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	public Vector3 launchVelocity;
	public float launchSpeed = 200;
	public bool inPlay = false;

	private Rigidbody rigidBody;
	private AudioSource clip;
	private Vector3 originalPosition;
	private Rigidbody ballRigidBody;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
		clip = GetComponent<AudioSource> ();

		rigidBody.useGravity = false;

		originalPosition = gameObject.transform.position;

	}

	public void Launch(Vector3 velocity){
		inPlay = true;

		launchVelocity = velocity;
		rigidBody.useGravity = true;
		rigidBody.velocity = launchVelocity;
		clip.Play ();

	}

	public void Reset(){
		inPlay = false;
		Debug.Log ("Resetting ball");
		transform.position = originalPosition;
		transform.rotation = Quaternion.identity;
		rigidBody.velocity = Vector3.zero;
		rigidBody.angularVelocity = Vector3.zero;
		rigidBody.useGravity = false;
	}
		

}
