using UnityEngine;

public class RotatornCharacters : MonoBehaviour
{
    private Mover _mover;

    private void Awake()
    {
        _mover = GetComponentInParent<Mover>();
        _mover.TurnedRight += TurnRight;
        _mover.TurnedLeft += TurnLeft;
    }

    private void OnDisable()
    {
        _mover.TurnedRight -= TurnRight;
        _mover.TurnedLeft -= TurnLeft;
    }

    private void TurnLeft() => 
        transform.rotation = Quaternion.Euler(Vector3.zero);
    
    private void TurnRight() => 
        transform.rotation = Quaternion.Euler(0, 180, 0);
}
