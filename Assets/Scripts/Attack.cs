using System.Collections.Generic;
using UnityEngine.Pool;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;

    private ObjectPool<Bullet> _bulletPool;
    private List<Bullet> _bullets;
    private int _poolCapacity = 5;
    private int _poolMaxSize = 10;

    public bool isShot;
    
    private void Awake()
    {
        _bullets = new List<Bullet>();
        
        _bulletPool = new ObjectPool<Bullet>
        (
            CreateObject,
            ActionOnGet,
            ActionOnRelease,
            ActionOnDestroy,
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize
        );
    }
    
    private Bullet CreateObject()
    {
        var bullet = Instantiate(_bulletPrefab);
        _bullets.Add(bullet);
        bullet.Destroyed += ReturnToPool;
        return bullet;
    }

    private void OnDisable()
    {
        foreach (var bullet in _bullets)
            bullet.Destroyed -= ReturnToPool;
    }

    private void ActionOnGet(Bullet obj)
    {
        if (isShot)
        {
            obj.transform.position = transform.position;
            obj.transform.rotation = transform.rotation;
            obj.gameObject.SetActive(true);
        }
    }

    private void ActionOnRelease(Bullet obj)=>
        obj.gameObject.SetActive(false);

    private void ActionOnDestroy(Bullet obj) =>
        Destroy(obj.gameObject);
    

    public void Shot() =>
        _bulletPool.Get();

    private void ReturnToPool(Bullet bullet)
    {
        if(bullet.gameObject.activeSelf)
            _bulletPool.Release(bullet);
    }
}
