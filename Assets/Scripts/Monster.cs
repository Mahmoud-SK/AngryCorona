using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] Sprite _deadSprite;
    [SerializeField] ParticleSystem _particleSystem;
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (shouldDieFromCollision(collisionInfo))
        {
            Die();
        }
    }
    
    private bool shouldDieFromCollision(Collision2D collisionInfo)
    {
        Bird bird = collisionInfo.gameObject.GetComponent<Bird>();

        if (bird != null)
            return true;
           
        if (collisionInfo.contacts[0].normal.y < -0.5)
            return true;

        return false;
        
    }

    void Die()
    {
        GetComponent<SpriteRenderer>().sprite = _deadSprite;
        _particleSystem.Play();
        //gameObject.SetActive(false);
    }
}
