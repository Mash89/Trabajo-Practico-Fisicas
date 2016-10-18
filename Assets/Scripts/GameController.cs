using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	[SerializeField]
	private Vector3 spawnValues;
	[SerializeField]
	private float spawnWait;

	public GUIText scoreText, restartText, gameOverText;

	private int score;
	private bool gameOver, restart;

	void Start () {
		score = 0;
		gameOver = false;
		restart = false;
		gameOverText.text = "";
		restartText.text = "";
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}

	void Update () {
		if (restart) {
			if (Input.GetKeyDown (KeyCode.R)) {
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}
		}
	}

	IEnumerator SpawnWaves () {
		ObjectPool activate = GameObject.Find("Game Controller").GetComponent<ObjectPool>();
		while (!gameOver) {
			Vector3 spawnPosition = new Vector3 (spawnValues.x, Random.Range (-spawnValues.y, spawnValues.y), spawnValues.z);
			Quaternion spawnRotation = Quaternion.identity;
			activate.ActivateObjects (spawnPosition, spawnRotation);
			yield return new WaitForSeconds (spawnWait);
		}
		if (gameOver) {
			restartText.text = "Press 'R' for restart";
			restart = true;
		}
	}

	public void AddScore (int newScoreValue){
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore () {
		scoreText.text = "Ricky points: " + score;
	}

	public void GameOver () {
		gameOverText.text = "Gueim ober pls git gud...";
		gameOver = true;
	}

}
