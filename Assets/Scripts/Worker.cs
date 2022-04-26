using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour
{
    public string name;
    public int morale;
    public int productivity;
    public float workTimer = 10;
    public float setTime = 5f;
    public GameObject package;
    public bool working = false;
    private Rigidbody packBody;
    private float packageTimer;
    Collider m_collider;
    // Start is called before the first frame update
    void Start()
    {
        morale = 100;
        productivity = 100;
        m_collider = GetComponent<Collider>();
        packageTimer = setTime;
    }

    // Update is called once per frame
    void Update()
    {
        workTimer -= Time.deltaTime;
        if (workTimer <= 0)
        {
            DecreaseMoraleTimer();
            workTimer = 10;
        }
        if (morale <= 30)
        {
            Destroy(gameObject);
        }
        if (working)
        {
            packageTimer -= Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Grabbable")
        {
            package = other.gameObject;
            working = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Grabbable")
        {
            if (working)
            {
                packBody = package.GetComponent<Rigidbody>();
                packBody.velocity = new Vector3(0, 0, 0);
                m_collider.enabled = !m_collider.enabled;
            }
            if (packageTimer <= 0)
            {
                package.tag = "Finished";
                working = false;
                m_collider.enabled = true;
                packageTimer = setTime;
            }
        }
    }

    public int returnMorale()
    {
        return morale;
    }

    public string returnName()
    {
        return name;
    }

    public int returnProductivity()
    {
        return productivity;
    }

    public void ReduceMorale()
    {
        morale -= 10;
        productivity += 10;
        Debug.Log("Morale: " + morale);
        Debug.Log("Productivity: " + productivity);
    }

    public void IncreaseMorale()
    {
        morale += 10;
        productivity += 10;
        Debug.Log("Morale: " + morale);
        Debug.Log("Productivity: " + productivity);
    }

    public void DecreaseMoraleTimer()
    {
        morale -= 1;
        productivity -= 1;
        Debug.Log("Morale: " + morale);
        Debug.Log("Productivity: " + productivity);
    }
}
