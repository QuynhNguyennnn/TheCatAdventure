using UnityEngine;

public class EnemyMusic : MonoBehaviour
{
    public Transform playerTransform;
    public AudioSource audioSource;
    public AudioClip townTheme;
    public AudioClip heroicTheme;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the direction vector from the enemy to the player
        Vector3 directionToPlayer = playerTransform.position - transform.position;

        // Calculate the angle between the enemy's forward vector and the direction to the player
        float angle = Vector3.Angle(transform.forward, directionToPlayer);

        // Check if the angle is within a specified range (e.g., 90 degrees left, 90 degrees right)
        if (angle <= 90f)
        {
            // If the angle is within the range, play the townTheme
            if (audioSource.clip != townTheme)
            {
                audioSource.clip = townTheme;
                audioSource.Play();
            }
        }
        else
        {
            // If the angle is outside the range, play the heroicTheme
            if (audioSource.clip != heroicTheme)
            {
                audioSource.clip = heroicTheme;
                audioSource.Play();
            }
        }
    }
}
