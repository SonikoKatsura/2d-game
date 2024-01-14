using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    const string LEFT = "left";
    const string RIGHT = "right";
    [SerializeField] float speed; // Referencia a la velocidad de movimiento
    [SerializeField] Rigidbody2D rb; // Referencia al Rigidbody2D
    [SerializeField] string direction; // Dirección del movimiento
    [SerializeField] Transform castPos;
    [SerializeField] float baseCastDistX;
    [SerializeField] float baseCastDistY;
    [SerializeField] Vector3 baseScale;

    // Esta función se ejecuta una vez al comienzo
    public void Start()
    {
        // Obtenemos la escalado original del enemigo
        baseScale = transform.localScale;
        direction = RIGHT;
    }
    // Esta función se ejecuta cada X tiempoa
    public void FixedUpdate()
    {
        float vX = speed;

        if (direction == LEFT)
        {
            vX = -speed; ;

        }

        rb.velocity = new Vector2(vX, rb.velocity.y);

        if (IsHittingWall() || IsNearEdge())
        {
            if (direction == LEFT)
            {
                ChangeDirection(RIGHT);
            }
            else if (direction == RIGHT)
            {
                ChangeDirection(LEFT);
            }

        }

        void ChangeDirection(string newDirection)
        {
            Vector3 newScale = baseScale;
            if (newDirection == LEFT)
            {
                newScale.x = -baseScale.x;
            }
            else if (newDirection == RIGHT)
            {
                newScale.x = baseScale.x;
            }
            transform.localScale = newScale;
            direction = newDirection;

        }
        bool IsHittingWall()
        {
            bool val = false;
            float castDist = baseCastDistX;
            //define cast distance for left & right
            if (direction == LEFT)
            {
                castDist = -baseCastDistX;
            }
            else
            {
                castDist = baseCastDistX;
            }
            //determine target destination based on cast distance
            Vector3 targetPos = castPos.position;
            targetPos.x += castDist;
            Debug.DrawLine(castPos.position, targetPos, Color.red);
            if (Physics2D.Linecast(castPos.position, targetPos, 1 << LayerMask.NameToLayer("Terrain")))
            {
                val = true;
            }
            else val = false;

            return val;
        }
        bool IsNearEdge()
        {
            bool val = true;
            float castDist = baseCastDistY;
            //determine target destination based on cast distance
            Vector3 targetPos = castPos.position;
            targetPos.y -= castDist;
            Debug.DrawLine(castPos.position, targetPos, Color.yellow);
            if (Physics2D.Linecast(castPos.position, targetPos, 1 << LayerMask.NameToLayer("Terrain")))
            {
                val = false;
            }
            else val = true;

            return val;
        }
    }
}
