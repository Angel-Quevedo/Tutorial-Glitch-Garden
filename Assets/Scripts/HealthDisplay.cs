using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] int health = 100;
    Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        health = health - PlayerPrefsController.GetDifficulty();
        if (health <= 0)
            health = 1;

        healthText = GetComponent<Text>();
        UpdateDisplay();
    }


    public int GetStars()
    {
        return health;
    }

    private void UpdateDisplay()
    {
        healthText.text = health.ToString();
    }

    public void AddHealth(int amount)
    {
        health += amount;
        UpdateDisplay();
    }

    public void ReduceHealth(int amount)
    {
        if (health > 0)
        {
            health -= amount;
            UpdateDisplay();

            if (health <= 0)
                FindObjectOfType<GameController>().HandleLoseCondition();
        }
    }
   
}
