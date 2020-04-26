using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp.Assets.Resources.Scripts.Enum;
using UnityEngine;

public class Item : MonoBehaviour
{
    protected ITEM_TYPE type;
    protected string itemName;
    protected GameObject prefab;
    public virtual void useItem()
    {
        Debug.Log("Um item generico foi usado!");
    }
    public ITEM_TYPE getType()
    {
        return this.type;
    }
    public string getItemName()
    {
        return this.itemName;
    }
    public void setItemName(string name)
    {
        this.itemName = name;
    }
    public virtual void dropItem()
    {
        Debug.Log("Dropando item generico!");
    }
}
