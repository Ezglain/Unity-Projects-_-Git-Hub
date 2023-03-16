using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //these are variables
    public int objNum;
    public GameObject objCollect;

    //these are variables
    public Transform leftTop;
    public Transform rightBottom;

    // This line both declares and initializes our list
    //remember that a line of code in this case the list becomes available to other code like Player count script once made public by adding the word public to the front of it dont forget to add the code public GameManager myManager; in the player script in order to link both codes up and make it work
    public List<GameObject> allCollectables = new List<GameObject>();

    //these are variables
    public int enemyNum;
    public GameObject enemyObj;

    //This is an array because brackets []
    //this line of code declares the array
    public GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        //this line of code executes/initialize the enemy array meaning it gives it a set number of spots
        enemies = new GameObject[enemyNum];

        //This is a for loop, for the collectables
        for(int i = 0; i < objNum; i++)
        {
            //This code is for the position of the collectables
            float newX = Random.Range(leftTop.position.x, rightBottom.position.x);
            float newZ = Random.Range(rightBottom.position.z, leftTop.position.z);
            // we are saving each individual number as a vector3 a cordinate so new postions every time.
            Vector3 newPos = new Vector3(newX, transform.position.y, newZ);
            // Instantiate means to create, this code is for the cretion of the collectables in game.
            GameObject newObj = Instantiate(objCollect, newPos, Quaternion.identity);
            // This adds each new collectable object to our list
            allCollectables.Add(newObj);
        }

        //This is a for loop, for the enemy
        for (int i = 0; i < enemyNum; i++)
        {
            float newX = Random.Range(leftTop.position.x, rightBottom.position.x);
            float newZ = Random.Range(rightBottom.position.z, leftTop.position.z);
            Vector3 newPos = new Vector3(newX, transform.position.y, newZ);
            GameObject newObj = Instantiate(enemyObj, newPos, Quaternion.identity);
            //this adds each new enemy to the array as they are created
            enemies[i] = newObj;
        }   
    }

    // Update is called once per frame
    void Update()
    {
        //This will show how many collectables are currently in the game
        Debug.Log(allCollectables.Count);

    }
}
