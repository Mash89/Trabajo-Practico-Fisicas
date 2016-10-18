using UnityEngine;
using System.Collections;

public class DisableByContact : MonoBehaviour {
	public GameObject playerExplosion;
	public int scoreValue;
	private GameController gameController;

	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag != "Boundary") {
			ObjectPool activate = GameObject.Find("Explosion Pool").GetComponent<ObjectPool>();
			activate.ActivateObjects (transform.position, transform.rotation);
			if (other.tag == "Player") {
				//Al ser un solo objeto los instancie en lugar de crear un object pool
				Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
				gameController.GameOver ();
				Destroy (other.gameObject);
			}
			gameController.AddScore (scoreValue);
			gameObject.SetActive (false);
			other.gameObject.SetActive (false);
			//transform.position = Vector3.zero;
		}
	}
}
