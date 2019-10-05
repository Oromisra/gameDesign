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
    private void Start() {
    }

    public static char generateNextLetter() {
        int randomIndex = Random.Range(0, 4);
        char randomLetter = letterBase[randomIndex];
        return randomLetter;
    }

    public void typeLetter(char letter) {
        if (this.letterList[0].getLetter() == letter) {
            Destroy(this.letterList[0].gameObject);
            this.letterList.RemoveAt(0);
        } else {
            // Add stress
        }
    }

    private void Update() {
        time++;
        if (time % frequency == 0) {
            LetterDisplay newLetter = LetterSpawner.spawnLetter();
            newLetter.setLetter(generateNextLetter());
            letterList.Add(newLetter);
        }
    }
}
