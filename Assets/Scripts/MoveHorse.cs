using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHorse : MoveAnimal
{
    //Expression body, shorthand for property. Use blockbody for property otherwise
    protected override List<string> diet => new List<string>() { "carrot", "steak" };
    protected override float speed => 3.0f;

    //Extra variable for horse. It has to eat two foods
    [SerializeField] private int feedCount = 0;

    public override void OnTriggerEnter(Collider other)
    {
        //Remember: at least ONE object must have Rigidbody and One must have IsTrigger!
        //if (other.tag == "banana") //eat
        if (diet.Contains(other.tag))
        {
            //necessary extra for feeding horse
            feedCount++;
            //Remove food here instead
            Destroy(other);

            if (feedCount >= 2)
            {
                //Animal is fed and walks away to side
                if (position == (int)leftOrRight.left)
                {
                    direction = Vector3.left;
                }
                else if (position == (int)leftOrRight.right)
                {
                    direction = Vector3.right;
                }
                //Score
                gameManager.Score();
                //Food needs to be allowed again
                dispenseFood.ResetDispenser(position);

                feedCount = 0;
            }
            else
            {
                //Animal walks back
                direction = Vector3.back;
            }
        }
        else if (other.tag == "exit")
        {
            Destroy(gameObject);
            spawnManager.SpawnAnimal(x);
        }
        else if (other.tag == "backwall")
        {
            //Animal walks forward after walking back
            direction = Vector3.forward;
        }
        else //reject
        {
            //Reject food: push it away
            RejectFood(other);
            //Food needs to be allowed again
            dispenseFood.ResetDispenser(position);
            //Animal walks back
            direction = Vector3.back;
        }
    }
}
