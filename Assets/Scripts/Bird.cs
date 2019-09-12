using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

	public float upforce = 200;

	private bool isDead = false; //verificar se o bird está vivo
	private Rigidbody2D rb2d;
	private Animator anim;


	// Use this for initialization
	void Start () {

		rb2d = GetComponent<Rigidbody2D>(); //referencia o rigidbody do Bird
		anim = GetComponent<Animator>(); //referencia o componente Animator do Bird

	}
	
	// Update is called once per frame
	void Update () {

		if (!isDead)
		{
			if (Input.GetMouseButtonDown(0)) //se clicar com o botão esquerdo
			{
				rb2d.velocity = Vector2.zero; //zera a velocidade
				rb2d.AddForce(new Vector2(0, upforce)); //adiciona força
				anim.SetTrigger("Flap"); //muda a animação
			}
		}


		rb2d.position = new Vector2(rb2d.position.x,Mathf.Clamp(rb2d.position.y, rb2d.position.y, 4.7f)); //limita a movimentação

	}

	private void OnCollisionEnter2D(Collision2D collision) //função que é chamada quando se colide
	{
		rb2d.velocity = Vector2.zero; //zera a velocidade
		isDead = true; //colocar verdadeiro para isDead
		anim.SetTrigger("Die"); //muda a animação
		GameControl.instance.BirdDie(); //chama a função BirdDie do Gamecontrol
		AdmobManager.instance.deaths++;
		if(AdmobManager.instance.deaths >= 3)
		{
			AdmobManager.instance.deaths = 0;
			AdmobManager.instance.ShowPopUp();
		}
	}
}
