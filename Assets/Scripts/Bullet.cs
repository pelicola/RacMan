using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   
    private void OnTriggerEnter2D(Collider2D other){ //box collider isTrigger 
        if(other.transform.tag == "Barrier" || other.transform.tag == "Enemy"){
            Destroy(gameObject); 
        }
    } 
}
