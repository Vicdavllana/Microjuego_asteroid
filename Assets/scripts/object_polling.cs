using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ObjectPooling : MonoBehaviour
{
    public GameObject meteoritoPrefab;
    public GameObject meteoritoPrefabChiquito;
    public GameObject balasPrefab;

    public int tamano_lista = 20; // Tamaño del pool 
    public int tamano_lista_balas = 50;

    private List<GameObject> listaBalas;
    private List<GameObject> listaMeteoritos;
    private List<GameObject> listaMeteoritosChiquitines;

    private static ObjectPooling piscina; // Instancia Singleton

    // Singleton: Propiedad pública para acceder a la instancia
    public static ObjectPooling Instance
    {
        get { return piscina; }
    }

    void Awake()
    {
        // Singleton pattern
        if (piscina == null)
        {
            piscina = this;
            DontDestroyOnLoad(gameObject); // Esto mantiene el pool entre escenas
        }
        else
        {
            Destroy(gameObject); 
        }

        // Inicializamos la lista y agregamos objetos al pool
        InicializarMeteorPool();
        InicializarBalasPool();
    }

    // Método para inicializar el pool de meteoritos
    private void InicializarMeteorPool()
    {
        listaMeteoritos = new List<GameObject>();
        listaMeteoritosChiquitines = new List<GameObject>();

        for (int i = 0; i < tamano_lista; i++)
        {
            GameObject miniMeteor = Instantiate(meteoritoPrefabChiquito);
            GameObject meteor = Instantiate(meteoritoPrefab);
            meteor.SetActive(false); // Iniciamos los meteoros como inactivos
            miniMeteor.SetActive(false);
            listaMeteoritosChiquitines.Add(miniMeteor);
            listaMeteoritos.Add(meteor);
        }
    }
    private void InicializarBalasPool()
    {
        listaBalas = new List<GameObject>();

        for(int j = 0; j< tamano_lista_balas; j++)
        {
            GameObject bala = Instantiate(balasPrefab);
            bala.SetActive(false);
            listaBalas.Add(bala);

        }



    }

    // Método para obtener un meteoro del pool
    public GameObject sacarMeteorito()
    {
        foreach (GameObject meteor in listaMeteoritos)
        {
            if (meteor != null && !meteor.activeInHierarchy) 
            {
                meteor.SetActive(true);
               
                Rigidbody rb = meteor.GetComponent<Rigidbody>();
                rb.velocity = Vector3.zero; 
                rb.angularVelocity = Vector3.zero; 

               
                
                return meteor;
            }
        }

        // Si no hay meteoritos inactivos, creamos uno nuevo y lo devolvemos
        GameObject nuevoMeteor = Instantiate(meteoritoPrefab);
        nuevoMeteor.SetActive(true);
        listaMeteoritos.Add(nuevoMeteor); // Lo añadimos al pool
        return nuevoMeteor;


    }
    
    public GameObject sacarMeteoritoMini()
    {
        foreach (GameObject meteor in listaMeteoritosChiquitines)
        {
            if (meteor != null && !meteor.activeInHierarchy)
            {
                meteor.SetActive(true);
                // Restablecer la velocidad y rotación 
                Rigidbody rb = meteor.GetComponent<Rigidbody>();
                rb.velocity = Vector3.zero; 
                rb.angularVelocity = Vector3.zero; 

            
                
                return meteor;
            }
        }

        // Si no hay meteoritos inactivos, creamos uno nuevo y lo devolvemos
        GameObject nuevoMeteor = Instantiate(meteoritoPrefabChiquito);
        nuevoMeteor.SetActive(true);
        listaMeteoritosChiquitines.Add(nuevoMeteor); // Lo añadimos al pool
        return nuevoMeteor;


    }
    public GameObject sacarBala()
    {
        foreach (GameObject bala in listaBalas)
        {
            if (bala != null && !bala.activeInHierarchy)
            {
                bala.SetActive(true);
                
                return bala;
            }
        }
            //si no hay balas inactivas, creo
            GameObject nuevaBala = Instantiate(balasPrefab);
            nuevaBala.SetActive(true);
            listaBalas.Add(nuevaBala); // Lo añadimos al pool
            return nuevaBala;
        
    }

    // Método para devolver un meteoro al pool
    public void DevolverMeteorito(GameObject meteor)
    {
        meteor.SetActive(false); // Simplemente lo desactivamos
    }

    public void DevolverBala(GameObject bala)
    {
        bala.SetActive(false);
    }
}
