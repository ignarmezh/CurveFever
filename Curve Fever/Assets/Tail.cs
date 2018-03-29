using System.Linq;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(EdgeCollider2D))]
public class Tail : MonoBehaviour {

    public float pointSpacingForColliderEdge = 0.1f;

    public Transform snake;

    List<Vector2> pointsColliderEdge;
    List<Vector2> pointsLineRend;

    LineRenderer line;
    EdgeCollider2D colliderEdge;

	// Use this for initialization
	void Start () {
        line = GetComponent<LineRenderer>();
        colliderEdge = GetComponent<EdgeCollider2D>();
        pointsColliderEdge = new List<Vector2>();
        pointsLineRend = new List<Vector2>();
        SetPointColliderEdge();
        SetPointLine();
    }
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(pointsColliderEdge.Last(),snake.position) > pointSpacingForColliderEdge)
        {
            SetPointColliderEdge(); 
        }
        SetPointLine();
    }

    void SetPointColliderEdge()
    {
        if (pointsColliderEdge.Count > 1)
            colliderEdge.points = pointsColliderEdge.ToArray();
        pointsColliderEdge.Add(snake.position);
        
    }

    void SetPointLine()
    {
        pointsLineRend.Add(snake.position);

        line.positionCount = pointsLineRend.Count;
        line.SetPosition(pointsLineRend.Count - 1,snake.position);
        
    }
}
