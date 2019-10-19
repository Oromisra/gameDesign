using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterDisplay : MonoBehaviour
{
    public Text text;
    private char letter;
    public float fallSpeed = 2;

    public void setLetter(char letter) {
        this.letter = letter;
        this.text.text = letter.ToString();
    }

    public char getLetter() {
        return letter;
    }

    public bool needsToDestroy() {
        Vector3 p = transform.position;
        if (p.y < -30) {
            return true;
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, -fallSpeed, 0f);
    }
}
