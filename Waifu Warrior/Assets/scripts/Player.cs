using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private int Health;
    public bool immune = false;
    public GameObject healthbar;

    private void Start()
    {
        healthbar = GameObject.FindWithTag("Health");
    }

    void OnMouseDrag()
    {
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
    }

        
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!immune && collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Health -= 1;

            healthbar.GetComponent<HealthBar>().TakeDamage(-1);

            if (Health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    

}
