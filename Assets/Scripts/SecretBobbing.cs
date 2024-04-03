using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretBobbing : MonoBehaviour
{
    public float bobbingSpeed = 5f; // Speed of the bobbing
    public float bobbingHeight = 0.5f; // Height difference of the bobbing
    public float offset = 0f; // Phase offset if needed
    private AudioSource capsuleAudioSource;
    public AudioClip collectedSound;

    private Vector3 startingPosition;

    void Start()
    {
        // Store the starting position of the object
        startingPosition = transform.position;
        capsuleAudioSource = GetComponent<AudioSource>();

        // Deactivate this GameObject if unlockSpecial is already true
        if (MainManager.Instance != null && MainManager.Instance.unlockSpecial)
        {
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        // Calculate the new Y position using a sine wave for smooth bobbing
        float newY = startingPosition.y + Mathf.Sin((Time.time + offset) * bobbingSpeed) * bobbingHeight;

        // Set the object's position to the new calculated position
        transform.position = new Vector3(startingPosition.x, newY, startingPosition.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider is tagged as "Player"
        if (other.CompareTag("Player"))
        {
            // Check if the MainManager instance is available
            if (MainManager.Instance != null)
            {
                // Unlock the special feature
                MainManager.Instance.unlockSpecial = true;
            }

            if (capsuleAudioSource != null && collectedSound != null)
            {
                capsuleAudioSource.PlayOneShot(collectedSound);
            }
            StartCoroutine(DestroySecret());
        }
    }

    IEnumerator DestroySecret() {
        yield return new WaitForSeconds(0.72f);
        Destroy(gameObject);
    }
}
