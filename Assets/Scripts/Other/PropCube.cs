using UnityEngine;

public class PropCube : MonoBehaviour
{
    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("DeadZone"))
        {
            if(other != null)
            {
                transform.position = startPos;
            }
        }
    }
}
