using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource audioSource;
    private bool isPlayerInside = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInside && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
        else if (!isPlayerInside && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
        }
    }
}
