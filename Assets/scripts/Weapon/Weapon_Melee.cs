using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Melee : WeaponBase
{
    // Start is called before the first frame update
    void Start()
    {

            damage          = 10f;
            actionTime      = 0.5f;
            cooldown        = 0.5f;
            range           = 3f;
            attackTimer     = 0f;
    }

}
