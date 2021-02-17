using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{

    const string MASTER_VOLUME_KEY = "MasterVolume";
    const string DIFFICULTY_KEY = "DefaultDifficulty";


    public static void SetMasterVolume(float value)
    {
        PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, value);
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void SetDifficulty(int value)
    {
        PlayerPrefs.SetInt(DIFFICULTY_KEY, value);
    }

    public static int GetDifficulty()
    {
        return PlayerPrefs.GetInt(DIFFICULTY_KEY);
    }

}
