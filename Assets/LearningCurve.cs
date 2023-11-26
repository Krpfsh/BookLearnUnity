using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningCurve : MonoBehaviour
{
    public GameObject directionLight;

    private Transform lightTransform;
    // Start is called before the first frame update
    void Start()
    {
        lightTransform = directionLight.GetComponent<Transform>();
        Debug.Log(lightTransform.localPosition);
        //Character hero = new Character();
        //Character hero2 = hero;
        //hero2.name = "Sir Krane";

        //hero.PrintStatsInfo();
        //hero2.PrintStatsInfo();

        //Character heroine = new Character("Nikita", 32);
        //heroine.PrintStatsInfo();


        //Weapon hammer = new Weapon("Hammer", 1);
        //Paladin knight = new Paladin("Sir Artur", 100, hammer);
        //knight.PrintStatsInfo();
        
        //Weapon weapon = new Weapon("Sword", 5);
        //Weapon weapon2 = weapon;
        
        //weapon2.name = "Bow";
        //weapon2.damage = 3;
        //weapon.PrintWeaponStatsInfo();
        //weapon2.PrintWeaponStatsInfo();

    }

}
