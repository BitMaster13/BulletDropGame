using System.Collections.Generic;
using UnityEngine;

public class RuneSelector : MonoBehaviour
{
    public  List<RuneCountItem> baseRunePool = new List<RuneCountItem>(); // Initial pool of all runes (Filled in Editor - can have duplicates)
    private List<Rune> currentRunePool; // Pool that changes during the game session
    public int runesToOffer = 3; // Number of runes to offer the player to choose from

    void Awake() {
        InitRunePool(); // Initialize the current rune pool
    }

    public List<Rune> GetRandomRunes()
    {
        if (currentRunePool == null || currentRunePool.Count == 0)
        {
            Debug.LogWarning("Rune pool is empty or null.");
            return new List<Rune>(); // Return empty list if pool is empty
        }

        List<Rune> randomRunes = new List<Rune>();
        HashSet<Rune> selectedRunes = new HashSet<Rune>(); // Use a HashSet to track unique runes
        List<Rune> poolCopy = new List<Rune>(currentRunePool);

        while (randomRunes.Count < runesToOffer && poolCopy.Count > 0)
        {
            int randomIndex = Random.Range(0, poolCopy.Count);
            Rune selectedRune = poolCopy[randomIndex];
            poolCopy.RemoveAt(randomIndex); // Remove from the copy to avoid re-selection in this round

            if (!selectedRunes.Contains(selectedRune)) // Check if this rune (or a rune with the same properties) is already selected
            {
                randomRunes.Add(selectedRune);
                selectedRunes.Add(selectedRune); // Add to the HashSet to mark as selected
            }
            // If the rune was already selected (due to duplicates in the source pool), the loop continues to find a unique one
        }

        return randomRunes;
    }

    public void RemoveRuneFromPool(Rune chosenRune)
    {
        if (currentRunePool.Contains(chosenRune))
        {
            currentRunePool.Remove(chosenRune);
        }
        else
        {
            Debug.LogWarning("Chosen rune not found in the current rune pool.");
        }
    }

    // Function to reset the current rune pool to the base pool (for starting a new round/session) (No changes needed here)
    public void InitRunePool()
    {
        List<Rune> allRunes = new List<Rune>();
        foreach (RuneCountItem runeEntry in baseRunePool)
        {
            for (int i = 0; i < runeEntry.count; i++)
            {
                allRunes.Add(runeEntry.rune);
            }
        }
        currentRunePool = allRunes;
    }
}