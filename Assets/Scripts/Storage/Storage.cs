using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Storage : MonoBehaviour 
{
    //public abstract void takeAll(List<Items> items);
    //public abstract void keepAll(List<Items> items);
    public abstract void store(Items item);
    public abstract void remove(Items item);
}
