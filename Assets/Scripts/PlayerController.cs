using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour {

	private Rigidbody2D dogeRigidBody;
	private AudioSource blast;
	[SerializeField]
	private float movementSpeed;
	[SerializeField]
	private Boundary boundary;

	public Transform shotSpawn;

	[SerializeField]
	private float fireRate;
	private float nextFire;

	void Start () {
		dogeRigidBody = GetComponent<Rigidbody2D> ();
		blast = GetComponent<AudioSource> ();
	}

	void Update () {
		ObjectPool activate = GameObject.Find("Player").GetComponent<ObjectPool>();
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			activate.ActivateObjects (shotSpawn.position, shotSpawn.rotation);
			blast.Play ();
		}
	}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0.0f);
		dogeRigidBody.velocity = movement * movementSpeed;

		dogeRigidBody.position = new Vector3 (Mathf.Clamp (dogeRigidBody.position.x, boundary.xMin, boundary.xMax), Mathf.Clamp (dogeRigidBody.position.y, boundary.yMin, boundary.yMax), 0.0f);
	}
}
