using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
	void Update()
    {
        
    }
	public void SceneLoad(int index)
	{
		SceneManager.LoadScene(index);
	}
}
