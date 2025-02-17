using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "duckDialog", menuName = "Scriptable Objects/duckDialog")]
public class duckDialog : ScriptableObject
{
    [TextArea(1, 5)]
    [SerializeField] List<string> lines = new List<string>();
    [SerializeField] List<Sprite> sprites = new List<Sprite>();
    [SerializeField] bool isEventDialog;

    public List<string> getLines() { return lines; }

    public List<Sprite> getSprites() { return sprites; }

    public bool getIsEventDialog() { return isEventDialog; }
}
