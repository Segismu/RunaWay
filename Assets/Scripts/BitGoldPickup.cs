using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitGoldPickup : MonoBehaviour
{
    [SerializeField] AudioClip bitgoldPickupSFX;
    [SerializeField] int pointsBitGoldPickup = 100;

    bool wasCollected = false;

void OnTriggerEnter2D(Collider2D other)
{
    if (other.tag == "Player" && !wasCollected)
    {
        wasCollected = true;
        FindObjectOfType<GameSession>().AddToScore(pointsBitGoldPickup);
        AudioSource.PlayClipAtPoint(bitgoldPickupSFX, Camera.main.transform.position);
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}

}
