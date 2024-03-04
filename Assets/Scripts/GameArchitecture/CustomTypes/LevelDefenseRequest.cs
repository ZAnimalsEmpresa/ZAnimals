using UnityEngine;

[System.Serializable]
public class LevelDefenseRequest
{
    public BaseSO[] bases;

    public LevelDefenseRequest(BaseSO[] bases)
    {
        this.bases = bases;
    }
}
