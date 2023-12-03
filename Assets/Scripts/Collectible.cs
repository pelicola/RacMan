using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D other){ //box collider isTrigger 
        if(other.transform.tag == "Player"){
            Destroy(gameObject); 
            Player._score++;
        }
    } 
}
