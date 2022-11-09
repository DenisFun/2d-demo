using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
	public Transform shootPos;
	public GameObject bulletPrefab;
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
		{
			Shoot();
		}
    }

	void Shoot()
	{
		GameObject Bullet = Instantiate(bulletPrefab, shootPos.position, shootPos.rotation);
		Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
		rb.AddForce(shootPos.up, ForceMode2D.Impulse);
	}
}
