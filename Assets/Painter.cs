using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painter : MonoBehaviour
{
    #region member variables

    public GameObject _paintPrefab;
    public float _drawRate;

    private float _rate = 0f;

    #endregion

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _rate += Time.deltaTime;
            if (_rate > _drawRate)
            {
                _rate = 0f;
                Instantiate(_paintPrefab, Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 1), Quaternion.identity, transform);
            }
        }
    }
}
