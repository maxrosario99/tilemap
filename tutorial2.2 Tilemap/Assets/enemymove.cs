using UnityEngine;

public class enemymove : MonoBehaviour
{
    public int EnemySpeed;
    public int XMoveDirection;
    private float waitTime = 2.0f;
    void Update()
    {
        // Set the x position to loop between 0 and 3
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (XMoveDirection, 0) * EnemySpeed;
        if (Time.time > waitTime){
            Flip ();
        }
        }
    void Flip()
    {
        if (XMoveDirection > 0) {
            XMoveDirection = -1;
        } else {
            XMoveDirection = 1;
        }

    }
    }
    
