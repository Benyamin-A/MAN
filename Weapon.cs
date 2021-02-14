using UnityEngine;

public abstract class Weapon
{

    abstract public int Damage { get; protected set; }
    abstract public int CountsCarried { get; protected set; }

    abstract public void throws();

    abstract public void swing();
   
    public void pickUp() 
    {
        Debug.Log("From the Weapon: picked up");
    }

}
