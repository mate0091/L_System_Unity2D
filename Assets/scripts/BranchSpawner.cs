using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchSpawner : MonoBehaviour
{
    public int recursion;
    public int branchSplitNumber;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(2f);
        recursion--;
        for (int i = 0; i < branchSplitNumber; ++i)
        {
            if (recursion > 0)
            {
                GameObject copy = Instantiate(gameObject);
                BranchSpawner recursive = copy.GetComponent<BranchSpawner>();
                recursive.SendMessage("ChangeValues", i);
            }
        }
    }

    //private Vector3 GetSpawnPosition()
    //{
    //    Bounds positionBounds = transform.Find("sprite").GetComponent<SpriteRenderer>().sprite.bounds;
    //    Vector3 position = new Vector3(positionBounds.center.x, positionBounds.max.y);
    //    //Debug.Log(position);
    //    return position;
    //}
}
