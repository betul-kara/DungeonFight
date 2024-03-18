using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    public void UpgradeHealth()
    {
        Player.Instance.health += 20;
    }

    public void UpgradeAttack()
    {

    }

    public void UpgradeShield()
    {

    }
}
