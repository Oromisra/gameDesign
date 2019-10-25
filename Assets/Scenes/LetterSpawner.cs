using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterSpawner : MonoBehaviour
{
    public GameObject letterPreFab;
    public Transform letterCanvas;
    public LetterDisplay spawnLetter() {
        Vector3 randomPosition = new Vector3(Random.Range(-50f, 50f), 35f);

        GameObject letterObj = Instantiate(letterPreFab, randomPosition, Quaternion.identity, letterCanvas);
        LetterDisplay letter = letterObj.GetComponent<LetterDisplay>();
        return letter;
    }
}
