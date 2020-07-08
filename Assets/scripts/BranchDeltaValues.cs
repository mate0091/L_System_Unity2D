using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchDeltaValues : MonoBehaviour
{
    public void ChangeValues(int index)
    {
        transform.position += transform.up * transform.localScale.y;
        //transform.Rotate(0, 0, 30 * ((index * 2) - 1));
        RotateBranches(index);
        ScaleBranch();
    }

    private void RotateBranches(int i)
    {
        if (i == 1)
        {
            transform.Rotate(0, 0, 25);
        }
        else
        {
            transform.Rotate(0, 0, -15);
        }
    }

    private void ScaleBranch()
    {
        transform.localScale *= .8f;
    }
}
