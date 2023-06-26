using UnityEngine;

public class TheresiaController : MonoBehaviour
{
    private Animator myAnim;
    private Transform target;
    private PlayerController player;
    private bool m_FacingRight = false;

    [SerializeField]
    private float speed = 2f; // Adjust the speed as needed

    private void Start()
    {
        myAnim = GetComponent<Animator>();
        player = FindObjectOfType<PlayerController>();
        if (player != null)
        {
            target = player.transform;
        }
    }

    private void Update()
    {
        if (target != null)
        {
            FollowPlayer();
        }
    }

    private void FollowPlayer()
    {
        myAnim.SetBool("isMoving", true);
        Vector3 direction = target.position - transform.position;
        float distance = direction.magnitude;

        if (distance > 1.5f) // Adjust the distance threshold as needed
        {
            // Calculate the normalized direction vector
            Vector3 normalizedDirection = direction.normalized;

            // Move the cat towards the player
            transform.position += normalizedDirection * speed * Time.deltaTime;

            // Set the animation parameters for movement
            myAnim.SetFloat("moveX", normalizedDirection.x);
            myAnim.SetFloat("moveY", normalizedDirection.y);
        }
    }
}
