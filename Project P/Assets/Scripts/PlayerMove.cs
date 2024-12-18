using UnityEngine;

public class PlayerMove : MonoBehaviour
{
   
    public float moveSpeed = 5f;
   
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal,0, vertical).normalized;

        if(movement.magnitude >= 0.1f){
            float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
        }
    }
}
