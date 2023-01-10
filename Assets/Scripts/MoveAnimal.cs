using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DispenseFood;

public class MoveAnimal : MonoBehaviour
{
    private DispenseFood dispenseFood;

    private float speed = 3.0f;
    private Vector3 direction = Vector3.forward;
    private enum leftOrRight { left, right };
    private int position;

    // Start is called before the first frame update
    void Start()
    {
        dispenseFood = FindObjectOfType<DispenseFood>();
        if (transform.position.x > 0)
        {
            position = (int)leftOrRight.left;
        }
        else
        {
            position = (int)leftOrRight.right;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * direction);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "banana")
        {
            //Animal is fed and walks away to side
            direction = Vector3.right;
            //Remove food
            Destroy(other);
        } else
        {
            //Animal walks back
            direction = Vector3.back;
            //Reject food and relocate to middle
            other.transform.position = new Vector3(-2, -1, 0);
        }
        dispenseFood.ResetDispenser(position);
    }
}
