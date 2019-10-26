using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterDisplay : MonoBehaviour
{
    public Text text;
    private char letter;
    public float fallSpeed = 2;
    public float slideDirection = 0;
    public int time = 0;
    public StressBarScript stressBar;

    public void setLetter(char letter) {
        this.letter = letter;
        this.text.text = letter.ToString();
    }

    public char getLetter() {
        return letter;
    }

    public void setStressReference(StressBarScript reference) {
        stressBar = reference;
    }

    public void setSpeed(float speed) {
        fallSpeed += speed;
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
        time++;
        float stress = stressBar.getStress();
        if (stress >= 0.2f) {
            if (time / 5 % 2 == 0) {
                slideDirection = -2 - (stress * 2);
            } else {
                slideDirection = 2 + (stress * 2);
            }
        } else {
            slideDirection = 0;
        }
        transform.Translate(slideDirection, -fallSpeed, 0f);
    }
}
