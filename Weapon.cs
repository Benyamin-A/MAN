using UnityEngine;

public abstract class Weapon
{

    private int _damage;
    private int _countsCarried;

    public abstract void throws();
     
    public abstract void swing();
   
    public void pickUp() 
    {
        Debug.Log("From the Weapon: picked up");
    }

}
