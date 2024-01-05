using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] string word;
    [SerializeField] Text worldField;
    [SerializeField] InputField inputField;
    [SerializeField] int attempts = 5;
    [SerializeField] Text attemptsText;
    [SerializeField] Button checkButton;
    [SerializeField] Button NewGameButton;
    string letters = "";
    string[] words = new string[]
    {
        "курага",
        "трансмеханика",
        "капуста",
        "самосвал",
        "барби",
        "инвалид",
        "дота",
        "РайанГослинг",
        "абоба",
        "бубылда"
    };
    public void NewGame()
    {
        letters = "";
        int index = Random.Range(0, 9);
        word = words[index];
        attempts =5;
        attemptsText.text = attempts.ToString();
        inputField.interactable = true;
        checkButton.interactable = true;
        NewGameButton.interactable = false;
        inputField.text = "";
        ShowWord ();
    }
    void FinishGame(string text)
    {
        NewGameButton.interactable = true;
        worldField.text = text;
        inputField.interactable = false;
        checkButton.interactable = false;
    }
    void loseAttempt()
    {
        attempts --;
        attemptsText.text = attempts.ToString();
    }
    public void CheckLetter()
    {
     if (worldField.text.Equals(word)) FinishGame("Победа!");
    else if (attempts<= 0) FinishGame("Потрачено");
    else{
    NewGameButton.interactable = false;
    string letter = inputField.text;
    inputField.text = "";
    inputField.ActivateInputField();
    letters += letter;
    print(letters);
    if (!word.Contains(letter))
     {
        loseAttempt();
        }
    ShowWord();
    }
    }
    void ShowWord()
{
    string output = "";
        foreach (char ch in word)
        {
            if (letters.Contains(ch.ToString()))output += ch;
           else output+= "*";
        }
        worldField.text = output;
}
    void Start()
    {
        int index = Random.Range(0, 9);
        word = words[index];
       NewGameButton.interactable = false;
       attemptsText.text = attempts.ToString();
       ShowWord();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) CheckLetter();
    }
}
//https://docs.unity3d.com/ScriptReference/Random.Range.html
//сделать так чтобы выпадало рандомное число