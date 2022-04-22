using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Package : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    float m_thrust = 20f;
    public Transform teleporterNExit;
    public Transform teleporterWExit;
    public Transform teleporterEExit;
    public Transform teleporterSExit;
    bool conveyorN = false;
    bool conveyorE = false;
    bool conveyorS = false;
    bool conveyorW = false;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ConveyorN")
        {
            conveyorN = true;
        }
        if (other.tag == "ConveyorE")
        {
            conveyorE = true;
        }
        if (other.tag == "ConveyorS")
        {
            conveyorS = true;
        }
        if (other.tag == "ConveyorW")
        {
            conveyorW = true;
        }
        if (other.tag == "TeleporterN")
        {
            teleporterNExit = GameObject.Find("TeleporterNExit").transform;
            gameObject.transform.position = teleporterNExit.position;
            m_Rigidbody.velocity = new Vector3(0, 0, 0);
        }
        if (other.tag == "TeleporterN" && gameObject.tag == "Finished")
        {
            Destroy(gameObject);
        }
        if (other.tag == "TeleporterW")
        {
            teleporterWExit = GameObject.Find("TeleporterWExit").transform;
            gameObject.transform.position = teleporterWExit.position;
            m_Rigidbody.velocity = new Vector3(0, 0, 0);
        }
        if (other.tag == "TeleporterE")
        {
            teleporterEExit = GameObject.Find("TeleporterEExit").transform;
            gameObject.transform.position = teleporterEExit.position;
            m_Rigidbody.velocity = new Vector3(0, 0, 0);
        }
        if (other.tag == "TeleporterS")
        {
            teleporterSExit = GameObject.Find("TeleporterSExit").transform;
            gameObject.transform.position = teleporterSExit.position;
            m_Rigidbody.velocity = new Vector3(0, 0, 0);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "ConveyorN")
        {
            conveyorN = true;
        }
        if (other.tag == "ConveyorE")
        {
            conveyorE = true;
        }
        if (other.tag == "ConveyorS")
        {
            conveyorS = true;
        }
        if (other.tag == "ConveyorW")
        {
            conveyorW = true;
        }
    }

    private void OnTriggerExit()
    {
        conveyorN = false;
        conveyorE = false;
        conveyorS = false;
        conveyorW = false;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (conveyorN)
        {
            m_Rigidbody.rotation = Quaternion.identity;
            m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            m_Rigidbody.AddForce(transform.forward * m_thrust);
        }
        if (conveyorE)
        {
            m_Rigidbody.rotation = Quaternion.identity;
            m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            m_Rigidbody.AddForce(transform.right * m_thrust);
        }
        if (conveyorS)
        {
            m_Rigidbody.rotation = Quaternion.identity;
            m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            m_Rigidbody.AddForce(transform.forward * -m_thrust);
        }
        if (conveyorW)
        {
            m_Rigidbody.rotation = Quaternion.identity;
            m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            m_Rigidbody.AddForce(transform.right * -m_thrust);
        }
    }
}