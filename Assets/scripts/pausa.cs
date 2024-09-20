using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class pausa : MonoBehaviour
{
    public GameObject iconoPausa;
    public GameObject menuDePausa;
    private bool pausado = false;
    // Start is called before the first frame update
    void Start()
    {
        iconoPausa.SetActive(true); 
        menuDePausa.SetActive(false);
        Time.timeScale = 1f;
        pausado = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pausado)
            {
                pausar();
            }
            else
            {
               reanudar();
            }
        }
        
    }

    public void pausar()// activa todo el menu de pausa y desactiva el icono de pausa
    {
        pausado = true;
       
        if (menuDePausa != null)
        {
            menuDePausa.SetActive(true);
        }
        if (iconoPausa != null)
        {
            iconoPausa.SetActive(false);
        }
        Time.timeScale = 0f;
    }
    public void reanudar()//desactiva el menu de pausa y activa el icono de pausa
    {
        pausado = false;
        if (menuDePausa != null)
        {
            menuDePausa.SetActive(false);
        }
        if (iconoPausa != null)
        {
            iconoPausa.SetActive(true);
        }
        Time.timeScale = 1f;
    }

    public void cerrar_jueguito()//se cierra el juego
    {
        Application.Quit();
    }
}
