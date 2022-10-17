using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float hp = 1f;
    private Animator anim;
    void Start ()
    {
        anim = GetComponent<Animator>();
    }
    public void TakeDamage(float amount)
    {
        hp -= amount;
        if (hp <= 0f)
        {
            Die();
        }
    }
 
    public void Die()
    {
        anim.SetTrigger("Die");
        GetComponent<CapsuleCollider>().enabled = false;
        //play anim
        Debug.Log(gameObject.name + " just died!");
    }
}
