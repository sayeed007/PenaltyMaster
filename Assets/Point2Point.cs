using UnityEngine;
using System.Collections;

public class Point2Point : MonoBehaviour
{
    public Vector3 PointB;
    IEnumerator Start()
    {
        var PointA = transform.position;
        while (true)
        {
            yield return StartCoroutine(MoveObject(transform, PointA, PointB, 3.0f));
            yield return StartCoroutine(MoveObject(transform, PointB, PointA, 3.0f));
        }
    }
    IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
    {
        var i = 0.0f;
        var rate = 4.0f / time;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            thisTransform.position = Vector3.Lerp(startPos, endPos, i);
            yield return null;
        }
    }
}
