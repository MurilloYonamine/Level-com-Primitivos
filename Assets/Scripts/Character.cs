using Unity.VisualScripting;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Vector3 targetPlace;
    private Vector3 initialPosition;
    private Vector3 finalPosition;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float distance = 5f;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        targetPlace = transform.position + new Vector3(distance, 0, 0);
        initialPosition = transform.position;
        finalPosition = targetPlace;
    }

    void Update()
    {
        Movement(targetPlace);
        if (Vector3.Distance(transform.position, targetPlace) < 0.2f )
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
            targetPlace = targetPlace == initialPosition ? finalPosition : initialPosition;
        }

    }
    private void Movement(Vector3 target)
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);
    }
}
