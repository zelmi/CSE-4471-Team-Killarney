using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeypadScriptBoss : MonoBehaviour
{
    [SerializeField] private string password;
    [SerializeField] private TextMeshProUGUI output;
    private string _currentString;

    void Start()
    {
        _currentString = "";
        this.UpdateText();
    }

    public void AddCharacter(string Char) {
        if(_currentString.Length < 7){
            _currentString += Char;
            this.UpdateText();
        } else {
            this.ClrString();
        }
    }

    public void ClrString(){
        _currentString = "";
        this.UpdateText();
    }

    public void SubmitString(){
        if(_currentString.Equals(password)){
            _currentString = "CORRECT";
            //Sets Unlocked Flag
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().BossUnlocked = true;
            this.UpdateText();
        } else {
            this.ClrString();
        }
    }

    private void UpdateText(){
        output.text = _currentString;
    }

    public void ExitPad(){
        PuzzleSceneManager.ExitPuzzle();
    }
}
