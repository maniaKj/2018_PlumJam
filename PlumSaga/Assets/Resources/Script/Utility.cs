using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Util
{
    public static int GenerateRandomInt(int range)
    {
        return Mathf.RoundToInt(Random.Range(0.0f, range));
    }
}
