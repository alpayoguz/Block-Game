﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoseCollider : MonoBehaviour
{
    IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene("Game Over");


        }
        
        
           
        
        
    }
}
