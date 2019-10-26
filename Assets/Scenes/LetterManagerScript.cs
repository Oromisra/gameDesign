using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterManagerScript : MonoBehaviour
{
    public static char[] letterBase = { 'k', 'a', 'r', 'o', 's', 'h', 'i' };
    public List<LetterDisplay> letterList;
    public LetterSpawner LetterSpawner;
    public int frequency = 100;
    private int time = 0;
    public float stress = 0;
    public StressBarScript stressBar;
    public ScoreScript score;
    private void Start() {
    }

    public static char generateNextLetter() {
        int randomIndex = Random.Range(0, 4);
        char randomLetter = letterBase[randomIndex];
        return randomLetter;
    }

    public void typeLetter(char letter) {
        if (this.letterList.Count > 0) {
            if (this.letterList[0].getLetter() == letter) {
                Destroy(this.letterList[0].gameObject);
                this.letterList.RemoveAt(0);
                score.scoreValue += 10;
            } else {
                stressBar.addStress(0.02f);
                score.scoreValue -= 2;
            }
        }
    }

    private void checkForLetterLower() {
        foreach(LetterDisplay letter in letterList) {
            if (letter.needsToDestroy()) {
                Destroy(letter.gameObject);
                this.letterList.Remove(letter);
                stressBar.addStress(0.05f);
                score.scoreValue -= 5;
                return;
            }
        }
    }

    private void Update() {
        if (!stressBar.isKaroshi()) {
            stress = stressBar.getStress();

            checkForLetterLower();
            time++;
            if (time % frequency == 0) {
                LetterDisplay newLetter = LetterSpawner.spawnLetter();
                newLetter.setLetter(generateNextLetter());
                newLetter.setSpeed(stress);
                newLetter.setStressReference(stressBar);
                letterList.Add(newLetter);
            }
        }
    }
}
