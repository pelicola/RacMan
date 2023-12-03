using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other){ //box collider isTrigger 
        if(other.transform.tag == "Player"){
            Player._currentLives--;
        }
    } 
}
