using UnityEngine;

public class EnemyRotation : MonoBehaviour
{
    [SerializeField] private Player _player;
    
    private void Update()
    {
        Vector3 direction = _player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg -90;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
