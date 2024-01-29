using UnityEngine;

public class Shoot : MonoBehaviour
{
	public GameObject bullet;
	public Transform spawnPoint;
	public ParticleSystem ps;
	public float bulletSpeed = 1000;
	public bool frontshoot = false;
	private float timeToNextShoot = 0;
	public float fireTime = 20;
	private void Update() {
		if (Input.GetKey(KeyCode.Space))
		{
			ShootBullet();
		}
		if (Input.GetButton("Fire1"))
		{
			ShootBullet();
		}
		timeToNextShoot++;
	}
	public void ShootBullet() 
	{
		if (timeToNextShoot > fireTime)
		{
			if (frontshoot)
			{
				GameObject GameObjectObj = Instantiate(bullet,spawnPoint.position,spawnPoint.rotation);
				GameObjectObj.GetComponent<Rigidbody>().velocity += transform.right * bulletSpeed * Time.deltaTime;
				Destroy(GameObjectObj,5.0f);
				ps.Play();
			}
			else
			{
				GameObject GameObjectObj = Instantiate(bullet,spawnPoint.position,spawnPoint.rotation);
				GameObjectObj.GetComponent<Rigidbody>().velocity += transform.right * -bulletSpeed * Time.deltaTime;
				Destroy(GameObjectObj,3.0f);
				ps.Play();
			}
			timeToNextShoot = 0;
		}
	}
}