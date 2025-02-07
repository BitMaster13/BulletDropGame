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

    internal void runeHit(GameObject runeGO)
    {
        Rune rune = runeGO.GetComponent<Rune>();
        if (rune != null)
        {
            rune.action.ExecuteAction(this);
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

    internal void MakeDamage(int damageAmount)
    {
        Debug.LogError("MakeDamage" + damageAmount);
    }
}
