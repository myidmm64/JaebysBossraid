using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiatEndDestory : PoolableMono
{
    public void ObjectDes()
    {
        PoolManager.Instance.Push(this);
    }

    public override void Reset()
    {
        transform.position = Vector3.zero;
    }
}
