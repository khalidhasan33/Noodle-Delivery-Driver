using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32 (1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32 (1, 1, 1, 1);
    [SerializeField] float destroyDelay = 0.5f;

    SpriteRenderer spriteRenderer;

    bool hasPackage;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Bump!!!");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Package" && !hasPackage)
        {
           Debug.Log("Package has been taken");
           hasPackage = true;
           Destroy(other.gameObject, destroyDelay);
           spriteRenderer.color = hasPackageColor;
        }

        if(other.tag == "Customer" && hasPackage)
        {
           Debug.Log("Package has been sent to the customer");
           hasPackage = false;
           spriteRenderer.color = noPackageColor;
        }
    }
}
