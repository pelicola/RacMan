using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] AudioSource PowerUpSFX; 
    private void OnTriggerEnter2D(Collider2D other){ //box collider isTrigger 
        if(other.transform.tag == "Player"){
            Player.canShoot = true;
            Player._currentAmmo += 3;
            PowerUpSFX.Play();
            Destroy(gameObject); 
        }
    } 
}
