using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBase", menuName = "Scriptable Object/Base")]
public class BaseSO : ScriptableObject
{
    public BaseType baseType;

    public float baseHP;
}
public enum BaseType
{
    Main,
    Secondary
}