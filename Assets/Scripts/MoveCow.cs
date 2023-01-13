using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCow : MoveAnimal
{
    //Expression body, shorthand for property. Use blockbody for property otherwise
    protected override List<string> diet => new List<string>() { "carrot", "banana" };
    protected override float speed => 2.0f;
}
