using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Car2D : MonoBehaviour
{
	[SerializeField]
	Rigidbody2D rb;
	
	[HideInInspector]
	public float gasInput = 0f;
	[HideInInspector]
	public float brakeInput = 0f;
	[HideInInspector]
	public float rudderInput = 0f;

	[HideInInspector]
	public float speedKmh = 0f;
	[HideInInspector]
	float speedMs = 0f;

	float maxVelMs = 360f / 3.6f;

	[SerializeField]
	AnimationCurve accel;
	float maxRotAngle = 120f;
	float goodSpeed = 60f / 3.6f;
	float deltaRot = 60f;
	float rotAngle = 0f;
	void MoveCar()
	{
		rb.velocity += gasInput * (Vector2)transform.up * accel.Evaluate(speedMs/maxVelMs);
	}

	void RotateCar()
	{
		if(speedMs <= goodSpeed)
			rotAngle = maxRotAngle;
		else
			rotAngle = maxRotAngle - Mathf.Lerp(0f, deltaRot, (speedMs - goodSpeed) / (maxVelMs - goodSpeed));
			transform.Rotate(0f, 0f, -100f * rudderInput * Time.deltaTime);
	}

	void Break()
	{
		rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, Time.deltaTime * brakeInput);
	}
	private void FixedUpdate()
	{
		speedMs = rb.velocity.magnitude;
		speedKmh = 3.6f * speedMs;
		if(gasInput != 0f)
			MoveCar();
		if(rudderInput != 0f)
		{
			RotateCar();
			Vector2 oldDir = rb.velocity / speedMs;
			Vector2 newDir = (Vector2)transform.up + oldDir;
			newDir.Normalize();
			rb.velocity = speedMs * newDir;
		}
		if(brakeInput != 0f)
			Break();
	}
}
