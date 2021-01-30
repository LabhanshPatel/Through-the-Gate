using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[CreateAssetMenu(menuName = "Create Scriptable obj", fileName = "new scriptable obj")]
[System.Serializable]
public class Scriptable_Obj : ScriptableObject
{
    
    [TextArea(5,5)] public string[] description;
}
