using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateauDetector : MonoBehaviour
{
    private List<string> tags;
    private Rigidbody foodRb;
    private BoxCollider foodBc;

    // Start is called before the first frame update
    void Start()
    {
        tags = new List<string>(){"carrot", "banana", "steak", "fish"};
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //If it is food, shut down gravity and activate isTrigger
        if (tags.Contains(other.tag))
        {
            foodRb = other.GetComponent<Rigidbody>();
            foodRb.useGravity = false;
            foodRb.isKinematic = true;

            foodBc = other.GetComponent<BoxCollider>();
            foodBc.isTrigger = true;
        }
    }
}
