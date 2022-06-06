using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public static bool trigger = false;

    public void Triggers()
    {
        trigger = true;
    }
}
