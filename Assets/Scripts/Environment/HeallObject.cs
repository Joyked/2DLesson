using UnityEngine;

public class HeallObject : MonoBehaviour, IVisitable
{
    [SerializeField] private float _heallPoint;

    public float Use() => _heallPoint;

    public void Accept(IVisitor visitor)=> 
        visitor.Visit(this);
}
