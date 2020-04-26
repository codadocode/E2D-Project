using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp.Assets.Resources.Scripts.Enum;
using UnityEngine;

public class Keycard : Item
{
    void Awake()
    {
        this.type = ITEM_TYPE.KEYCARD;
    }

    public override void useItem()
    {
        //Use Keycard
    }

    public override void dropItem()
    {
        //Drop Keycard
    }
}
