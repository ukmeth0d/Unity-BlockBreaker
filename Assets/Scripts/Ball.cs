using UnityEngine;using System.Collections;public class Ball : MonoBehaviour {    private Paddle paddle;    private Rigidbody2D ballRigidBody;    private Vector3 paddleToBallVector;    private bool hasStarted = false;    private AudioSource ballAudio;

    // Use this for initialization
    void Start () {        paddle = GameObject.FindObjectOfType<Paddle>();        paddleToBallVector = this.transform.position - paddle.transform.position;        ballRigidBody = GetComponent<Rigidbody2D>();        ballAudio = GetComponent<AudioSource>();    }		// Update is called once per frame	void Update () {        if (!hasStarted) {            this.transform.position = paddle.transform.position + paddleToBallVector;            if (Input.GetMouseButtonDown(0)) {                hasStarted = true;                ballRigidBody.velocity = new Vector2(2f, 10f);            }        }	}    void OnCollisionEnter2D(Collision2D collision) {
        Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
        if (hasStarted) {
            //ballAudio.Play();
            ballRigidBody.velocity += tweak;
        }    }}