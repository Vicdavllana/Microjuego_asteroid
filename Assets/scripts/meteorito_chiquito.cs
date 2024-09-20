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
        if (transform.position.y < -6f) // Solo se devuelve al pool de objetos si se va de la pantalla
        {
            ObjectPooling.Instance.DevolverMeteorito(gameObject);
        }
    }
}
