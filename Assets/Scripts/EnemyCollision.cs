using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{

    [SerializeField] AudioSource HitByCop; 

    private void OnTriggerEnter2D(Collider2D other){ 
        if(other.transform.tag == "Player"){ //if player hits cop they lose a life. 
            HitByCop.Play(); 
            Player._currentLives -= 1;
            Debug.Log("Cops Caught U");
        }

        if(other.transform.tag == "Bullet"){ //if gun hits cop 
            Destroy(gameObject); 
            Debug.Log("Killed Cop"); 
        }

    } 

    
}
