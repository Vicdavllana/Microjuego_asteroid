using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteorito_chiquito : MonoBehaviour
{
    public float vida = 4f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,vida);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
