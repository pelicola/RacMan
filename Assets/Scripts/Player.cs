using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static int _score = 0;

    private Rigidbody2D rb;

    public SpriteRenderer spriteRenderer;
    public Sprite wGun;
    public Sprite noGun;

    [SerializeField] private float _speed;
    private Vector2 _moveDirection;
    private Vector2 mousePosition;

    public Weapon weapon;
    public static int _currentAmmo;

    public static bool canShoot;

    public int _maxLives = 3;
    public static int _currentLives;
    
    public TextMeshProUGUI LivesUI, CurrentScoreUI, AmmoCountUI; 
    [SerializeField] AudioSource ShootSFX; 

    void Start(){
        InputManager.Init(this); //puts the game controls on the player
        InputManager.SetGameControls();

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        ChangeSpriteNoGun();

        canShoot = false;

        rb = GetComponent<Rigidbody2D>();
        _currentLives = _maxLives;
        _currentAmmo = 0;

    }
    
    void Update(){

        if(_currentAmmo > 0){
            ChangeSpriteWGun();
        }
        else{
            ChangeSpriteNoGun();
        }

        if(Input.GetMouseButtonDown(0) && canShoot && _currentAmmo > 0){
            weapon.Fire();
            ShootSFX.Play(); 
            _currentAmmo -= 1;
        }

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        LivesUI.text = "Lives: " + _currentLives; 
        CurrentScoreUI.text = "Score: " + _score;

        if(canShoot && _currentAmmo > 0){


            AmmoCountUI.gameObject.SetActive(true);
            AmmoCountUI.color = Color.red;
            AmmoCountUI.text = "Current Ammo: " + _currentAmmo; 
        }
        else if (_currentAmmo <= 0){

            AmmoCountUI.gameObject.SetActive(false); 
        }

        if(_currentLives == 0){
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            _currentLives = 3; 
            _score = 0; 
            _currentAmmo = 0; 

        }

        if(_score == 276 ){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            _currentLives = 3; 
            _score = 0;
            _currentAmmo = 0; 
        }

    }

     void FixedUpdate(){
        rb.AddForce (_moveDirection * _speed); 
        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
     }

     public void SetMovementDirection(Vector2 currentDirection){
        _moveDirection = currentDirection;
    }

    void ChangeSpriteWGun()
    {
        spriteRenderer.sprite = wGun; 
    }

    void ChangeSpriteNoGun()
    {
        spriteRenderer.sprite = noGun; 
    }
}
