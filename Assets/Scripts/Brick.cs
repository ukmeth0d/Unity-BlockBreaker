﻿using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

    public AudioClip crack;
    public Sprite[] hitSprites;
    public static int breakableCount = 0;
	public GameObject smoke;

    private int timesHit;
    private LevelManager levelManager;
    private bool isBreakable;
	private Color brickColor;


    // Use this for initialization
    void Start () {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        isBreakable = (this.tag == "Breakable");
        if (isBreakable) {
            breakableCount++;
        }
        timesHit = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D collision) {
        
    }

    void OnCollisionExit2D(Collision2D collision) {
        if (crack) {
            AudioSource.PlayClipAtPoint(crack, transform.position);
        }
        if (isBreakable) {
            HandleHits();
        }
    }

    void HandleHits() {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits) {
            Destroy(gameObject);
            breakableCount--;
			puffSmoke ();
            levelManager.BrickDestroyed();
        } else {
            LoadSprites();
        }
    }

	void puffSmoke() {
		GameObject smokePuff = Instantiate (smoke, transform.position, Quaternion.identity) as GameObject;
		smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}

    void LoadSprites() {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex]) {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
    }
}
