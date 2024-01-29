using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public Transform playerPos;
	public GameObject[] Houses;
	public GameObject[] Cars;

	public void Spawn(int field, int much)
	{
		for (int i = 0; i < much; i++)
		{
			AddHouse(0, field);
			AddCar(0, field);
		}
	}

	private void Start()
	{
		Spawn(500, 500);
		StartCoroutine(addGegner());
	}

	private void AddHouse(int i, int field)
	{
		Instantiate(Houses[i], new Vector3(playerPos.position.x + Random.Range(-field, field), 0, playerPos.position.z + Random.Range(-field, field)), Quaternion.identity);
	}

	private void AddCar(int i, int field)
	{
		Instantiate(Cars[i], new Vector3(playerPos.position.x + Random.Range(-field, field), 1, playerPos.position.z + Random.Range(-field, field)), Quaternion.identity);
	}

	IEnumerator addGegner()
	{
		AddCar(0, 500);
		yield return new WaitForSeconds(0.25f);
		StartCoroutine(addGegner());
	}
}