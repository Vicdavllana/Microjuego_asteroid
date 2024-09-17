using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nave_jugador : MonoBehaviour
{
    public float velempuje = 300f;
    public float velrotacion = 200f;

    public float xBorde;
    public float yBorde;

    public GameObject pistola, bulletPrefab;

    public Rigidbody rigid;

    public static int puntuacion = 0;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = transform.position;
        if (newPos.x > xBorde)
            newPos.x = -xBorde + 1;
        else if (newPos.x < -xBorde)
            newPos.x = xBorde - 1;
        else if (newPos.y > yBorde)
            newPos.y = -yBorde + 1;
        else if (newPos.y < -yBorde)
            newPos.y = yBorde - 1;
        transform.position = newPos;




        float empuje = Input.GetAxis("Vertical") * Time.deltaTime;
        Vector3 vectorDireccion = transform.right;

        float rotacion = Input.GetAxis("Rotate") * Time.deltaTime;

        transform.Rotate(Vector3.forward, -rotacion * velrotacion);
        rigid.AddForce(vectorDireccion * empuje * velempuje);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bala = Instantiate(bulletPrefab, pistola.transform.position, Quaternion.identity);

            Bullet balasScript = bala.GetComponent<Bullet>();

            balasScript.targetVector = transform.right;
        }

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy") {
            puntuacion = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
}
