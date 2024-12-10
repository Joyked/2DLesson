using UnityEngine;

public class EaterFruits : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Fruit fruits))
            fruits.BeEaten();
    }
}
