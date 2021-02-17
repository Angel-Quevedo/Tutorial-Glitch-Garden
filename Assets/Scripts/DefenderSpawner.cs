using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    StarsDisplay starsDisplay;
    GameObject defendersParent;

    const string DEFENDER_PARENT_NAME = "Defenders";

    private void Start()
    {
        starsDisplay = FindObjectOfType<StarsDisplay>();

        CreateDefendersParent();
    }

    private void CreateDefendersParent()
    {
        defendersParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defendersParent)
            defendersParent = new GameObject(DEFENDER_PARENT_NAME);
    }

    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    private void OnMouseDown()
    {
        SpawnDefender();
    }

    private Vector2 GetSquareClicked()
    {
        var mousePos = new Vector2(Mathf.Floor(Input.mousePosition.x), Mathf.Floor(Input.mousePosition.y));;
        var worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        return worldPos;
    }

    private void SpawnDefender()
    {
        var defenderCost = defender.GetComponent<Defender>().GetStarsCost();
        if (starsDisplay.GetStars() >= defenderCost)
        {
            var pos = GetSquareClicked();
            var newDefender = Instantiate(defender, new Vector2(Mathf.Round(pos.x), Mathf.Round(pos.y)), Quaternion.identity, defendersParent.transform );
            starsDisplay.ReduceStars(defenderCost);
        }
    }
}
