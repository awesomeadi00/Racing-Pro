using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Rigidbody playerRb;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float speed;

    void Start() {
        playerRb = player.GetComponent<Rigidbody>();
    }

    void LateUpdate()
    {
        // This takes the player's speed into account of how far the camera will be for a more realistic effect
        Vector3 playerForward =(playerRb.velocity + player.transform.forward).normalized;
        Vector3 targetPosition = player.transform.position + player.transform.TransformVector(offset) + playerForward * (-5f);
        float distance = Vector3.Distance(transform.position, targetPosition);

        // Calculate a dynamic speed based on the distance.
        float dynamicSpeed = Mathf.Clamp(distance / 10.0f, 0.1f, speed); // Adjust these values as needed.

        transform.position = Vector3.Lerp(transform.position, targetPosition, dynamicSpeed * Time.deltaTime);
        transform.LookAt(player.transform);
    }
}