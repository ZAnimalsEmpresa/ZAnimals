using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUI : MonoBehaviour
{
    [Header("Dependencies")]
    public GameObject levelWon;
    public GameObject levelLost;
    public GameObject HUD;

    public void ShowHUD()
    {
        levelWon.SetActive(false);
        levelLost.SetActive(false);
        HUD.SetActive(true);
    }

    public void ShowWonMenu()
    {
        levelWon.SetActive(true);
        levelLost.SetActive(false);
        HUD.SetActive(false);
    }

    public void ShowLostMenu()
    {
        levelWon.SetActive(false);
        levelLost.SetActive(true);
        HUD.SetActive(false);
    }
}
