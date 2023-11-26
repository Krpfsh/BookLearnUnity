using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paladin : Character
{
    public Weapon weapon;
    public Paladin(string name, int exp, Weapon weapon) : base(name , exp)
    {
        this.weapon = weapon;
    }
    public override void PrintStatsInfo()
    {
        Debug.Log($"Hero:{name}, Exp - {exp} , Weapon: {weapon.name} , DMGWeapon: {weapon.damage}");
    }
}
