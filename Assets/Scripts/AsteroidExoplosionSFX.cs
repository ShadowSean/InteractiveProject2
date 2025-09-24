using UnityEngine;

public class AsteroidExoplosionSFX : MonoBehaviour
{
    public AudioSource explosionSound;

    private void OnTriggerEnter(Collider other)
    {
        explosionSound.Play();
    }
}
