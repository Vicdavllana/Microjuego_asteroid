using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteorito_chiquito : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -6f) // Suponiendo que -5f está fuera de la pantalla
        {
            ObjectPooling.Instance.DevolverMeteorito(gameObject);
        }
    }
}
