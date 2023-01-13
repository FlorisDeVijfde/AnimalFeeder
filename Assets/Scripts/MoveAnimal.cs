using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DispenseFood;

public class MoveAnimal : MonoBehaviour
{
    protected DispenseFood dispenseFood;
    protected SpawnManager spawnManager;
    protected Rigidbody foodRb;
    protected GameManager gameManager;

    //Properties for inheritance
    //Must be property for override inheritance
    //Protected is inherited, private not.
    //Expression body, shorthand for property. Use blockbody for property otherwise.
    protected virtual List<string> diet => new List<string>() { "fish" };
    //Blockbody instead of expression body, more code for property
    protected virtual float speed
    {
        get
        {
            return 2.0f;
        }
    }

    protected Vector3 direction = Vector3.forward;
    protected enum leftOrRight { left, right };
    protected int position = 0; 
    protected float x = 2;

    // Start is called before the first frame update
    void Start()
    {
        dispenseFood = FindObjectOfType<DispenseFood>();
        spawnManager = FindObjectOfType<SpawnManager>();
        gameManager = FindObjectOfType<GameManager>();

        //trying to create new monobehavious with new keyword not allowed...
        //dispenseFood = new DispenseFood();
        //gameManager = new GameManager();

        //From camera perspective, on which track the animal is
        if (transform.position.x < 0)
        {
            position = (int)leftOrRight.left;
            x = -2;
        }
        else
        {
            position = (int)leftOrRight.right;
            x = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Move in current directton
        transform.Translate(speed * Time.deltaTime * direction);
    }

    public void RejectFood(Collider food)
    {
        foodRb = food.GetComponent<Rigidbody>();
        float speed = 10.0f;
        foodRb.AddForce(Vector3.forward * speed, ForceMode.Impulse);
        //Update reject score
        gameManager.AddReject();
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        //Remember: at least ONE object must have Rigidbody and One must have IsTrigger!
        //if (other.tag == "banana") //eat
        if (diet.Contains(other.tag))
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
            //Remove food
            Destroy(other);
            //Score
            gameManager.Score();
            //Food needs to be allowed again
            dispenseFood.ResetDispenser(position);
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
