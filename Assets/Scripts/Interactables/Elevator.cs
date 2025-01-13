using System.Collections;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] float upPosition;
    [SerializeField] float downPosition;
    [SerializeField] float speed;
    public bool isMoving = false;

    public IEnumerator goingUp() 
    {
        isMoving = true;

        while (this.transform.position.y < upPosition)
        {
            yield return new WaitForSeconds(0.02f);
            this.transform.position += Vector3.up * speed;
        }

        isMoving = false;
    }

    public IEnumerator goingDown()
    {
        isMoving = true;

        while (this.transform.position.y > downPosition)
        {
            yield return new WaitForSeconds(0.02f);
            this.transform.position += Vector3.down * speed;
        }

        isMoving = false;
    }
}
