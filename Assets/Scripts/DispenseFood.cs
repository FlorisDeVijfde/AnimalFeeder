using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispenseFood : MonoBehaviour
{
    public List<GameObject> foodSelect;
    public List<GameObject> foodDrop;
    public GameObject plateau1;
    public GameObject plateau2;

    //Visible in inspector without being public
    [SerializeField] private int[] steakOrCarrotCounts = { 0, 0 };
    [SerializeField] private int[] otherCounts = { 0, 0 };

    private int index = 0;
    private enum leftOrRight { left, right };
    private int position;

    // Start is called before the first frame update
    void Start()
    {
        foodSelect[index].SetActive(true);
        //Position of Dispenser starts left
        position = (int)leftOrRight.left;
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

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(plateau1.transform.position.x, 3.0f, plateau1.transform.position.z);
            position = (int)leftOrRight.left;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position = new Vector3(plateau2.transform.position.x, 3.0f, plateau2.transform.position.z);
            position = (int)leftOrRight.right;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Steaks and carrots may be dropped twice on the same plateau, others once.
            //Other foods are never allowed with another food. Only combinations of steak and carrot or set of two steaks/two carrots.
            List<string> horsefood = new List<string>() { "steak", "carrot" };

            //if (foodSelect[index].tag == "steak")
            if (horsefood.Contains(foodSelect[index].tag))
            {
                if (steakOrCarrotCounts[position] < 2 && otherCounts[position] < 1)
                {
                    dropFood();
                    steakOrCarrotCounts[position]++;
                }
            }
            else
            {
                if (steakOrCarrotCounts[position] == 0 && otherCounts[position] < 1)
                {
                    dropFood();
                    otherCounts[position]++;
                }
            }
        }
    }

    void dropFood()
    {
            //foodSelect[index].SetActive(false);
            //Instantiate new food object and forbid new food until food is dismissed or eaten
            Instantiate(foodDrop[index], transform.position, transform.rotation);
    }

    public void ResetDispenser(int pos)
     {
            //Allow new food by resetting counters
            steakOrCarrotCounts[pos] = 0;
            otherCounts[pos] = 0;
     }
}