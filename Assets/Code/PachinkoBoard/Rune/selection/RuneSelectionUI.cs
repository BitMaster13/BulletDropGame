using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class RuneSelectorUI : MonoBehaviour
{
    public RuneItemUI runeItemOne;
    public RuneItemUI runeItemTwo;
    public RuneItemUI runeItemThree;
    
    public RuneSelector runeSelector;
    private void Start()
    {
        ShowRunes(runeSelector.GetRandomRunes());
    }
    public void HideUI()
    {
        // Disable the main UI panel to hide it
        gameObject.SetActive(false);
    }
    public void ShowRunes(List<Rune> runes)
    {
        gameObject.SetActive(true);

        if (runes[0] != null)
        {
            runeItemOne.gameObject.SetActive(true);
            runeItemOne.DisplayRune(runes[0], this);
        }
        else
        {
            runeItemOne.gameObject.SetActive(false);
        }

        if (runes[1] != null)
        {
            runeItemTwo.gameObject.SetActive(true);
            runeItemTwo.DisplayRune(runes[1], this);
        }
        else
        {
            runeItemTwo.gameObject.SetActive(false);
        }

        if (runes[2] != null)
        {
            runeItemThree.gameObject.SetActive(true);
            runeItemThree.DisplayRune(runes[2], this);
        }
        else
        {
            runeItemThree.gameObject.SetActive(false);
        }

    }

    public void OnRuneSelected(Rune selectedRune)
    {
        Debug.Log("Rune selected: " + selectedRune.runeName);
        HideUI();
    }
}