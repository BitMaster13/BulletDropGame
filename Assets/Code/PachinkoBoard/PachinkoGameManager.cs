using System;
using UnityEngine;

public class PachinkoGameManager : MonoBehaviour
{
    internal void enteredBattleBox(GameObject gameObject)
    {
        DestroyPachinkoBall(gameObject);
    }

    public void DestroyPachinkoBall(GameObject ball)
    {
        Destroy(ball);
    }

    internal void runeHit(DraggableRune rune)
    {
        RuneData runrData = rune.runeData;
        if (runrData != null)
        {
            switch (runrData.type)
            {
                case AbilityType.Attack:
                    Debug.Log("Attack rune hit" + runrData.value);
                    break;
                case AbilityType.Health:
                    Debug.Log("Health rune hit" + runrData.value);
                    break;
                case AbilityType.Defence:
                    Debug.Log("Defence rune hit" + runrData.value);
                    break;
                default:
                    Debug.LogError("Unknown AbilityType" + runrData.type);
                    break;
            }
        }
    }

    internal void enteredBattleBox(BattleBox battleBox, GameObject pachinkoBall)
    {
        DestroyPachinkoBall(pachinkoBall);
        BattleBoxData battleBoxData = battleBox.battleBoxData;

        if (battleBoxData != null)
        {
            switch (battleBoxData.type)
            {
                case AbilityType.Attack:
                    Debug.Log("Attack box hit" + battleBoxData.value);
                    break;
                case AbilityType.Health:
                    Debug.Log("Health box hit" + battleBoxData.value);
                    break;
                case AbilityType.Defence:
                    Debug.Log("Defence box hit" + battleBoxData.value);
                    break;
                default:
                    Debug.LogError("UnknownAbilityType" + battleBoxData.type);
                    break;
            }
        }
    }
}
