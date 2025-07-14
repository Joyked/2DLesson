using UnityEngine;

[RequireComponent(typeof(Attack))]
public class PlayerShot : MonoBehaviour
{
    private Attack _attack;

    private void Awake()
    {
        _attack = GetComponent<Attack>();
        _attack.isShot = true;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
            _attack.Shot();
    }
}
