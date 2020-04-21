using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem")]
public class ItemClass : ScriptableObject
{
    public new string name;
    public string description;
    public string sprite;
    public int id;
    public int price;
    public int count;
    

    public ItemClass(string name, string description, int id, int price, string sprite)
    {
        this.name = name;
        this.description = description;
        this.id = id;
        this.price = price;
        this.sprite = sprite;
    }
}
