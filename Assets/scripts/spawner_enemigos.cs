using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner_enemigos : MonoBehaviour
{
    public GameObject asteroidesPrefab;
    public GameObject asteroidesPrefabChiquito;
    public float spawnRatePerMin = 30f;
    public float spawnRateIncrement = 1f;
    private float spawnNext = 0;
    public float xlimite;
    public float metTimeLife = 4f;
    // Start is called before the first frame update
    void Start()
    {
           
        
}

// Update is called once per frame
void Update() //spawnea meteoritos en la pantalla de juego 
    {
        if (Time.time > spawnNext)
        {
            spawnNext = Time.time + 60/spawnRatePerMin;

            spawnRatePerMin += spawnRateIncrement + spawnRateIncrement;

            float randX = Random.Range(-xlimite, xlimite);

            Vector2 spawnPosition = new Vector2(randX , 8f);
            // Crear una instancia de la clase Random
            GameObject meteorito = ObjectPooling.Instance.sacarMeteorito();

            // Posicionamos el meteoro en una posici�n aleatoria
            meteorito.transform.position = spawnPosition;
            meteorito.transform.rotation = Quaternion.identity;
            
        }


    }
}
