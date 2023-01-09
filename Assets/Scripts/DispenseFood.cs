using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispenseFood : MonoBehaviour
{
    public List<GameObject> foodSelect;
    public List<GameObject> foodDrop;
    private int index = 0;
    private int steakCount = 0;
    private bool foodAllowed = true; 

    // Start is called before the first frame update
    void Start()
    {
        foodSelect[index].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //make current inactive
            foodSelect[index].SetActive(false);
            index++;
            if (index >= foodSelect.Count)
            {
                index = 0;
            }

            //make next selection active
            foodSelect[index].SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //make current inactive
            foodSelect[index].SetActive(false);
            index--;
            if (index < 0)
            {
                index = foodSelect.Count - 1;
            }

            //make next selection active
            foodSelect[index].SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Steaks are allowed twice, others not
            if (foodSelect[index].tag == "steak")
            {
                if (steakCount < 2)
                { 
                    foodAllowed = true;
                    steakCount++;
                }
            }

            if (foodAllowed)
            {
                foodSelect[index].SetActive(false);
                //Instantiate new food object
                Instantiate(foodDrop[index], transform.position, transform.rotation);
                foodAllowed = false;
            }
       
        }
    }
}
