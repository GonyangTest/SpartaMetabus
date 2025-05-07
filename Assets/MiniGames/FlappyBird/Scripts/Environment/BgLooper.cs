using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    [SerializeField] private int _bgCount = 5;

    private Vector3 _lastPosition;
    private void Start()
    {
        Obstacle[] obstacles = FindObjectsOfType<Obstacle>();
        _lastPosition = obstacles[0].transform.position;

        foreach(Obstacle obstacle in obstacles)
        {
            _lastPosition = obstacle.SetRandomPlace(_lastPosition);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag(Constant.BACKGROUND_TAG))
        {
            float width = (collision as BoxCollider2D).size.x;
            Vector3 targetPosition = collision.transform.position;
            
            targetPosition.x += width * _bgCount;
            collision.transform.position = targetPosition;
            return;
        }

        Obstacle obstacle = collision.GetComponent<Obstacle>();
        if(obstacle != null)
        {
            _lastPosition = obstacle.SetRandomPlace(_lastPosition);
        }
    }
}
