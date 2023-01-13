using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDog : MoveAnimal
{
    //Expression body, shorthand for property. Use blockbody for property otherwise
    protected override List<string> diet => new List<string>() { "meat", "fish", "banana", "carrot" };
    protected override float speed => 3.5f;
}
