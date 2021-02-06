// Create a non-MonoBehaviour class which displays
// messages when a game is loaded.
using UnityEngine;

class MyClass
{
    public static Arrow arrow = new Arrow();

    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad()
    {
        arrow.swing();
        arrow.throws();
        arrow.pickUp();
    }

}
