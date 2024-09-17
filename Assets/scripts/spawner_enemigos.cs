using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner_enemigos : MonoBehaviour
{
    public GameObject asteroidesPrefab;
    public float spawnRatePerMin = 30f;
    public float spawnRateIncrement = 1f;
    private float spawnNext = 0;
    public float xlimite;
    public float metTimeLife = 2f;
    // Start is called before the first frame update
    void Start()
    {
           
        
}

// Update is called once per frame
void Update()
    {
        if (Time.time > spawnNext)
        {
            spawnNext = Time.time + 60/spawnRatePerMin;

            spawnRatePerMin += spawnRateIncrement + spawnRateIncrement;

            float randX = Random.Range(-xlimite, xlimite);

            Vector2 spawnPosition = new Vector2(randX , 8f);

           GameObject meteor = Instantiate(asteroidesPrefab, spawnPosition, Quaternion.identity);
            Destroy(meteor, metTimeLife);       
        }


    }
}
