using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///Summary
// This script is used to move the submarine, the camera is the fixed camera 
// and the submarine is the object that is moved by the player
// key AD controls the rotation of the submarine, WS controls the movement and QE controls the up and down movement
///Summary
public class Movement : MonoBehaviour
{
    private Animator _anim;
    private float _speed = 2f;
    private float _rotationSpeed = 100f;
    private float _upDownSpeed = 2f;

    void Start()
    {
        _anim = GetComponent<Animator>();  
    }   

    void Update()
    {
        Move();
    }
    private void Move()
    {
        // Rotation
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -_rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);
        }

        // Movement
        if (Input.GetKey(KeyCode.W))
        {
            PlayAnimation("Run");
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            PlayAnimation("Walk");
            transform.Translate(Vector3.forward * -_speed * Time.deltaTime);
        }
        else
        {
            PlayAnimation("Idle");
        }

        // Up and Down
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(Vector3.up * _upDownSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Translate(Vector3.up * -_upDownSpeed * Time.deltaTime);
        }

    }

	public void PlayAnimation(string s) {
		_anim.Play (s);

		if (s == "Idle") {
			_anim.SetBool ("isWalking", false);
			_anim.SetBool ("isRunning", false);
		}

		if (s == "Walk") {
			_anim.SetBool ("isWalking", true);
			_anim.SetBool ("isRunning", false);
		}
		if (s == "Run") {
			_anim.SetBool ("isWalking", false);
			_anim.SetBool ("isRunning", true);
		}
	}
}
