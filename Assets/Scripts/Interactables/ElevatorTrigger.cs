using UnityEngine;

public class ElevatorTrigger : MonoBehaviour
{
    [SerializeField] bool isUp = false;
    Elevator elevator;

    private void Start()
    {
        elevator = this.transform.parent.GetComponent<Elevator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(elevator);

        if (!elevator.isMoving)
        {
            if (!isUp)
            {
                Coroutine movingUp = StartCoroutine(elevator.goingUp());
                isUp = true;
            }

            else
            {
                Coroutine movingDown = StartCoroutine(elevator.goingDown());
                isUp = false;
            }
        }
        
    }
}
