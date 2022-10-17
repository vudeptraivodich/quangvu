using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public LayerMask enemyLayer;
    public float damage = 1f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 rayOrigin = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
            RaycastHit hit;
            if (Physics.Raycast(rayOrigin, Camera.main.transform.forward, out hit, Mathf.Infinity, enemyLayer))
            {
                Debug.Log(hit.collider.gameObject);
                Enemy enemyHit = hit.collider.gameObject.GetComponent<Enemy>();
                if (enemyHit != null)
                {
                    enemyHit.TakeDamage(damage);
                }
            }
        }
    }
}
