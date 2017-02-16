using UnityEngine;
using System.Collections;

//1
public enum GameState {
    menu,
	inTheGame,
	gameOver
}

public class GameManager : MonoBehaviour {


	public static GameManager sharedInstance;
	//3
	// currentGameState = Estado del juego actual
	// Nada mas arrancar nuestro juego empieza en el Menu principal:
	public GameState currentGameStates = GameState.menu;

	void Awake (){
		sharedInstance = this;
	}
	//2 Se crea cada metodo (vacios) 
	void Start () {
		currentGameStates = GameState.menu;
	}


	void Update (){
		if (Input.GetButtonDown ("s")) {
			if (currentGameStates != GameState.inTheGame) {
				PlayerController.sharedInstance.StartGame ();
				currentGameStates = GameState.inTheGame;

			}	
		}
	}

	// Se llama para iniciar la partida
	//5 luego cada metodo se llena con lo que se hizo en el 4
	public void StartGame (){
		ChangeGameState (GameState.inTheGame);

	}

	// Se llama cuando el jugador muere
	public void GameOver (){
		ChangeGameState (GameState.gameOver);
	
	}

	// Se llama para regresar al menu principal
	public void BackToMineMenu(){
		ChangeGameState (GameState.menu);
	
	}
	//4 
	void ChangeGameState (GameState newGameState){

		//La escena de unity debe mostrar la escena principal
		if (newGameState == GameState.menu) {

		//La escena de unity debe configurarse para mostrar el juego			 
		} else if (newGameState == GameState.inTheGame) {

		//La escena de unity debe configurarse para mostrar la pantalla de muerte/fin de juego etc...
		} else if (newGameState == GameState.gameOver) {
		
		}

	}
}


