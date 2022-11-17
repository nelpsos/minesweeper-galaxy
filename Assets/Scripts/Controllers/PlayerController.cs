using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    void Start()
    {
		Managers.Input.MouseAction -= OnMouseClicked;
		Managers.Input.MouseAction += OnMouseClicked;		
	}

	void Update()
    {
	}

	void OnMouseClicked(Define.MouseEvent evt)
	{

	}
}
