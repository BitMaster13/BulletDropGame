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
}
