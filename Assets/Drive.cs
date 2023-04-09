using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// A very simplistic car driving on the x-z plane.

public class Drive : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    public GameObject fuel;
    bool autopilot = false;
    float tspeed = 2f;
    float rspeed = 0.1f;


    private Quaternion _quaternion;
    private Quaternion _writeQuaternion;
    private Quaternion _tempQuaternion;
    private float _myAngle;

    [SerializeField]private float angleX;
    [SerializeField]private float angleY;
    [SerializeField]private float angleZ;

    void Start()
    {
        _writeQuaternion = transform.rotation;

    }

    void AutoPilot()
    {
        StartCoroutine(RotateToPlayer());
        //this.transform.position += -this.transform.forward * tspeed * Time.deltaTime;
    }

    IEnumerator RotateToPlayer()
    {
        CalculateAngle();
        yield return new WaitForSeconds(3f);
    }

    void CalculateAngle()
    {
        Vector3 tankForward = transform.forward;
        Vector3 fuelDirection = fuel.transform.position - transform.position;

        Debug.DrawRay(this.transform.position, tankForward * 10, Color.green, 5);
        Debug.DrawRay(this.transform.position, fuelDirection, Color.red, 5);

        float dot = tankForward.x * fuelDirection.x + tankForward.y * fuelDirection.y;
        float angle = Mathf.Acos(dot / (tankForward.magnitude * fuelDirection.magnitude));

        Debug.Log("Angle: " + angle * Mathf.Rad2Deg);
        Debug.Log("Unity Angle: " + Vector3.Angle(tankForward, fuelDirection));

        int clockwise = 1;
        if (Cross(tankForward, fuelDirection).z < 0)
            clockwise = -1;

        if ((angle * Mathf.Rad2Deg) > 10) ;
        var myAngle_sim = angle * Mathf.Rad2Deg;
        var myAngle_full = myAngle_sim * clockwise;
        this.transform.Rotate(0, myAngle_full * rspeed, 0);
        //this.transform.rotation = Quaternion.Euler( 0, 0,angle * Mathf.Rad2Deg * clockwise * rspeed);

        /*var mAngle1 = angle * clockwise * rspeed;
        var mAngle2 = angle * Mathf.Rad2Deg * clockwise * rspeed;
        this.transform.rotation = Quaternion.Euler(mAngle2, angleY, angleZ);*/

        _writeQuaternion = this.transform.rotation;
        var x = _writeQuaternion.x;
        var y = _writeQuaternion.y;
        var z = _writeQuaternion.z;
        var xE = _writeQuaternion.eulerAngles.x;
        var yE = _writeQuaternion.eulerAngles.y;
        var zE = _writeQuaternion.eulerAngles.z;
        Debug.Log($" transform rotation  ({x} {y} {z}); transfrom euler ({xE} {yE} {zE});  MainAngle = {myAngle_full}; MainRadian = {angle}");
        /*this.transform.rotation =
            Quaternion.Euler(_writeQuaternion.eulerAngles.x  , _writeQuaternion.eulerAngles.y , _writeQuaternion.eulerAngles.z + myAngle_full );
        
        _myAngle = myAngle_full;
        _quaternion = this.transform.rotation;*/

    }

    Vector3 Cross(Vector3 v, Vector3 w)
    {
        float xMult = v.y * w.z - v.z * w.y;
        float yMult = v.x * w.z - v.z * w.x;
        float zMult = v.x * w.y - v.y * w.x;

        return (new Vector3(xMult, yMult, zMult));
    }

    float CalculateDistance()
    {
        float distance = Mathf.Sqrt(Mathf.Pow(fuel.transform.position.x - transform.position.x,2) +
                                    Mathf.Pow(fuel.transform.position.y - transform.position.y,2));

        Vector3 fuelPos = new Vector3(fuel.transform.position.x, 0, fuel.transform.position.z);
        Vector3 tankPos = new Vector3(transform.position.x, 0, transform.position.z);
        float uDistance = Vector3.Distance(fuelPos, tankPos);

        Vector3 tankToFuel = fuelPos - tankPos;

        Debug.Log("Distance: " + distance);
        Debug.Log("U Distance: " + uDistance);
        Debug.Log("V Magnitude: " + tankToFuel.magnitude);
        Debug.Log("V SqMagnitude: " + tankToFuel.sqrMagnitude);

        return distance;
    }

    void LateUpdate()
    {
        // Get the horizontal and vertical axis.
        // By default they are mapped to the arrow keys.
        // The value is in the range -1 to 1
        /*float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        // Make it move 10 meters per second instead of 10 meters per frame...
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        // Move translation along the object's z-axis
        transform.Translate(0, translation, 0);

        // Rotate around our y-axis
        transform.Rotate(0, 0, -rotation);*/
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CalculateDistance();
            CalculateAngle();
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            autopilot = !autopilot;
        }

        if (CalculateDistance() < 3)
            autopilot = false;

        if (autopilot)
            AutoPilot();

    }
}