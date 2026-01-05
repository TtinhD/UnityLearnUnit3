using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce = 10.0f;
    public float gravitiModifier;
    public bool isOnGround = true;
    public bool gameOver;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravitiModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }    
        


    private void OnCollisionEnter(Collision collison)
    {
        if (collison.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }else if (collison.gameObject.CompareTag("Obstacles"))
        {
            gameOver = true;
            Debug.Log("Game Over");
        }
    }
    
}
