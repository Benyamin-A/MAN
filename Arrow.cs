using UnityEngine;

public class Arrow: Weapon
{
    public override int Damage { get; protected set; }
    public override int CountsCarried { get; protected set; }
    public Arrow()
    {
        Damage = 5;
    }

    public override void swing()
    {
        
        Debug.Log("From the Arrow: arrow stab "+Damage); 
    }

    public override void throws()
    {
        Debug.Log("From the Arrow: whisle sound");
    }

}
