using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
	public float speed = 1.0f;
	public string axisName ="Horizontal";
	public Animator anim;
	public float jumpForce = 100.0f;
	// Use this for initialization
	void Start () {

		anim = gameObject.GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown ("space"))
		{
			// Set the Jump animator trigger parameter.
			anim.SetTrigger("Jump");
			
		

			
			// Add a vertical force to the player.
			rigidbody2D.AddForce(new Vector2(0f, jumpForce));
			
			// Make sure the player can't jump again until the jump conditions from Update are satisfied.
			//jump = false;
		}
		/*if (Input.GetKeyDown ("space"))
		{
		 transform.Translate(Vector3.up *jumpHeight * Time.deltaTime, Space.World);
		} */
		anim.SetFloat("speed", Mathf.Abs(Input.GetAxis(axisName)));
		if(Input.GetAxis(axisName) < 0)
		{
			Vector3 newScale = transform.localScale;
			newScale.x = -1.0f;
			transform.localScale = newScale;
		} else if (Input.GetAxis(axisName) > 0)
		{
			Vector3 newScale = transform.localScale;
			newScale.x = 1.0f;
			transform.localScale = newScale;
		}

		transform.position += transform.right*Input.GetAxis(axisName)*speed*Time.deltaTime;
	
	}
}



