using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public GameObject THIS;
	public GameObject THIS2;
	public float MoveSpeed = 50;
	public ParticleSystem MyExplosion;
	//public GameObject MyExplosionObj;
	public GameObject[] Cars;
	public float MaxSpeed = 15;
	public float Drag = 0.98f;
	public float SteerAngle = 20;
	public float Traction = 1;
	private bool canMove;
	private Vector3 MoveForce;
	private GameObject Player;
	public Rigidbody rb;
	public float enemySpeed = 4;
	private void Start()
	{
		if (Player == null)
		{
			Player = GameObject.FindWithTag("Player");
		}
	}

	private void Update()
	{
		if (canMove)
		{
			transform.LookAt(Player.transform);
		}
	}

	private void FixedUpdate()
	{
		if (canMove)
		{
			rb.velocity *= Drag;
			rb.velocity += (transform.forward * (MoveSpeed / 2) * Time.deltaTime);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			canMove = true;
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			canMove = false;
		}
	}
	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Player" || other.gameObject.tag == "Bullet")
		{
			//MyExplosionObj.SetActive(true);
			MyExplosion.Clear();
			MyExplosion.Play();
			AddCar(0, 200);
			rb.velocity = -rb.velocity * 1.5f;
			StartCoroutine(die());
		}
	}

	IEnumerator die()
	{
		yield return new WaitForSeconds(1.8f);
		Destroy(THIS);
		yield return new WaitForSeconds(1.8f);
		Destroy(THIS2);
		//THIS.SetActive(false);
	}
	private void AddCar(int i, int field)
	{
		Instantiate(Cars[i], new Vector3(transform.position.x + Random.Range(-field, field), 1, transform.position.z + Random.Range(-field, field)), Quaternion.identity);
	}
}