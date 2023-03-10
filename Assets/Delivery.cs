using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] float delayDestroy = 0.5f;
    [SerializeField] Color32 hasPackageColor = new Color32 (1,0,1,1);
    [SerializeField] Color32 noPackageColor = new Color32 (0,1,1,1);
    bool hasPackage = false;

    SpriteRenderer spriteRenderer;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = noPackageColor;
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Collision..."); 
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up!");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, delayDestroy);
        }

        if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package delivered!");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
