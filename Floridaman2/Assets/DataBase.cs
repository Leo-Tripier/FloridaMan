using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBase : MonoBehaviour
{
    public List<ItemClass> items;
    public List<EntityClass> entities;


    public DataBase()
    {
        ItemClass empty = new ItemClass("","", 0, 999,"test");
        ItemClass yeezys = new ItemClass("yeezys", "who wants another dash ?", 1, 50, "test");
        items.Add(empty);
        items.Add(yeezys);
        
        EntityClass player = new EntityClass(1,10, (200,200),"Florida Man");
        EntityClass croco = new EntityClass(5,25,(35,35),"Evil Croc");
        entities.Add(player);
        entities.Add(croco);
    }
}
