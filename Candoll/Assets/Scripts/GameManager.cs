﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	// Time to wait to start a level (display black screen)
	public float levelStartDelay = 1f;
    public static GameManager instance = null;
    private int level = 1;

	// Display level
	private Text levelText;
	// Use this to show or hide level loading screen
	private GameObject levelImage;
	// Prevent player from moving during setup
	private bool doingSetup;

	// Use this for initialization
	void Awake () {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        InitGame();
	}

	private void HideLevelImage()
	{
		levelImage.SetActive (false);
		doingSetup = false;
	}

	public void GameOver()
	{
		levelText.text = "You haunted the home for " + level + " nights.";
		levelImage.SetActive(true);
		enabled = false;
	}

	private void OnLevelWasLoaded (int index)
	{
		level++;
		InitGame ();
	}

    void InitGame()
	{
		doingSetup = true;
		levelImage = GameObject.Find ("LevelImage");
		levelText = GameObject.Find ("LevelText").GetComponent<Text> ();
		levelText.text = "Night " + level;
		levelImage.SetActive (true);
		Invoke ("HideLevelImage", levelStartDelay);
	}

	// Update is called once per frame
	void Update () 
	{
		if (doingSetup)
			return;
	
	}
}
