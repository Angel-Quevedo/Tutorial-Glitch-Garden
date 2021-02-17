using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarsDisplay : MonoBehaviour
{
    [SerializeField] int stars = 100;
    Text starsText;

    private void Start()
    {
        starsText = GetComponent<Text>();
        UpdateDisplay();
    }

    public int GetStars()
    {
        return stars;
    }

    private void UpdateDisplay()
    {
        starsText.text = stars.ToString();
    }

    public void AddStars(int amount)
    {
        stars += amount;
        UpdateDisplay();
    }

    public void ReduceStars(int amount)
    {
        if (stars >= amount)
        {
            stars -= amount;
            UpdateDisplay();
        }
    }

}
