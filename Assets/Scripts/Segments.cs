using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Segments : MonoBehaviour
{
    public Snake Snake;
    public float SnakeHeadRange;
    private void FixedUpdate()
    {
       MoveTails();
    }


    public void MoveTails()
    {
        if (Snake.HealthPoints < 0) return;

        float distance = ((Vector3)Snake.HeadTransform.position - Snake.TailsVector[0]).magnitude; 

        if (distance > SnakeHeadRange)
        {
            Vector3 direction = ((Vector3)Snake.HeadTransform.position - Snake.TailsVector[0]).normalized;

            Snake.TailsVector.Insert(0, Snake.TailsVector[0] + direction * SnakeHeadRange);
            Snake.TailsVector.RemoveAt(Snake.TailsVector.Count - 1);

            distance -= SnakeHeadRange;
        }

        for (int i = 0; i < Snake.TailsTransform.Count; i++)
        {
            Vector3 SnakeMove = Vector3.Lerp(Snake.TailsVector[i + 1], Snake.TailsVector[i], distance / SnakeHeadRange);
            Snake.TailsTransform[i].position = SnakeMove;
        }
    }
}
