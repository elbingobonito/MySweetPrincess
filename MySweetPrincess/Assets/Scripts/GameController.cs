﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

    List<GameObject> sweets = new List<GameObject>();
    public GameObject player;

    Vector3 playerStartPos;
    Quaternion playerStartRot;
    int startWeight;

    public Camera camera;
    Vector3 cameraStartPos;
    Quaternion cameraStartRot;

	// Use this for initialization
	void Start () {
        foreach (Transform child in transform) {
            sweets.Add(child.gameObject);
        }
        playerStartPos = player.transform.position;
        playerStartRot = player.transform.rotation;
        startWeight = player.GetComponent<CharController>().weight;
        cameraStartPos = camera.transform.position;
        cameraStartRot = camera.transform.rotation;
        Reset();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R)) Reset();
	}

    void Reset() {
        foreach (GameObject candy in sweets) {
            candy.SetActive(true);
        }
        player.GetComponent<CharController>().weight = startWeight;
        player.GetComponent<CharController>().isDead = false;
        player.GetComponent<CharController>().enteredDeepWater = false;
        player.transform.position = playerStartPos;
        player.transform.rotation = playerStartRot;
        camera.transform.position = cameraStartPos;
        camera.transform.rotation = cameraStartRot;
    }
}
