using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;

    DefenderSpawner defenderSpawner;

    private void Start()
    {
        defenderSpawner = FindObjectOfType<DefenderSpawner>();

        LabelButtonWithCost();
    }

    private void LabelButtonWithCost()
    {
        var costText = GetComponentInChildren<Text>();
        if (!costText)
            Debug.LogError(name + " has no cost text");
        else
            costText.text = defenderPrefab.GetStarsCost().ToString();
    }

    private void OnMouseDown()
    {
        foreach (var defenderButton in FindObjectsOfType<DefenderButton>())
        {
            defenderButton.GetComponent<SpriteRenderer>().color = new Color32(102,102,102,255);
        }
        
        GetComponent<SpriteRenderer>().color = Color.white;
        defenderSpawner.SetSelectedDefender(defenderPrefab);
    }
}
