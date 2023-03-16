using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMaker : MonoBehaviour
{
    // we named it blockObj
    public GameObject blockObj;

    public int blockNum;

    // Start is called before the first frame update
    void Start()
    {
        // for loop = a construction that allows us to loop a set number of times IE we loop FOR a number of times
        // parenthasis is for passing on or checking information
        // int i = 0; is declaring a variable, this is a counter like a tally mark and we start off at zero 
        // i < 10 checks to see if i is less than 10 to then execute what is in the curly brrackets 
        // i++ adds until i no longer is less than 10
        //x we can use for loops in different ways
        //! This is a for loop
        //! for (int i = 0; i < 10; i++) { Debug.Log(i);}
        //? (!) means not, the exclimation point means not as in not equals to
        //? for (int i = 10; i != 0; i--)
        //todo the below code is better than the above because this will prevent getting stuck in walls, this one works one way and the above works two ways and occasionally doesn't work.
        //todo for (int i = 10; i > 0; i--)

        for (int i = 0; i < blockNum; i++)
        {
            Debug.Log(i);
            
            //? Vector3 newPos = new Vector3(transform.position.x + (i * 2), transform.position.y, transform.position.z);
            
            //! This code is using random range which will give a random number between andy numbers placed in the parenthasis next to Random.Range()
            Vector3 newPos = new Vector3(transform.position.x + Random.Range(-10, 10), transform.position.y, transform.position.z + Random.Range(-10, 10));

            //todo Instantiate is a function that allows us to create a game objection from code it takes three peramiters
            //! first peramiter is blockObj, it means we want to create whatever is in the first spot in this case its blockObj
            //! transfor position just means put me at the positioin whevere the current block object is
            //! the third peramiter is for rotation, in this case we dont want it to rotate so we say Quaternion.identity
            Instantiate (blockObj, newPos, Quaternion.identity);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
