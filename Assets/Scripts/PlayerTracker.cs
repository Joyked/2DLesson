using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
      [SerializeField] private PlayerMover _player;
      [SerializeField] private float _xOffset;

      private void Update()
      {
            var position = transform.position;
            position.x = _xOffset + _player.transform.position.x;
            transform.position = position;
      }
}
