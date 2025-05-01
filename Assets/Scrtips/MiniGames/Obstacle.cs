using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float _holeSizeMin = 1f;
    [SerializeField] private float _holeSizeMax = 3f;
    [SerializeField] private float _highPositionY = 1f;
    [SerializeField] private float _lowPositionY = -1f;
    [SerializeField] private float _widthPadding = 4f;

    [SerializeField] private GameObject _top;
    [SerializeField] private GameObject _bottom;

    // Start is called before the first frame update
    public Vector3 SetRandomPlace(Vector3 lastPosition)
    {
        Debug.Log("SetRandomPlace");
        float holeSize = Random.Range(_holeSizeMin, _holeSizeMax);
        float positionY = Random.Range(_lowPositionY, _highPositionY);
        _top.transform.localPosition = new Vector3(0, holeSize / 2f, 0);
        _bottom.transform.localPosition = new Vector3(0, -holeSize / 2f, 0);

        Vector3 placePosition = new Vector3(lastPosition.x + _widthPadding, positionY, 0);
        transform.position = placePosition;
        return placePosition;
    }
}
