using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour
{

    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULITY_KEY = "difficulity";
    const string LEVEL_KEY = "level_unlocked_";

    public static void SetMasterVolume(float volume)
    {
        if (volume > 0f && volume < 1f)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Invalid volume: " + volume);
        }
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void UnlockLevel(int level)
    {
        if (level <= SceneManager.sceneCountInBuildSettings - 1)
        {
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1); //Use 1 for true
        }
        else
        {
            Debug.LogError("Unlock level too high: " + level);
        }
    }

    public static bool IsLevelUnlocked(int level)
    {
        if (level <= SceneManager.sceneCountInBuildSettings - 1)
        {
            return (PlayerPrefs.GetInt(LEVEL_KEY + level.ToString()) == 1);
        }
        else
        {
            Debug.LogError("Invlaid level: " + level);
            return false;
        }
    }

    public static void SetDifficulity(float difficulity)
    {
        if (difficulity >= 0f && difficulity <= 1f)
        {
            PlayerPrefs.SetFloat(DIFFICULITY_KEY, difficulity);
        }
        else
        {
            Debug.LogError("Invlaid difficulity: " + difficulity);
        }
    }

    public static float GetDifficulity()
    {
        return PlayerPrefs.GetFloat(DIFFICULITY_KEY);
    }
}
