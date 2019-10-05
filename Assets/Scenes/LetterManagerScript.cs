using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterManagerScript : MonoBehaviour
{
    public static char[] letterBase = { 'k', 'a', 'r', 'o' };
    public List<LetterDisplay> letterList;
    public LetterSpawner LetterSpawner;
    private void Start() {
        LetterDisplay newLetter = LetterSpawner.spawnLetter();
        newLetter.setLetter(generateNextLetter());
        letterList.Add(newLetter);
    }

    public static char generateNextLetter() {
        int randomIndex = Random.Range(0, 4);
        char randomLetter = letterBase[randomIndex];
        return randomLetter;
    }

    public void typeLetter(char letter) {
        if (this.letterList[0].getLetter() == letter) {
            Destroy(this.letterList[0]);
        } else {
            // Add stress
        }
    }

    private void Update() {
    }
}
