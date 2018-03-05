using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class Player : MonoBehaviour {

    public Boundary boundary;

    [SerializeField]
    private int Health;
    public bool immune = false;
    public GameObject healthbar;
    Rigidbody2D rgbd;
    public Sprite image;
    public Sprite camo;

    public bool dragOn = true;

    private void Start()
    {
        healthbar = GameObject.FindWithTag("Health");
        rgbd = gameObject.GetComponent<Rigidbody2D>();
        image = gameObject.GetComponent<SpriteRenderer>().sprite;
    }

    void Update()
    {
        if(rgbd.position.y > boundary.yMax || rgbd.position.y < boundary.yMin) { Debug.Log('a'); dragOn = false; }
        else { dragOn = true; }
        
        rgbd.position = new Vector2
        (
            Mathf.Clamp(rgbd.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(rgbd.position.y, boundary.yMin, boundary.yMax)
        );
    }

    void OnMouseDrag()
    {
        if (dragOn)
        {
            

            Debug.Log("hi");
            Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = objPosition;
        }
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
