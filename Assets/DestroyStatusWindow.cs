using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyStatusWindow : MonoBehaviour
{


	public void DestroyWindowParent()
	{
		Debug.Log("destroy window");
		this.transform.parent.transform.gameObject.SetActive(false);
	}
}
