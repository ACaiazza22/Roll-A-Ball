﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

public float speed;

private Rigidbody rb;
private int count;
public Text countText;
public Text winText;

void Start(){

	rb = GetComponent<Rigidbody>();
	count = 0;
	SetCountText();
	winText.text = "";
}

void FixedUpdate(){

	float moveHorizontal = Input.GetAxis("Horizontal");

	float moveVertical = Input.GetAxis("Vertical");

	Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

	rb.AddForce (movement * speed);
}

	
	void OnTriggerEnter(Collider other){

		
		if (other.gameObject.CompareTag("PickUP")){
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText();

		}
	}

	void SetCountText(){

		countText.text = "Count: " + count.ToString();
		if (count >= 9){

			winText.text = "You Win!";


		}
	}



}