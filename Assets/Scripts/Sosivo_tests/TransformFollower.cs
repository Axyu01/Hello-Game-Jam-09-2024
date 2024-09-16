using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformFollower : MonoBehaviour
{
    [SerializeField]
    Transform _followedTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_followedTransform == null)
        {
            Debug.LogError("Assign Transform to this TransformFollower script!");
            return;
        }
        transform.position = _followedTransform.position;
        transform.rotation = _followedTransform.rotation;
        transform.localScale = _followedTransform.localScale;
    }
}
