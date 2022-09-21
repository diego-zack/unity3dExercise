using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;

public class player : MonoBehaviour
{
    
    public float velocidad = 1;
    public float rotation = 1; // grados * segundo
    public float salto = 1;
    private bool tocarSuelo = false;
    private Rigidbody rigidbody;
    
    // Start is called before the first frame update
    void Start()

    {
        Cursor.lockState = CursorLockMode.Locked;
        rigidbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float ejeX = Input.GetAxis("Horizontal"); //valores que varían entre -1 y 1
        float ejeZ = Input.GetAxis("Vertical");
        if (ejeX != 0.0f || ejeZ != 0.0f)
        {
        transform.Translate(new Vector3(ejeX,0,ejeZ) * (Time.deltaTime * velocidad));
        }
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(new Vector3(0,mouseX,0) * (Time.deltaTime * rotation));
        
        if (Input.GetKeyDown(KeyCode.Space) && tocarSuelo)
        {
            rigidbody.AddForce(new Vector3(0,salto, 0),ForceMode.Impulse);
            tocarSuelo = false;
        }

        
    }
        void OnCollisionEnter(Collision collision)
        {
            tocarSuelo = true;
        }
}
