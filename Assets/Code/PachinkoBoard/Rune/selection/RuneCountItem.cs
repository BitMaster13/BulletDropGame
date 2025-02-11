using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class RuneCountItem
{
    public Rune rune;  // Key
    public int count;    // Value

    public RuneCountItem(Rune rune, int count)
    {
        this.rune = rune;
        this.count = count;
    }
}
