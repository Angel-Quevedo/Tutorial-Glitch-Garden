using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int starCost = 100;
    StarsDisplay starsDisplay;

    private void Start()
    {
        starsDisplay = FindObjectOfType<StarsDisplay>();
    }

    public void AddStars(int amount)
    {
        starsDisplay.AddStars(amount);
    }

    public int GetStarsCost()
    {
        return starCost;
    }
}
