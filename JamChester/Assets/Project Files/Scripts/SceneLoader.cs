﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour {

    float time = 5;
    float next_scene_count = 0;
    public int loadthis = 2;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (next_scene_count > time)
        {
            SceneManager.LoadScene(loadthis);
        }
        next_scene_count += Time.deltaTime;
	}
}