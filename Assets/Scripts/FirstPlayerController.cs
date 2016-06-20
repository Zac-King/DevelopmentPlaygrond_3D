using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class FirstPlayerController : MonoBehaviour
{
    /// <summary>
    /// RigidBody based first person movement
    /// 
    /// </summary>
    
    #region // Variables //
    [Header ("Movement Variables")]
    [SerializeField] private float m_speed = 3;
    private Rigidbody m_rigidbody;
    [SerializeField] private float m_jumpForce = 0;
    [SerializeField] [Range(0, 1)] private float m_jumpAngle  = 0;
    [SerializeField] private float m_gravityMod = 0;
    [Space(10)]
    
    [Header("Grounded variables")]
    [SerializeField] private Transform m_groundCheck;
    [SerializeField] private float m_groundCheckRadius = 0.5f;
    [SerializeField] private LayerMask m_WhatIsGround;
    private bool m_grounded = false;
    #endregion

    #region // Unity //
    void Start ()
    {
        m_rigidbody = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate ()
    {
        m_grounded = (Physics.OverlapSphere(m_groundCheck.position, m_groundCheckRadius, m_WhatIsGround)[0] != null);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))    // Forward Movement
        { m_rigidbody.AddForce(gameObject.transform.forward * (m_speed / Time.deltaTime)); }
        if (Input.GetKey(KeyCode.A))    // Left Movement
        { m_rigidbody.AddForce(-gameObject.transform.right * (m_speed / Time.deltaTime)); }
        if (Input.GetKey(KeyCode.S))    // Backward Movement
        { m_rigidbody.AddForce(-gameObject.transform.forward * (m_speed / Time.deltaTime)); }
        if (Input.GetKey(KeyCode.D))    // Right Movement
        { m_rigidbody.AddForce(gameObject.transform.right * (m_speed / Time.deltaTime)); }

        if (m_grounded) // Only allow jump if player is grounded
        {
            Vector3 jump = ((m_rigidbody.velocity.normalized * Mathf.Abs(m_jumpAngle - 1)) + (new Vector3(0, 1, 0) * m_jumpAngle)) * (m_jumpForce / Time.deltaTime);
            if (Input.GetKey(KeyCode.Space))    // Jump Vertical Movement
            { m_rigidbody.AddForce(jump); m_grounded = false; }
        }

        else // Player falls
        {
            m_rigidbody.AddForce(new Vector3(0, -9.8f, 0) * m_gravityMod);
        }
    }
    #endregion
}
