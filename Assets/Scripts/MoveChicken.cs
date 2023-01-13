using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChicken : MoveAnimal
{
    //parent already has this diet
    //protected override List<string> diet => new List<string>() { "fish" };
    //=> Shorthand for property
    protected override float speed => 2.5f;
}
