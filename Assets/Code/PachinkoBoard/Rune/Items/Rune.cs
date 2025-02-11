using SerializeReferenceEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New Rune", menuName = "Runes/Rune")]
public partial class Rune : ScriptableObject
{
    public RuneShape runeShape;
    public string runeName;
    [TextArea]
    public string description;
    public Sprite runeSprite;

    [SerializeReference, SR]
    public IRuneAction action;
}
