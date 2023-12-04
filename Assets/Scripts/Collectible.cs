using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{

    [SerializeField] AudioSource collectSFX; 
   private void OnTriggerEnter2D(Collider2D other){ //box collider isTrigger 
        if(other.transform.tag == "Player"){
            collectSFX.Play(); 
            Destroy(gameObject); 
            Player._score++;
        }
    } 
}
