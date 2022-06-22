using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitGoldPickup : MonoBehaviour
{
    [SerializeField] AudioClip bitgoldPickupSFX;

void OnTriggerEnter2D(Collider2D other)
{
    if (other.tag == "Player")
    {
        AudioSource.PlayClipAtPoint(bitgoldPickupSFX, Camera.main.transform.position);
        Destroy(gameObject);
    }
}

}
