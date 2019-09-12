using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {

	private BoxCollider2D groundCollider;
	private float groundHorizontalLength; //armazena o valor do tamanho do chão

	// Use this for initialization
	void Start () {

		groundCollider = GetComponent<BoxCollider2D>();
		groundHorizontalLength = groundCollider.size.x; //pega o tamanho dele pelo boxcollider

	}
	
	// Update is called once per frame
	void Update () {
		
		if(transform.position.x < -groundHorizontalLength)//se a posição no eixo de x for menor que o tamanho dele negativo
		{
			RepositionBackground(); //chama a função para reposicionar
		}

	}

	private void RepositionBackground()
	{
		Vector2 groundOffSet = new Vector2(groundHorizontalLength * 2f, 0); //calcula pra onde ele deve se mover, o tamanho do boxcollider * 2
		transform.position = (Vector2)transform.position + groundOffSet; //casta como vector 2 e move ele pra nova posição
	}
}
