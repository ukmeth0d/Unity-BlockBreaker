﻿using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

    public LevelManager levelManager;

    void OnTriggerEnter2D(Collider2D trigger) {
        levelManager.LoadLevel("Win Screen");
    }

    void OnCollisionEnter2D(Collision2D collision) {

    }
}
