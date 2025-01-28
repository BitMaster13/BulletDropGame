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

    internal void pachinkoBallHitRune(GameObject gameObject)
    {
        RuneData runrData = gameObject.GetComponent<Rune>().runeData;
        if(runrData != null)
        {
            switch (runrData.type)
            {
                case RuneData.RuneType.Attack:
                    Debug.Log("Attack rune hit"+runrData.value);
                    break;
                case RuneData.RuneType.Health:
                    Debug.Log("Health rune hit"+runrData.value);
                    break;
                case RuneData.RuneType.Defence:
                    Debug.Log("Defence rune hit"+runrData.value);
                    break;
                default:
                    Debug.LogError("Unknown rune type", gameObject);
                    break;
            }
        }
    }
}
