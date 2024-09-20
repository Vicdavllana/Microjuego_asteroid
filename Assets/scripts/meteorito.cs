using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteorito : MonoBehaviour
{

    public GameObject meteoritoChiquitoPrefab; 
    public Vector3 Movimientox = new Vector3(0.5f, 0, 0);//desplazamiento en el que spawnean los asteroides chiquitos
  

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -6f) // Si se sale de la pantalla desaparece
        {
            ObjectPooling.Instance.DevolverMeteorito(gameObject);
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            // Calcula la posición para el nuevo meteorito
            Vector3 spawnPositionPos = transform.position + Movimientox;
            Vector3 spawnPositionNeg = transform.position - Movimientox;

            // Genera el nuevo meteorito
           
            GameObject meteorChiquitoder = ObjectPooling.Instance.sacarMeteoritoMini();
            GameObject meteorChiquitoizq = ObjectPooling.Instance.sacarMeteoritoMini();
            meteorChiquitoder.transform.position = spawnPositionPos;
            meteorChiquitoizq.transform.position = spawnPositionNeg;

        }
    }
}

