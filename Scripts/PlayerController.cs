using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	public Joystick JV;
	public Joystick JH;
	public float MoveSpeed = 50;
	public float MaxSpeed = 15;
	public float Drag = 0.98f;
	public float SteerAngle = 20;
	public float Traction = 1;
	private Vector3 MoveForce;
	private float speed;
	public float beschleunigung = 1;
	public Rigidbody rb;
	private bool Grounded;
	private int undergroundColissions = 0;
	
	private void Update() {
		if (transform.position.y < -5)
		{
			rb.velocity = -rb.velocity * 1.05f;
			undergroundColissions++;
			if (undergroundColissions > 5)
			{
				rb.velocity = -rb.velocity * 1.05f;
				//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
			}
		}
	}

	void FixedUpdate() {
		if (Grounded)
		{
			float V = JV.Vertical + Input.GetAxis("Vertical");
			float H = (JH.Horizontal / 2) + Input.GetAxis("Horizontal");
			rb.velocity += transform.right * V * beschleunigung * MoveSpeed * Time.deltaTime;
			rb.velocity *= Drag;
			transform.Rotate(Vector3.up * H * V * SteerAngle * Time.deltaTime);
			MoveForce *= Drag;
			MoveForce = Vector3.ClampMagnitude(MoveForce, MaxSpeed);
		}
	}
	
	private void OnCollisionStay(Collision other) {
		if (other.gameObject.tag == "Ground")
		{
			Grounded = true;
		}
	}
	private void OnCollisionExit(Collision other) {
		if (other.gameObject.tag == "Ground")
		{
			Grounded = false;
		}
	}
}