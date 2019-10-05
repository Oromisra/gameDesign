using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterDisplay : MonoBehaviour
{
    public Text text;
    private char letter;
    public float fallSpeed = 30f;

    public void setLetter(char letter) {
        this.letter = letter;
        this.text.text = letter.ToString();
    }

    public char getLetter() {
        return letter;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, -fallSpeed * Time.deltaTime, 0f);
    }
}
