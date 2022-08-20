using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using TMPro;

public class Air : MonoBehaviour
{
    private TextMeshProUGUI airText;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        airText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        string temp;

        if (player.oxygenTime > 0)
            temp = "Oxygen: " + Math.Round(player.oxygenTime, 2) + "s";
        else
            temp = "O2 LEVELS CRITICAL";

        airText.text = temp;
    }
}
