using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DispenseFood;

public class MoveAnimal : MonoBehaviour
{
    private DispenseFood dispenseFood;
    private SpawnManager spawnManager;
    private Rigidbody foodRb;
    private GameManager gameManager;

    private float speed = 3.0f;
    private Vector3 direction = Vector3.forward;
    private enum leftOrRight { left, right };
    private int position = 0; 
    float x = 2;


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

    private void RejectFood(Collider food)
    {
        foodRb = food.GetComponent<Rigidbody>();
        float speed = 10.0f;
        foodRb.AddForce(Vector3.forward * speed, ForceMode.Impulse);
        //Update reject score
        gameManager.AddReject();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Remember: at least ONE object must have Rigidbody and One must have IsTrigger!
        if (other.tag == "banana") //eat
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
