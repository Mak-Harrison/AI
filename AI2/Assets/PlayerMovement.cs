using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 5f;
    public float gravity = -9.81f;

    private Vector3 velocity;

    void Update()
    {
        // 1. Get Input from WASD / Arrow Keys
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // 2. Calculate movement direction based on where the player is facing
        Vector3 move = transform.right * x + transform.forward * z;

        // 3. Move the controller
        controller.Move(move * speed * Time.deltaTime);

        // 4. Simple Gravity (so you stay on the ground)
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
