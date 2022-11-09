using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlay : MonoBehaviour
{
	[SerializeField]
	Car2D car;

	float pressedBreak = 0f;

	// Update is called once per frame
	void Update()
    {
        car.gasInput = Input.GetAxis("Vertical");
		car.rudderInput = Input.GetAxis("Horizontal");

		if (Input.GetKey(KeyCode.LeftShift))
		{
			pressedBreak = Mathf.Min(pressedBreak + 0.9f, 1f);
		}
		else
			pressedBreak = 0f;
		car.brakeInput = pressedBreak;
	}
}
