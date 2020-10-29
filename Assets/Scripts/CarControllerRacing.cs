using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControllerRacing : MonoBehaviour
{
	private const string HORIZONTAL = "Horizontal";
	private const string VERTICAL = "Vertical";
	
	private float horizontalInput;
	private float verticalInput;
	private float steerAngle;
	private float currentbreakForce;
	private bool isBreaking;
	private bool isNitro;

	[SerializeField] public float motorForce;
	[SerializeField] public float breakForce;
	[SerializeField] public float maxSteeringAngle;
	
	[SerializeField] public float nitro;
	[SerializeField] public float kmh;
	
	[SerializeField] private WheelCollider frontLeftWheelCollider;
	[SerializeField] private WheelCollider frontRightWheelCollider;
	[SerializeField] private WheelCollider rearLeftWheelCollider;
	[SerializeField] private WheelCollider rearRightWheelCollider;
	
	[SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform;
    [SerializeField] private Transform rearRightWheelTransform;
	
	[SerializeField] private Vector3 centerOfMass;
	private Rigidbody _rb;
	
	private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.centerOfMass = centerOfMass;
    }
	
	private void FixedUpdate()
	{
		GetInput();
		HandleMotor();
		HandleSteering();
		UpdateWheels();
	}
	
	private void HandleMotor()
	{
		frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
		frontRightWheelCollider.motorTorque = verticalInput * motorForce;
		
		//breakforce if breaking then breakforce else 0
		currentbreakForce = isBreaking ? breakForce : 0f;
		if(isBreaking)
		{	
			frontLeftWheelCollider.brakeTorque = currentbreakForce;
			frontRightWheelCollider.brakeTorque = currentbreakForce;
			rearLeftWheelCollider.brakeTorque = currentbreakForce;
			rearRightWheelCollider.brakeTorque = currentbreakForce;
		}
		else
		{
			frontLeftWheelCollider.brakeTorque = 0f;
			frontRightWheelCollider.brakeTorque = 0f;
			rearLeftWheelCollider.brakeTorque = 0f;
			rearRightWheelCollider.brakeTorque = 0f;
		}
		
		if(isNitro&& !isBreaking && nitro > 0)
		{
			frontLeftWheelCollider.motorTorque = verticalInput * motorForce * 1000f;
			frontRightWheelCollider.motorTorque = verticalInput * motorForce * 1000f;
			nitro = nitro - 0.5f;
		}
		else if(!isNitro && nitro <= 99.9)
		{
			nitro = nitro + 0.01f;
		}
		
		kmh = _rb.velocity.magnitude*3.6f;
		
	}
	
	private void GetInput()
	{
		horizontalInput = Input.GetAxis(HORIZONTAL);
		verticalInput = Input.GetAxis(VERTICAL);
		isBreaking = Input.GetKey(KeyCode.Space);
		isNitro = Input.GetKey(KeyCode.Mouse0);
		//Debug.Log("isBreaking = " + isBreaking + "    isNitro = " + isNitro);
	}
	
	private void HandleSteering()
	{
		steerAngle = maxSteeringAngle * horizontalInput;
		frontLeftWheelCollider.steerAngle = steerAngle;
		frontRightWheelCollider.steerAngle = steerAngle;
	}	
	
	private void UpdateWheels()
    {
        UpdateWheelPos(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateWheelPos(frontRightWheelCollider, frontRightWheelTransform);
        UpdateWheelPos(rearLeftWheelCollider, rearLeftWheelTransform);
        UpdateWheelPos(rearRightWheelCollider, rearRightWheelTransform);
    }

    private void UpdateWheelPos(WheelCollider wheelCollider, Transform trans)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        trans.rotation = rot;
        trans.position = pos;
    }
}	

