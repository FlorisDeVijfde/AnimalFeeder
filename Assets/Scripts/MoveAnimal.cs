using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnimal : MonoBehaviour
{
    private float speed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "banana")
        {
            transform.Translate(speed * Time.deltaTime * Vector3.right);
        } else
        {
            transform.Translate(speed * Time.deltaTime * Vector3.back);
        }
    }
}
