using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformLerp : MonoBehaviour
{

    public GameObject m_endObject1;
    public GameObject m_endObject2;
    public float m_desiredDuration;

    private Vector3 m_endPoint1;
    private Vector3 m_endPoint2;

    private Vector3 m_currStartPoint;
    private Vector3 m_currEndPoint;
    private float m_elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        m_endPoint1 = m_endObject1.transform.position;
        m_endPoint2 = m_endObject2.transform.position;

        m_currStartPoint = m_endObject1.transform.position;
        m_currEndPoint = m_endObject2.transform.position;

        transform.position = m_endPoint1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // move the platform
        m_elapsedTime += Time.deltaTime;
        float percentageComplete = m_elapsedTime / m_desiredDuration;

        transform.position = Vector3.Lerp(m_currStartPoint, m_currEndPoint, percentageComplete);

        // If weve arrived at 2, go back to 1
        if (transform.position == m_endPoint2)
        {
            m_currStartPoint = m_endPoint2;
            m_currEndPoint = m_endPoint1;
            m_elapsedTime = 0;
        }

        // If weve arrived at 1 go back to 2
        if (transform.position == m_endPoint1)
        {
            m_currStartPoint = m_endPoint1;
            m_currEndPoint = m_endPoint2;
            m_elapsedTime = 0;
        }
    }
}
