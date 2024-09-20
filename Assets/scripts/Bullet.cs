using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{

    public float velocidad = 10f;
  
    public Vector3 targetVector;
  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocidad * targetVector * Time.deltaTime);
        if (transform.position.x < -11f || transform.position.x > 11f) // Si se sale de la pantalla desaparece
        {
            ObjectPooling.Instance.DevolverBala(gameObject);
        }
        if (transform.position.y < -7f || transform.position.y > 7f) // si se sale de la pantalla desaparece
        {
            ObjectPooling.Instance.DevolverBala(gameObject);
        }
    }


    private void OnCollisionEnter(Collision collision)//si se topa con un meteorito, devolvemos el meteorito y la bala a la piscina de objetos y actualizamos score
    {
        if(collision.gameObject.CompareTag("enemy"))
        {
            
            IncreaseScore();
            GameObject meteorito = collision.gameObject;
            ObjectPooling.Instance.DevolverMeteorito(meteorito);
            ObjectPooling.Instance.DevolverBala(gameObject);
           


        }
        else if (collision.gameObject.CompareTag("enemy chiquito"))
        {
          
            IncreaseScore();
            GameObject meteorito = collision.gameObject;
            ObjectPooling.Instance.DevolverMeteorito(meteorito);

            ObjectPooling.Instance.DevolverBala(gameObject);

        }
    }
    private void IncreaseScore()
    {
     
        nave_jugador.puntuacion++;
        UpdateScoreText();
    }
    private void UpdateScoreText()
    {
        GameObject texto = GameObject.FindGameObjectWithTag("ui");
        texto.GetComponent<Text>().text = "Puntos: " + nave_jugador.puntuacion;
        
    }
}


