using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[SelectionBaseAttribute]

public class Monster : MonoBehaviour
{
    [SerializeField] Sprite _deadSprite;
    [SerializeField] ParticleSystem _particleSystem;
    bool _hasDied;

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (shouldDieFromCollision(collisionInfo))
        {
            StartCoroutine(Die());
        }
    }
    
    private bool shouldDieFromCollision(Collision2D collisionInfo)
    {
        if (_hasDied)
        {
            return false;
        }
                    
        Bird bird = collisionInfo.gameObject.GetComponent<Bird>();

        if (bird != null)
        {
            return true;
        }
            
           
        if (collisionInfo.contacts[0].normal.y < -0.1)
        {
            return true;
        }

        if(collisionInfo.contacts[0].normal.x == -4.4925){
            return true;
        }

                
        return false;
        
    }

    IEnumerator Die()
    {
        _hasDied = true;
        GetComponent<SpriteRenderer>().sprite = _deadSprite;
        _particleSystem.Play();
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
