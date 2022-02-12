using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource currentMusicTreck; // не забыть проверить что трек из публичных источников
    public bool startPlayingGame;
    public NotesScroller ntScroller;
    public static GameManager instance;

    public int currentScore;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerPerfectNote = 150;


    public int currentMultiplier = 1;
    public int currentMistakesCount = 0;
    public int multiplierTracker;
    public int mistakesTracker;
    public int[] multiplierTresholds;

    public Text scoreText;
    public Text multiText;
    public Text mistakesText;

    public float totalNotes;
    public float normalHits;
    public float goodHits;
    public float perfectHits;
    public float missedHits;

    public GameObject resultScreen;
    public Text percentHitText, normalsText, goodText, perfectText, missedText, rankText, finalScoreText;

    void Start()
    {
        instance = this;

        scoreText.text = "Score: 0";

    }

    
    void Update()
    {
        if(!startPlayingGame)
        {
            if (Input.anyKeyDown)
            {
                startPlayingGame = true;
                ntScroller.hasStarted = true;
                currentMusicTreck.Play();
            }
        }
        else
        {
            if(!currentMusicTreck.isPlaying && !resultScreen.activeInHierarchy)
            {
                resultScreen.SetActive(true);
                normalsText.text = "" + normalHits;
                goodText.text = goodHits.ToString();
                perfectText.text = perfectHits.ToString();
                missedText.text = missedHits.ToString();

                float totalHit = normalHits + goodHits + perfectHits;
                float percentHit = (totalHit / totalNotes) * 100f;

                percentHitText.text = percentHit.ToString("F1") + "%";

                string rankValue = "F";
                if (percentHit > 40)
                {
                    rankValue = "D";
                    if (percentHit > 55)
                    {
                        rankValue = "C";
                        if (percentHit > 70)
                        {
                            rankValue = "B";
                            if (percentHit > 85)
                            {
                                rankValue = "A";
                                if (percentHit > 95)
                                {
                                    rankValue = "S";
                                }
                            }
                        }
                    }
                    
                }

                rankText.text = rankValue;
                finalScoreText.text = currentScore.ToString();
            }
        }
    }

    public void NoteHit()
    {
        Debug.Log("Hit");

        if (currentMultiplier - 1 < multiplierTresholds.Length)
        {
        multiplierTracker++;
        if(multiplierTresholds[currentMultiplier - 1] <= multiplierTracker)
        {
            multiplierTracker = 0;
            currentMultiplier++;
        }}

        multiText.text = "Multiplier: x" + currentMultiplier;

        scoreText.text = "Score:" + currentScore;
    }

    public void NormalHit()
    {
        currentScore += scorePerNote * currentMultiplier;
        NoteHit();

        normalHits++;
        totalNotes++;
    }

    public void GoodHit()
    {
        currentScore += scorePerGoodNote * currentMultiplier;
        NoteHit();

        goodHits++;
        totalNotes++;
    }
    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote * currentMultiplier;
        NoteHit();

        perfectHits++;
        totalNotes++;
    }
    public void NoteMissed()
    {
        Debug.Log("Missed");

        currentMultiplier = 1;
        multiplierTracker = 0;
        multiText.text = "Multiplier: x" + currentMultiplier;

        mistakesTracker ++;
        currentMistakesCount++;
        mistakesText.text = "Mistakes: x" + currentMistakesCount;

        missedHits++;
        totalNotes++;
    }
}
