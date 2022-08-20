using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Trigger : MonoBehaviour
{
    public TextMeshProUGUI winText;

    private void OnTriggerEnter2D(Collider2D other) {
        winText.text = "YOU WIN!";
    }
}
