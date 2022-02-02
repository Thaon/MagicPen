using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painter : MonoBehaviour
{
    #region member variables

    public GameObject _paintPrefab;
    public float _drawRate;
    public float _overlapTreshold;

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
                var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 1);
                //check for overlap
                Collider[] colls = Physics.OverlapBox(pos, new Vector3(_overlapTreshold / 10, _overlapTreshold / 10, _overlapTreshold / 10));
                if (colls.Length == 0)
                    Instantiate(_paintPrefab, pos, Quaternion.identity, transform);
            }
        }
    }
}
