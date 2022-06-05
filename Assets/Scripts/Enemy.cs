using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float HP, rotationSpeed, speed;
    public Transform[] points;

    private Transform _currentPoint;
    private int _index;
    private Vector3 _direction;
    private Resources _resources;

    void Start()
    {
        _index = 0;
        _currentPoint = points[_index];
        _resources = FindObjectOfType<Resources>();
    }


    void Update()
    {
        _direction = points[_index].position - transform.position;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, _direction, Time.deltaTime * rotationSpeed, 0);
        transform.rotation = Quaternion.LookRotation(newDirection);

        transform.position = Vector3.MoveTowards(transform.position, _currentPoint.position, speed * Time.deltaTime);

        if (transform.position == _currentPoint.position) 
        {
            _index++;

            if(_index >= points.Length) 
            {
                Destroy(gameObject);
                _resources.LostLife();
            }
            else
            {
                _currentPoint = points[_index];
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            HP -= other.GetComponent<Bullet>().damage;
            Destroy(other.gameObject);

            if(HP <= 0)
            {
                Destroy(gameObject);
                _resources.WhenKilled();
            }  
        }
    }
}
