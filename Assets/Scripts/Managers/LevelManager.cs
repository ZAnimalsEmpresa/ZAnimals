using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public LevelUI levelUI;
    // Private
    private LevelStates _levelStates = LevelStates.NONE;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LevelWon()
    {
        levelUI.ShowWonMenu();
    }
    private void LevelLost()
    {
        levelUI.ShowLostMenu();
    }
}
public enum LevelStates
{
    NONE,
    START,
    WON,
    LOST
}
