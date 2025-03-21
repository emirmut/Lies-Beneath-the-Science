using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    [SerializeField] private BoxCollider2D walkingCollider;
    [SerializeField] private BoxCollider2D attackingCollider;
    [SerializeField] private AIPath aIPath;

    private bool isDead;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (aIPath.desiredVelocity.x >= 0.001f) {
            transform.localScale = new Vector3(0.04078622f, 0.04078622f, 0.04078622f);
        } else if (aIPath.desiredVelocity.x <= -0.001f) {
            transform.localScale = new Vector3(-0.04078622f, 0.04078622f, 0.04078622f);
        }
    }

    private void FixedUpdate() 
    {
        
    }

    
}
