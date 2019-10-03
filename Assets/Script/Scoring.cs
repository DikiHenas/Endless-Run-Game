using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour {
    private float score = 0.0f;
    int Z = 0;
    public Text scoreText;
    public DeathMenu deathMenu;
    private int maxDiffucltyLevel = 10;
    private int difficultyLevel = 0;
    private int scoreToNextLevel = 10;

    private bool isDead = false;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (isDead)
            return;
        if (score >= scoreToNextLevel)
            LevelUP();
        score =score+Time.deltaTime;        
        scoreText.text = ((int)score).ToString();
    }
   void LevelUP()
    {
        if (difficultyLevel == maxDiffucltyLevel)
            return;
        scoreToNextLevel *=2;
        difficultyLevel++;        
        GetComponent<PlayerMove>().SetSpeed(difficultyLevel);
    }
    public void OnDeath()
    {
        isDead = true;       
        
        deathMenu.ToggleEndMenu(score); 
    }
    
}
