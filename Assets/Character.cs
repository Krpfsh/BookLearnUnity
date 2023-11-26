using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string name;
    public int exp = 0;
    public Character()
    {
        name = "Not assigned";
    }
     public Character(string name, int exp)
    {
        this.name = name;
        this.exp = exp;
    }
    public virtual void PrintStatsInfo()
    {
        Debug.Log($"Hero:{name}, Exp - {exp}");
    }
    private void Reset()
    {
        this.name = "Not assigned";
        this.exp = 0;
    }
}
public struct Weapon
{
    public string name;
    public int damage;
    public Weapon(string name, int damage)
    {
        this.name = name;
        this.damage = damage;
    }
    public   void PrintWeaponStatsInfo()
    {
        Debug.Log($"Weapon Name: {name}, Damage - {damage}");
    }
}