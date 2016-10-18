using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	private Rigidbody2D objectRigidBody;
	[SerializeField]
	private float speed;

	void OnEnable () {
		objectRigidBody = GetComponent<Rigidbody2D> ();
		objectRigidBody.velocity = transform.right * speed;
	}

	void Update (){
		objectRigidBody.transform.Rotate (0, 0, 250 * Time.deltaTime);
	}
}
