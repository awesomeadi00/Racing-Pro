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
        transform.position = Vector3.Lerp(transform.position, player.transform.position + player.transform.TransformVector(offset) + playerForward * (-5f), speed * Time.deltaTime);
        transform.LookAt(player.transform);
    }
}
