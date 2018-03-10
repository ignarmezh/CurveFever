﻿using System.Linq;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(EdgeCollider2D))]
public class Tail : MonoBehaviour {

    public float pointSpacing = .1f;

    public Transform snake;

    List<Vector2> points;

    LineRenderer line;
    EdgeCollider2D collider;

	// Use this for initialization
	void Start () {
        line = GetComponent<LineRenderer>();
        collider = GetComponent<EdgeCollider2D>();
        points = new List<Vector2>();
        SetPoint();
    }
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(points.Last(),snake.position) > pointSpacing)
        {
            SetPoint(); 

        }

	}

    void SetPoint()
    {
        points.Add(transform.position);

        line.positionCount = points.Count;
        line.SetPosition(points.Count - 1,snake.position);

        collider.points = points.ToArray<Vector2>();
    }
}