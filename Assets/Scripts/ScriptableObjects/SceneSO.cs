using UnityEngine;

[CreateAssetMenu(fileName = "NewScene", menuName = "Scriptable Object/Scene")]
public class SceneSO : ScriptableObject
{

    [Header("Scene Information")]
    public string sceneName;
}
