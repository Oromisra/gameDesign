using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StressBarScript : MonoBehaviour
{
    public Transform bar;
    private float stress = 0f;

    public void addStress(float stress) {
        this.stress += stress;
        SetSize(this.stress);
    }

    private void SetSize(float sizeNormalized) {
        if (sizeNormalized < 1f) {
            bar.localScale = new Vector3(1f, sizeNormalized);
        } else {
            bar.localScale = new Vector3(1f, 1f);
        }
    }

    public float getStress() {
        return stress;
    }

    public bool isKaroshi() {
        if (stress >= 1f) {
            return true;
        } else {
            return false;
        }
    }
}
