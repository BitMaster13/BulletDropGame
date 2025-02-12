using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class RuneSelectorUI : MonoBehaviour
{
    public GameObject runeItemUIPrefab;
    public Transform runeContainer;
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
        // Clear any existing cards
        foreach (Transform child in runeContainer)
        {
            Destroy(child.gameObject);
        }
        // Instantiate rune cards
        foreach (Rune rune in runes)
        {
            GameObject cardGO = Instantiate(runeItemUIPrefab, runeContainer);
            RuneItemUI runeItemUI = cardGO.GetComponent<RuneItemUI>(); // (See below)
            runeItemUI.DisplayRune(rune, this); // Pass 'this' (the UI manager)
        }
    }

    public void OnRuneSelected(Rune selectedRune)
    {
        Debug.Log("Rune selected: " + selectedRune.runeName);
        HideUI();
    }
}