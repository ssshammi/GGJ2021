using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameManager : MonoBehaviour
{
    public float startTime;
    public float currentTime;
    public bool gameStarted = false;

    public int roundNum = 0;
    public Text roundInfoText;
    public Text countdownText;

    //public int phase = 0;

    public List<GameObject> marbles = new List<GameObject>();

    public int currentMarble = 0;
    public PlayerHoleSelection selection;

    int score = 0;
    int lives = 3;

    enum PHASE {START, WAIT, GAME, SELECTION };
    PHASE phase;
    // Start is called before the first frame update
    void Start()
    {
        RoundStart();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        switch (phase) {
            case PHASE.START:
                RoundStart();
                break;
            case PHASE.WAIT:
                WaitPhase();
                break;
            case PHASE.GAME:
                GamePhase();
                break;
            case PHASE.SELECTION:
                PlayerSelectionPhase();
                break;
        }

    }

    void RoundStart() {

        currentTime = 0;
        countdownText.text = (startTime - (int)currentTime).ToString();
        roundInfoText.text = "Round Starts: ";
        roundNum++;
        phase = PHASE.WAIT;
        // tell the rats to go to for marbles...reachedbox = false  
    }

    void RoundOver() { 
       
        //player has made selections
        //  call round start
    }
    void WaitPhase() {

        // check if game ready to start
        if (currentTime > startTime)
        {
            gameStarted = true;
            countdownText.text = " ";
            roundInfoText.text = "Round: " + roundNum.ToString();
            phase = PHASE.GAME;
        }
        else
        {
            // set text to be countdown value
            countdownText.text = (startTime - (int)currentTime).ToString();
        }
    }
    void GamePhase() {

        // Debug for checking the round start code works... change this to be called after rats rturn to holes
        if (currentTime > 20)
        {
            phase = PHASE.SELECTION;
        }
    }

    void PlayerSelectionPhase() {

        if (currentMarble == marbles.Count)
        {
            phase = PHASE.START;
        }
        if (lives > 0)
        {
            roundInfoText.text = "Find the " + marbles[currentMarble].name + " Marble!";

            GameObject selcted = selection.PlayerChoice();
            if (selcted)
            {

                if (selcted.name == marbles[currentMarble].name)
                {
                    // selected right marble
                    // do something
                    score++;
                    currentMarble++;
                }
                else
                {
                    lives--;
                    //wrong
                }
            }
        }
        else {
            SceneManager.LoadScene("MenuScreen");
        }

        
    }
}
