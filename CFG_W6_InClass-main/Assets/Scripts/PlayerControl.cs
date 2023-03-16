using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControl : MonoBehaviour
{
    //variables keep track of information
    //this is a variable
    bool letMove = true;

    public float speed;

    //make sure to add this code in when you want to link them up
    public GameManager myManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    { 
        //this string of code is based on whether the player has flipped the switch on or off, this will affect how the player will move if at all.
        if (letMove)
        {
            Vector3 newPos = transform.position;
            if (Input.GetKey(KeyCode.W))
            {
                newPos.z = newPos.z + speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                newPos.z = newPos.z - speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A))
            {
                newPos.x = newPos.x - speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                newPos.x = newPos.x + speed * Time.deltaTime;
            }
            transform.position = newPos;
        }

        // "Lets make it so that this for loop only runs when we press space. we want to run the for loop inside that is statement because in general you do not want to constantly loop inside Update!
        if (Input.GetKey(KeyCode.Space))
        {
            //this for loop is going to use the Distance function to see how close an enemy is, here is a reference link: https://docs.unity3d.com/ScriptReference/Vector3.Distance.html
            for (int i = 0; i < myManager.enemyNum; i++)
            {
                //The first and second parameters are the points we want to check how far between they are, Then we use a < operator to check if that distance is within a certain range. In this case, i'm using 4
                if (Vector3.Distance(transform.position, myManager.enemies[i].transform.position) < 4f)
                {
                    Vector3 enemyPos = myManager.enemies[i].transform.position;
                    Vector3 resetPos = new Vector3(Random.Range(-2, 20), enemyPos.y, Random.Range(-2, 15));
                    myManager.enemies[i].transform.position = resetPos;
                    Debug.Log("near an enemy!!!");
                }
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Collect")
        {
            //This line: 1. Accesses the game manager script 2. Accesses the collectables list 3. Removes the triggered collectable from the list
            myManager.allCollectables.Remove(other.gameObject);
            Destroy(other.gameObject);
        }

        for(int i = 0; i < myManager.enemyNum; i++)
        {
            if(other.gameObject == myManager.enemies[i])
            {
                letMove = false;
                Debug.Log("hit!");
            }
        }
    }
}
