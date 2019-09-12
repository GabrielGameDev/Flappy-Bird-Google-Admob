using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour {

	public int columnPoolSize = 5; //quantos objetos vamos querer instanciar no total
	public GameObject columnPrefab; //prefab da coluna
	public float spawnRate = 3f; //tempo para reposicionar a coluna
	public float columnMin = -3.2f; //altura mínima para posicionar a coluna
	public float columnMax = 1.34f; //altura máxima

	private GameObject[] columns; //vetor das colunas
	private Vector2 objectPollPosition = new Vector2(-15f, 25f); //posição fora da tela pra instanciar as colunas
	private float timeSinceLastSpawned; //timer que irá verificar o tempo até posicionar uma nova coluna
	private float spawnXPosition = 5f; //posição no eixo de X da coluna que sempre será a mesma
	private int currentColumn = 0; //verifica qual é a coluna atual

	// Use this for initialization
	void Start () {

		columns = new GameObject[columnPoolSize]; //vamos iniciar os objetos da coluna de acordo com o tamanho do columnPoolSize
		for (int i = 0; i < columnPoolSize; i++) //loop que irá instanciar o total de colunas que queremos
		{
			columns[i] = (GameObject)Instantiate(columnPrefab, objectPollPosition, Quaternion.identity); //intanciar as colunas
		}

	}
	
	// Update is called once per frame
	void Update () {

		timeSinceLastSpawned += Time.deltaTime; //inicia o timer

		if(!GameControl.instance.gameOver && timeSinceLastSpawned >= spawnRate) //se não for gameover e o tempo de instanciar uma nova coluna for maior que o tempo de spanRate
		{
			timeSinceLastSpawned = 0; //zera o timer
			float spawnYPosition = Random.Range(columnMin, columnMax); //vai gerar em qual a posição no eixo de Y devemos colocar a coluna
			columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition); //pega a coluna atual e coloca numa nova posição
			currentColumn++; //aumenta o valor da coluna atual
			if(currentColumn >= columnPoolSize) //se o valor de coluna atual for maior que o tamanho do pool, zeramos o valor de currentColumn
			{
				currentColumn = 0;
			}

		}

	}
}
