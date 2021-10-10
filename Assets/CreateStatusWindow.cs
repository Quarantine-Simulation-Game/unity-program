using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateStatusWindow : MonoBehaviour
{
	public GameObject window;
	public GameObject buttonClose;

	private GameObject newWindow;


	// Use this for initialization
	void Start()
	{
	}

	public void CreateWindow()
	{
		Debug.Log("---> Window ShareLink create");
		window.SetActive(true);
	}
}
