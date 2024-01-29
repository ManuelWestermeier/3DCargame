using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
	public Rigidbody rb;	
	private void OnTriggerExit(Collider other) {
		if (other.tag == "Boost")
		{
			//StartCoroutine(addBoost(3));
			//StartCoroutine(addEnergy(5000));
		}
	}
	
	IEnumerator addBoost(float time)
	{
		rb.velocity += transform.right * 70 * Time.deltaTime;
		yield return new WaitForSeconds(time);
	}
	
	IEnumerator addEnergy(float energy)
	{
		rb.AddForce(transform.right * energy, ForceMode.Impulse);
		yield return new WaitForSeconds(0.1f);
	}
}
