using System.Collections;
using UnityEngine;

public class AsteroidCollision : MonoBehaviour
{
    public string playerTag = "Player";
    public float asteroidRespawnTime = 5f;

    //holds wheather the object is visible or not
    private Renderer objectRend;


    private void Start()
    {
        objectRend = GetComponent<Renderer>();
    }

    // Trigger the coroutine that can respawn asteroid only if player touches it
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag)) 
        {
            StartCoroutine(RespawnAsteroid());
        }
    }

    // this is the function dealing with the asteroid respawn times
    IEnumerator RespawnAsteroid()
    {
        objectRend.enabled = false;
        

        yield return new WaitForSeconds(asteroidRespawnTime);

        objectRend.enabled = true;
        
    }
}
