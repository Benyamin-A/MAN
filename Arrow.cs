using UnityEngine;

public class Arrow: Weapon
{
    public override void swing()
    { 
        Debug.Log("From the Arrow: arrow stab"); 
    }

    public override void throws()
    {
        Debug.Log("From the Arrow: whisle sound");
    }
    


    

}
