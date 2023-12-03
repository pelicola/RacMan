using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager{

   private static GameControls _gameControls;

   public static void Init(Player myPlayer){
      _gameControls = new GameControls();

      _gameControls.InGame.Enable(); 

      _gameControls.InGame.Movement.performed += c => { //look for input
          myPlayer.SetMovementDirection(c.ReadValue<Vector2>()); //action performed
       };
   }

    public static void SetGameControls(){
     _gameControls.InGame.Enable();
   }
}
