using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cross_hair : MonoBehaviour {


    [SerializeField] private GameObject explosion;
    public Transform target;
    public GameObject camo;

    public Player character;
    void Start()
    {
        character = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        character.CamoShape();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        FindObjectOfType<AudioManager>().Play("Siren");
        Instantiate(camo, target.position, target.rotation);
        StartCoroutine(NotImmune());
    }
    IEnumerator NotImmune()
    {
        yield return new WaitForSeconds(3);
        character.immune = false;
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
            character.DefaultShape();
            Destroy(gameObject);
            
        }
    }

    
}
