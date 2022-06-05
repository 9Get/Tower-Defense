using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources : MonoBehaviour
{
    public int gold, towerCost, enemyCost, lives;
    
    public void WhenBuild()
    {
        gold -= towerCost;
    }

    public void WhenKilled()
    {
        gold += enemyCost;
    }

    public void LostLife()
    {
        lives--;
    }
}
