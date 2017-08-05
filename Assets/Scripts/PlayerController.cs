using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;

	private int count;
	private Rigidbody2D rb;

	void Start() {
		rb = GetComponent<Rigidbody2D> ();
		count = 0;
		winText.text = "";
		SetCountText ();
	}
		
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal") * speed;
		float moveVertical = Input.GetAxis("Vertical") * speed;

		rb.AddForce (new Vector2(moveHorizontal, moveVertical));
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag("PickUp")) {
			other.gameObject.SetActive (false);
			count++;
			SetCountText ();

			if (count == 12) {
				winText.text = "YOU WIN!";
			}
		}
	}

	void SetCountText() {
		countText.text = "Count: " + count.ToString();
	}
}
