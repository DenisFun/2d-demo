using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenyPause : MonoBehaviour
{

	public GameObject menuPaused;
	public GameObject rg;
	bool isMenuPaused;
	[SerializeField] KeyCode keyMenuPaused;

	void Start()
    {
		menuPaused.SetActive(false);
	}

	void Update()
	{
		ActiveMenu();
	}
	void ActiveMenu()
	{
		if(Input.GetKeyDown(keyMenuPaused))
		{
			isMenuPaused = !isMenuPaused;
		}

		if(isMenuPaused)
		{
			menuPaused.SetActive(true);
			Time.timeScale = 0f;
			//GameObject.FindGameObjectsWithTag("Gun");
			rg.SetActive(false);
		}
		else
		{
			menuPaused.SetActive(false);
			Time.timeScale = 1f;
			rg.SetActive(true);
		}
	}
	public void MenuPausedContinue()
	{
		isMenuPaused = false;
	}
}
