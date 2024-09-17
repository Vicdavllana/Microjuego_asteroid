using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{

    public float velocidad = 10f;
    public float vida_util = 3f;
    public Vector3 targetVector;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, vida_util);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocidad * targetVector * Time.deltaTime);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("enemy"))
        {
            IncreaseScore();
            Destroy(collision.gameObject);
            Destroy(gameObject);

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


