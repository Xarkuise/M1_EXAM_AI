using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public GameObject Door;

    private bool keyCollected = false;

    public bool isKeyCollected()
    {
        return keyCollected;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !keyCollected)
        {
            keyCollected = true;
            gameObject.SetActive(false);

            AudioManagerForLevels audioManager = FindObjectOfType<AudioManagerForLevels>();
            if (audioManager != null)
            {
                audioManager.PlayKeyPickupSound();
                audioManager.PlayDoorOpenSound();
            }
        }
    }
}
