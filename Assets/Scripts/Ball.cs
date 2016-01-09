﻿using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
    public Paddle paddle;

    private Rigidbody2D ballRigidBody;
    private Vector3 paddleToBallVector;
    private bool hasStarted = false;

	// Use this for initialization
	void Start () {
        paddleToBallVector = this.transform.position - paddle.transform.position;

        ballRigidBody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!hasStarted) {
            this.transform.position = paddle.transform.position + paddleToBallVector;

            if (Input.GetMouseButtonDown(0)) {
                hasStarted = true;
                ballRigidBody.velocity = new Vector2(2f, 10f);
            }
        }
	}
}
