using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.Windows;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int wrongGuesses = 0;

    //inactive body for hangman
    [SerializeField] GameObject HangmanHead;
    [SerializeField] GameObject HangmanSmile;
    [SerializeField] GameObject HangmanTorso;
    [SerializeField] GameObject HangmanLegLeft;
    [SerializeField] GameObject HangmanLegRight;
    [SerializeField] GameObject HangmanArmLeft;
    [SerializeField] GameObject HangmanArmRight;

    //Menus
    [SerializeField] GameObject InstructionsMenu;
    [SerializeField] GameObject LoseScreen;
    [SerializeField] GameObject WinScreen;

    //Audio Effects
    [SerializeField] AudioSource WrongAnswerAudio;
    [SerializeField] AudioSource CorrectAnswerAudio;
    [SerializeField] AudioSource BackgroundMusic;
    [SerializeField] AudioSource LoseMusic;
    [SerializeField] AudioSource WinMusic;

    //holds display word and word selected from text file
    string[] blankWord;
    public string selectedWord;

    //display word
    [SerializeField] TextMeshProUGUI SelectedWordLabel;

    //variables for the buttons used for the letters
    //used to store buttons so inactive game object
    //can be referenced later.
    GameObject UsedAButton;
    GameObject UsedBButton;
    GameObject UsedCButton;
    GameObject UsedDButton;
    GameObject UsedEButton;
    GameObject UsedFButton;
    GameObject UsedGButton;
    GameObject UsedHButton;
    GameObject UsedIButton;
    GameObject UsedJButton;
    GameObject UsedKButton;
    GameObject UsedLButton;
    GameObject UsedMButton;
    GameObject UsedNButton;
    GameObject UsedOButton;
    GameObject UsedPButton;
    GameObject UsedQButton;
    GameObject UsedRButton;
    GameObject UsedSButton;
    GameObject UsedTButton;
    GameObject UsedUButton;
    GameObject UsedVButton;
    GameObject UsedWButton;
    GameObject UsedXButton;
    GameObject UsedYButton;
    GameObject UsedZButton;


    private void Awake()
    {
        //Saves used button game objects so they are active
        //When Find is called

        //A
        UsedAButton = GameObject.Find("UsedButtons/UsedA");
        UsedAButton.SetActive(false);

        //B
        UsedBButton = GameObject.Find("UsedButtons/UsedB");
        UsedBButton.SetActive(false);

        //C
        UsedCButton = GameObject.Find("UsedButtons/UsedC");
        UsedCButton.SetActive(false);

        //D
        UsedDButton = GameObject.Find("UsedButtons/UsedD");
        UsedDButton.SetActive(false);

        //E
        UsedEButton = GameObject.Find("UsedButtons/UsedE");
        UsedEButton.SetActive(false);

        //F
        UsedFButton = GameObject.Find("UsedButtons/UsedF");
        UsedFButton.SetActive(false);

        //G
        UsedGButton = GameObject.Find("UsedButtons/UsedG");
        UsedGButton.SetActive(false);

        //H
        UsedHButton = GameObject.Find("UsedButtons/UsedH");
        UsedHButton.SetActive(false);

        //I
        UsedIButton = GameObject.Find("UsedButtons/UsedI");
        UsedIButton.SetActive(false);

        //J
        UsedJButton = GameObject.Find("UsedButtons/UsedJ");
        UsedJButton.SetActive(false);

        //K
        UsedKButton = GameObject.Find("UsedButtons/UsedK");
        UsedKButton.SetActive(false);

        //L
        UsedLButton = GameObject.Find("UsedButtons/UsedL");
        UsedLButton.SetActive(false);

        //M
        UsedMButton = GameObject.Find("UsedButtons/UsedM");
        UsedMButton.SetActive(false);

        //N
        UsedNButton = GameObject.Find("UsedButtons/UsedN");
        UsedNButton.SetActive(false);

        //O
        UsedOButton = GameObject.Find("UsedButtons/UsedO");
        UsedOButton.SetActive(false);

        //P
        UsedPButton = GameObject.Find("UsedButtons/UsedP");
        UsedPButton.SetActive(false);

        //Q
        UsedQButton = GameObject.Find("UsedButtons/UsedQ");
        UsedQButton.SetActive(false);

        //R
        UsedRButton = GameObject.Find("UsedButtons/UsedR");
        UsedRButton.SetActive(false);

        //S
        UsedSButton = GameObject.Find("UsedButtons/UsedS");
        UsedSButton.SetActive(false);

        //T
        UsedTButton = GameObject.Find("UsedButtons/UsedT");
        UsedTButton.SetActive(false);

        //U
        UsedUButton = GameObject.Find("UsedButtons/UsedU");
        UsedUButton.SetActive(false);

        //V
        UsedVButton = GameObject.Find("UsedButtons/UsedV");
        UsedVButton.SetActive(false);

        //W
        UsedWButton = GameObject.Find("UsedButtons/UsedW");
        UsedWButton.SetActive(false);

        //X
        UsedXButton = GameObject.Find("UsedButtons/UsedX");
        UsedXButton.SetActive(false);

        //Y
        UsedYButton = GameObject.Find("UsedButtons/UsedY");
        UsedYButton.SetActive(false);

        //Z
        UsedZButton = GameObject.Find("UsedButtons/UsedZ");
        UsedZButton.SetActive(false);

    }

    void Start()
    {
        SetUp();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetUp()
    {
        //picks word from wordlist txt file
        //sets bar at top in game to read _'s in corresponding spaces
        SelectedWord selectedWordClass = new SelectedWord();
        selectedWord = selectedWordClass.SelectWord();
        
        Debug.Log(selectedWord);
        blankWord = new string[selectedWord.Length];

        for (int i = 0; i < selectedWord.Length; i++)
        {
            blankWord[i] = "_";
            SelectedWordLabel.text = string.Join("", blankWord);
        }
    }

    public void Instructions()
    {
        InstructionsMenu.SetActive(true);
    }

    public void MakeLetterGuess(string input)
    {
        string letterInput = input;

        //this first double checks that there isn't both capital and lower
        if (selectedWord.Contains(input.ToLower()) && selectedWord.Contains(input))
        {
            int i = 0;

            while ((i = selectedWord.IndexOf(input, i)) != -1)
            {
                blankWord[i] = input;
                SelectedWordLabel.text = string.Join("", blankWord);

                i++;
            }

            int j = 0;

            while ((j = selectedWord.IndexOf(input.ToLower(), j)) != -1)
            {
                blankWord[j] = input.ToLower();
                SelectedWordLabel.text = string.Join("", blankWord);

                j++;
            }

            //plays CORRECT answer sound effect once
            CorrectAnswerAudio.Play();
        }

        //Difference in lower and upper so first letter can be capital
        else if (selectedWord.Contains(input))
        {
            int i = 0;

            while ((i = selectedWord.IndexOf(input, i)) != -1)
            {
                blankWord[i] = input;

                SelectedWordLabel.text = string.Join("", blankWord);

                i++;
            }

            //Plays CORRECT answer effect
            CorrectAnswerAudio.Play();
        }

        else if (selectedWord.Contains(input.ToLower()))
        {
            int i = 0;

            while ((i = selectedWord.IndexOf(input.ToLower(), i)) != -1)
            {
                blankWord[i] = input.ToLower();
                SelectedWordLabel.text = string.Join("", blankWord);

                i++;
            }

            //Plays CORRECT answer effect
            CorrectAnswerAudio.Play();
        }

        else
        {
            //Int used in checkhangmanstatus()
            wrongGuesses += 1;

            //Plays INCORRECT answer effect
            WrongAnswerAudio.Play();
        }
        
        ReplaceButton(letterInput);

        //adds to hangman if player got wrong answer
        CheckHangmanStatus();
        CheckWin();
    }

    void ReplaceButton(string input)
    {
        GameObject clickedButton = GameObject.Find($"LetterButtons/{input}");
        clickedButton.SetActive(false);

        if (input == "A") { UsedAButton.SetActive(true); }
        else if (input == "B") { UsedBButton.SetActive(true); }
        else if (input == "C") { UsedCButton.SetActive(true); }
        else if (input == "D") { UsedDButton.SetActive(true); }
        else if (input == "E") { UsedEButton.SetActive(true); }
        else if (input == "F") { UsedFButton.SetActive(true); }
        else if (input == "G") { UsedGButton.SetActive(true); }
        else if (input == "H") { UsedHButton.SetActive(true); }
        else if (input == "I") { UsedIButton.SetActive(true); }
        else if (input == "J") { UsedJButton.SetActive(true); }
        else if (input == "K") { UsedKButton.SetActive(true); }
        else if (input == "L") { UsedLButton.SetActive(true); }
        else if (input == "M") { UsedMButton.SetActive(true); }
        else if (input == "N") { UsedNButton.SetActive(true); }
        else if (input == "O") { UsedOButton.SetActive(true); }
        else if (input == "P") { UsedPButton.SetActive(true); }
        else if (input == "Q") { UsedQButton.SetActive(true); }
        else if (input == "R") { UsedRButton.SetActive(true); }
        else if (input == "S") { UsedSButton.SetActive(true); }
        else if (input == "T") { UsedTButton.SetActive(true); }
        else if (input == "U") { UsedUButton.SetActive(true); }
        else if (input == "V") { UsedVButton.SetActive(true); }
        else if (input == "W") { UsedWButton.SetActive(true); }
        else if (input == "X") { UsedXButton.SetActive(true); }
        else if (input == "Y") { UsedYButton.SetActive(true); }
        else if (input == "Z") { UsedZButton.SetActive(true); }
    }

    /// <summary>
    /// based on current amount of wrong guesses activates body gameobjects
    /// </summary>
    void CheckHangmanStatus()
    {
        if (wrongGuesses == 0)
        {
           
        }
        else if (wrongGuesses == 1)
        {
            HangmanHead.SetActive(true);
        }
        else if (wrongGuesses == 2)
        {
            HangmanSmile.SetActive(true);
            
        }
        else if (wrongGuesses == 3)
        {
            HangmanTorso.SetActive(true);
            
        }
        else if (wrongGuesses == 4)
        {
            HangmanLegLeft.SetActive(true);
            
        }
        else if (wrongGuesses == 5)
        {
            HangmanLegRight.SetActive(true);
        }
        else if (wrongGuesses == 6)
        {
            HangmanArmRight.SetActive(true);
        }
        else if (wrongGuesses == 7)
        {
            HangmanArmLeft.SetActive(true);
        }
        else
        {
            Lose();
        }

    }

    void CheckWin()
    {
        if(selectedWord == SelectedWordLabel.text)
        {
            Debug.Log("Win");
            WinScreen.SetActive(true);
            BackgroundMusic.Stop();
            WinMusic.Play();
        }
    }

    void Lose()
    {
        LoseScreen.SetActive(true);
        BackgroundMusic.Stop();
        LoseMusic.Play();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
