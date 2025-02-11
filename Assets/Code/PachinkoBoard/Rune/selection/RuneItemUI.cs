using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RuneItemUI : MonoBehaviour
{
    public TextMeshProUGUI runeNameText;
    public Image runeIconImage;
    public TextMeshProUGUI runeDescriptionText;
    private Rune myRune;
    private RuneSelectorUI selectionUI;

    public void DisplayRune(Rune rune, RuneSelectorUI uiManager)
    {
        myRune = rune;
        selectionUI = uiManager;

        runeNameText.text = rune.runeName;
        runeIconImage.sprite = rune.runeSprite;
        runeDescriptionText.text = rune.description;
        //set on click listener
        Button button = GetComponent<Button>(); 
        button.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        selectionUI.OnRuneSelected(myRune); // Notify the UI manager
    }
}