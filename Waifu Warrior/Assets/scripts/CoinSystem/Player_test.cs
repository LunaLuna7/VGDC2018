﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_test : MonoBehaviour {

    [SerializeField]
    private int Health;
    public bool immune = false;

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
            Health -= 1;
            if (Health <= 0)
            {
                Bank.IncrementBank();
                Destroy(gameObject, 4);
                
            }
        }
    }

    

}
