using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cross_hair : MonoBehaviour {


    [SerializeField] private GameObject explosion;


    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Siren");
    }

    void Update()
    {
        
        
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 temp = Input.mousePosition;
            temp.z = 10f;

            this.transform.position = Camera.main.ScreenToWorldPoint(temp);

            FindObjectOfType<AudioManager>().Stop("Siren");
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
            
        }
    }

    
}
