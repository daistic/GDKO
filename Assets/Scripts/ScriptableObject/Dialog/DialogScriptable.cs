using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "DialogScriptable", menuName = "Scriptable Objects/DialogScriptable")]
public class DialogScriptable : ScriptableObject
{
    [TextArea(1, 5)]
    [SerializeField] List<string> lines = new List<string>();
    [SerializeField] bool isEventDialog;

    public List<string> getLines() { return lines; }

    public bool getIsEventDialog () { return isEventDialog; }
}
