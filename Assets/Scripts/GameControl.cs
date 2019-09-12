using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

	public static GameControl instance; //Singleton, vai servir para chamar as funções dentro do GameControl
	public GameObject gameOverText; //Texto do GameOver
	public bool gameOver = false; //verificar se o jogo acabou

	public float scrollSpeed = -1.5f; //velocidade do scroll pra ser igual de todos os objetos

	public Text scoreText; //Texto da pontuação
	private int score = 0; //inicia o score com 0

	// Use this for initialization
	void Awake () {

		//garante que só haverá um GameControl no jogo
		if (instance == null)
			instance = this;
		else if(instance != this)
			Destroy(gameObject);

	}
	
	// Update is called once per frame
	void Update () {
		
		if(gameOver && Input.GetMouseButtonDown(0)) //se for gameover e pressionar o botão esquerdo do mouse
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //carrega a mesma cena
		}

	}

	public void BirdScore() //função quando pontuar
	{
		if (gameOver) //se gameover for verdadeiro, simplesmente retorna, não faz nada
		{
			return;
		}
		score++; //aumenta um na pontuação
		scoreText.text = "Score: " + score.ToString(); //atualiza o texto da pontuação
 	}

	public void BirdDie() //função quando morrer
	{
		gameOverText.SetActive(true); //ativar o texto de gameover
		gameOver = true; //coloca gameover como verdadeiro
	}
}
