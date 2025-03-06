using UnityEngine;

public class Airplpane : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float enginePower = 50f;
    [SerializeField] float liftBooster = 0.5f;
    [SerializeField] float drag = 0.003f;
    [SerializeField] float angularDrag = 0.03f;

    [SerializeField] float yawPower = 50f;
    [SerializeField] float pitchPower = 50f;
    [SerializeField] float rollPower = 30f;

    //float roll = Input.GetAxis("Roll");

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();

      
    }
   
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space)) //Press Space to move forward 1.Engine
        {
            rb.AddForce(transform.forward * enginePower);
                    
        }
        Vector3 lift = Vector3.Project(rb.linearVelocity, transform.forward);
        rb.AddForce(transform.up * lift.magnitude * liftBooster); //2.Lift Force

        //3. Drag (Air Resi)
        rb.linearDamping = rb.linearVelocity.magnitude * drag; //slowdown mobement
        rb.angularDamping = rb.linearVelocity.magnitude * angularDrag; //slowdown rotation

        //4.Rotation
        float yaw = Input.GetAxis("Horizontal") * yawPower; //L and R (Q/E)
        float pitch = Input.GetAxis("Vertical") * pitchPower; // Nose Up/down
        float roll = Input.GetAxis("Roll") * rollPower; // Roll (A/D)

        rb.AddTorque(transform.up * yaw); // turn L R
        rb.AddTorque(transform.right * pitch); // pitch nose up/down
        rb.AddTorque(transform.forward * roll); // roll (tilting)
    }
}
