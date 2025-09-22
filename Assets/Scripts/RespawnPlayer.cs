using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private Transform spawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        Player.transform.position = spawnPoint.transform.position;
    }
}
