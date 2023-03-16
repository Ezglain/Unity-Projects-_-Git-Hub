using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControl : MonoBehaviour
{


    int health = 10;
    public TMP_Text healthText;

    //a float is a number with a deceimal and in c sharp we have to put an f at the end of a number to tell unity that its a float, otherwise unity will think its a double and will get confused
    //double is similar to a float but can only go two space
    //float health = 10f;

    int score = 0;

    float thisIsADecimal = 3.14f;

    //to make a variable public means being able to change that part of the code in Unity
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        healthText.text = health.ToString();
        Debug.Log(thisIsADecimal);
        thisIsADecimal++;
        Debug.Log(thisIsADecimal);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPos = transform.position;
        if (Input.GetKey(KeyCode.W))
        {
            //currentPos.z++;                                                             //something weird? hit insert.
            currentPos.z = currentPos.z + speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            //currentPos.z--;
            currentPos.z = currentPos.z - speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            //currentPos.x--;
            currentPos.x = currentPos.x - speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            //currentPos.x++;
            currentPos.x = currentPos.x + speed * Time.deltaTime;
        }
        transform.position = currentPos;

        //tune a game is making sure the game is balanced and even, we use variables to fine tune the code.

    }

    void OnCollisionEnter(Collision otherThing)
    {
        Debug.Log(otherThing.gameObject.name);
        if(otherThing.gameObject.name == "Enemy")
        {
            health--;
            healthText.text = health.ToString();
        }
    }

}