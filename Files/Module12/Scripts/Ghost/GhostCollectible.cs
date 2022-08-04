using System;
using UnityEngine;

public class GhostCollectible : MonoBehaviour
{
    public int Score;

    public event Action<int, GhostCollectible> OnCollectedGhost;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnCollectedGhost?.Invoke(Score, this);
        }
    }
}
