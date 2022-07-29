using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float MaxHp;
    public float MaxMp;

    public float Dmg;

    public float Str;
    public float Dex;
    public float Vit;
    public float Int;

    public float Exp;
    public float Lvl;

    public float Speed;

    //public float Score;

    public Player()
    {
        MaxHp = 10.0f;
        MaxMp = 10.0f;

        Dmg = 2.0f;

        Str = 0;
        Dex = 0;
        Vit = 0;
        Int = 0;

        Exp = 0;

        Lvl = 1;

        Speed = 5.0f;
    }
}
