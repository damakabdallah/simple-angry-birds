using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public ParticleSystem deathEffect;
    public float health = 4f;
    public static int enemiesAlive = 0;
    void Start()
    {
        enemiesAlive++;
    }
    void OnCollisionEnter2D( Collision2D colInfo)
    {
        if (colInfo.relativeVelocity.magnitude > health)
        {
            Die();
        }
    }
    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);

        enemiesAlive--;
        if (enemiesAlive <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Destroy(gameObject);
    }
  

}