using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> animals;

    private float x = 2.0f;
    private float y = 0.6f;
    private float z = -14.0f;

    // Start is called before the first frame update
    void Start()
    {
        //First two random animals
        SpawnAnimal(x);
        SpawnAnimal(x * -1);
    }

    public void SpawnAnimal(float x_input)
    {
        x = x_input;
        Vector3 pos = new Vector3(x, y, z);
        int random = Random.Range(0, animals.Count);
        Instantiate(animals[random], pos, animals[random].transform.rotation);
    }
}
