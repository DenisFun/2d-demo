using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet: MonoBehaviour
{
	public float speed = 7f;
	public int damage = 40;

	void Start()
    {
		StartCoroutine(Death());
    }

    void Update()
    {
		transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

	private IEnumerator Death()
	{
		yield return new WaitForSeconds(5f);
		Destroy(gameObject);
	}

	void OnTriggerEnter2D(Collider2D HitInfo)
	{
		Enemy enemy = HitInfo.GetComponent<Enemy>();
		if(enemy != null)
		{
			enemy.TakeDamage(damage);
		}
		Destroy(gameObject);
	}
}
