using UnityEngine;

public class EatFruits : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Fruits fruits))
            fruits.Eat();
    }
}
