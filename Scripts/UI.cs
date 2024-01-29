using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
	public Text scoreText;
	public ParticleSystem ps;
	public Text HIScoreText;
	public Text positionText;
	public Text livesText;
	private int score;
	public int lives;
	void FixedUpdate()
	{
		score++;
		scoreText.text = "score:" + score;
		HIScoreText.text = "Hiscore:" + PlayerPrefs.GetInt("HiScore");
		positionText.text = "Distance: " + (int)transform.position.x + "|" + (int)transform.position.z;
		livesText.text = "Lives:" + lives;
		if (score > PlayerPrefs.GetInt("HiScore"))
		{
			PlayerPrefs.SetInt("HiScore",score);
		}
		if (lives == 0 || lives < 0)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			//ps.Play();
		}
	}

	private void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "Gegner")
		{
			other.transform.gameObject.tag = "Untagged";
			//print(other.transform.gameObject.tag);
			lives -= 1;
		}
	}
}
