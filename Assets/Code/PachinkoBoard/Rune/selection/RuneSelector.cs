using System.Collections.Generic;
using UnityEngine;

public class RuneSelector : MonoBehaviour
{
    public  List<RuneCountItem> baseRunePool = new List<RuneCountItem>(); // Initial pool of all runes (Filled in Editor - can have duplicates)
    private List<Rune> currentRunePool; // Pool that changes during the game session
    public int runesToOffer = 3; // Number of runes to offer the player to choose from

    void Awake() {
        InitRunePool(); // Initialize the current rune pool
        Debug.LogWarning("First round of rune selection: ------------------- "+currentRunePool.Count);
        StartRuneSelectionRound(); // Start the rune selection round
        Debug.LogWarning("Example: Player chose a rune and removed it from the pool. Starting another round: -------------------");
        RemoveRuneFromPool(baseRunePool[0].rune); // Example of removing a rune from the base pool
        Debug.LogWarning("Second round of rune selection: ------------------- "+currentRunePool.Count);
        StartRuneSelectionRound(); // Start another rune selection round
    }

    public List<Rune> GetRandomRunes(List<Rune> runeSourcePool, int count)
    {
        if (runeSourcePool == null || runeSourcePool.Count == 0)
        {
            Debug.LogWarning("Rune pool is empty or null.");
            return new List<Rune>(); // Return empty list if pool is empty
        }

        if (count > runeSourcePool.Count)
        {
            Debug.LogWarning("Requested rune count exceeds the pool size. Returning all available unique runes.");
            count = runeSourcePool.Count; // Adjust count if it's more than available runes
        }

        List<Rune> randomRunes = new List<Rune>();
        HashSet<Rune> selectedRunes = new HashSet<Rune>(); // Use a HashSet to track unique runes
        List<Rune> poolCopy = new List<Rune>(runeSourcePool);

        while (randomRunes.Count < count && poolCopy.Count > 0)
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

    // Example function to get runes for the player to choose from (you would call this when you need to offer runes to the player) (No changes needed here)
    public List<Rune> OfferRunesToPlayer()
    {
        List<Rune> offeredRunes = GetRandomRunes(currentRunePool, runesToOffer);
        return offeredRunes;
    }

    // Example function to handle player choosing a rune (No changes needed here)
    public void PlayerChoseRune(Rune chosenRune)
    {
        // Apply the effect of the chosenRune in your game logic here
        Debug.Log("Player chose rune: " + chosenRune.runeName + ". Effect: " + chosenRune.description);

        RemoveRuneFromPool(chosenRune); // Remove the chosen rune from the current pool for this session
        // If you want permanent removal, you would modify the baseRunePool as well, or have a separate "owned runes" system.
    }

    public void DisplayOfferedRunes(List<Rune> offeredRunes)
    {
        // Get UI elements to display rune options (e.g., Buttons)
        // For each rune in offeredRunes:
        //   - Create a UI Button or use existing ones
        //   - Set the button's image to rune.runeImage
        //   - Set the button's text to rune.runeName
        //   - Attach an event listener to the button that calls PlayerChoseRune(rune) when clicked

        Debug.Log("Displaying offered runes in UI (UI code needs to be implemented):");
        foreach (Rune rune in offeredRunes)
        {
            Debug.Log("- " + rune.runeName + ": " + rune.description);
        }
    }

    // Example of how to use the system in your game logic: (No changes needed here)
    public void StartRuneSelectionRound()
    {
        List<Rune> runesToOffer = OfferRunesToPlayer();
        DisplayOfferedRunes(runesToOffer); // Display runes in UI for player to choose
    }
}