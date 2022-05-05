using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{

    PlayerController playerControl;
    
    // Start is called before the first frame update
    public float topBound = 30;
    public float lowerBound = -10;
    void Start()
    {
        playerControl = GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z > topBound || transform.position.z < lowerBound){
            Debug.Log("Health : " + PlayerController.health);
            Destroy(gameObject);
            PlayerController.health--;
            PlayerController.check = true;
        }
    }
}
