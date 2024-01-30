using UnityEngine;

[CreateAssetMenu(fileName = "PlayerPath", menuName = "Scriptable Object/Player Path")]
public class PlayerPathSO : ScriptableObject
{
    public LevelEntanceSO levelEntance;
    public SceneSO lastScene;
}
