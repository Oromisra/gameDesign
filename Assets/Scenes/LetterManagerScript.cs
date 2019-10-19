using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterManagerScript : MonoBehaviour
{
    public static char[] letterBase = { 'k', 'a', 'r', 'o' };
    public List<LetterDisplay> letterList;
    public LetterSpawner LetterSpawner;
    public int frequency = 100;
    private int time = 0;
    public int stress = 0;
    public StressBarScript stressBar;

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
            } else {
                stressBar.addStress(0.02f);
            }
        }
    }

    private void checkForLetterLower() {
        foreach(LetterDisplay letter in letterList) {
            if (letter.needsToDestroy()) {
                Destroy(letter.gameObject);
                this.letterList.Remove(letter);
                stressBar.addStress(0.05f);
                return;
            }
        }
    }

    private void Update() {
        if (!stressBar.isKaroshi()) {

            checkForLetterLower();
            time++;
            if (time % frequency == 0) {
                LetterDisplay newLetter = LetterSpawner.spawnLetter();
                newLetter.setLetter(generateNextLetter());
                letterList.Add(newLetter);
            }
        }
    }
}
