using UnityEngine;

[RequireComponent(typeof(Health))]
public class Eater : MonoBehaviour, IVisitor
{
    private Health _health;

    private void Awake() => 
        _health = GetComponent<Health>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        var visitables = other.GetComponents<IVisitable>();
    
        foreach (var visitable in visitables)
            visitable.Accept(this);
    }
    
    public void Visit(HeallObject heallObject) => 
        _health.Heal(heallObject.Use());

    public void Visit(FruitAnimator fruitAnimator) => 
        fruitAnimator.BeEaten();
}
