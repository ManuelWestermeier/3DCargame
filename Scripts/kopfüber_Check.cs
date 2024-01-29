using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kopfüber_Check : MonoBehaviour
{
	public GameObject car;
	public float rotation;
	
	private void OnTriggerEnter(Collider other) 
	{
		car.transform.Rotate(0, 0, rotation);
	}
}