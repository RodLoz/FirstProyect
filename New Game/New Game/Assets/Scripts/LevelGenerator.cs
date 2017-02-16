using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour {
	/*
	 *Variables publicas generador de niveles 
	 * 
	*/
	public static LevelGenerator sharedInstance;// Instancia compartida para solo tener un generador de niveles
	public List <LevelBlock> allTheLevelBlocks = new List <LevelBlock> (); // Lista de todos los niveles que se han creado
	public List <LevelBlock> currentLevelBlocks = new List <LevelBlock> ();// Lista de todos los niveles que se encuentran en pantalla
	public Transform levelInitialPosition; // Posicion inical donde empezara a crearse el primer nivel de todo

	void Awake (){
		sharedInstance = this;
	
	}


	// Use this for initialization
	void Start () {
		GenerateInitialBlocks ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void GenerateInitialBlocks (){
		for (int i = 0; i < 2; i++) {
			AddNewBlock ();
		}
	}

	public void AddNewBlock (){
	
		// Seleccionar un bloque aleatorio entre los que tenemos disponibles
		int randomIndex= Random.Range(0 , allTheLevelBlocks.Count);

		LevelBlock block = (LevelBlock)Instantiate (allTheLevelBlocks [randomIndex]); //Vamos a coger cualquier bloque que ya se ha cargado en el nivel (randomIndex) y tendra como variable block
		block.transform.SetParent(this.transform,false);


		//Posicion del bloque
		Vector3 blockPosition = Vector3.zero;

		if (currentLevelBlocks.Count == 0) {
			//Vamos a colocar el primer bloque en pantalla
			blockPosition = levelInitialPosition.position;
		}else{
			//Ya tengo bloques en pantalla lo empalmo al ultimo disponible
			blockPosition = currentLevelBlocks [currentLevelBlocks.Count - 1].exitPoint.position; // De todos los bloques que hay en pantalla se coge el ultimo, tambien hace que el nuevo bloque(blockPosition) 
			                                                                                      //se coloque justo en el punto de salida del bloque anterior
		}

		block.transform.position = blockPosition;
		currentLevelBlocks.Add (block);
	}


	public void RemoveOldBlock (){

		LevelBlock block = currentLevelBlocks [0];
		currentLevelBlocks.Remove (block);
		Destroy (block.gameObject);

	}

	}
