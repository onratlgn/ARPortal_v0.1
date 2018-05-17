using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class InterDimensionalTransport : MonoBehaviour {

	public Material[] materials;
	public Transform device;

	void Start () {
		
		if(device==null){
			device = GameObject.FindGameObjectWithTag("ARcam").gameObject.transform;		
		}

		foreach (var mat in materials)
		{
			mat.SetInt("_StencilTest",(int)CompareFunction.Equal);
		}
	}

	void OnTriggerStay(Collider other){
		if(other.transform != device)
			return;

		// outside of other the world
		if(transform.position.z > other.transform.position.z)
		{
			Debug.Log("Outside");
			foreach (var mat in materials)
			{
				mat.SetInt("_StencilTest",(int)CompareFunction.Equal);
			}
		// inside of other the world
		}else{
			Debug.Log("Inside");
			foreach (var mat in materials)
			{
				mat.SetInt("_StencilTest",(int)CompareFunction.NotEqual);
			}
		}
	}
	
	void OnDestroy(){
		foreach (var mat in materials)
		{
			mat.SetInt("_StencilTest",(int)CompareFunction.NotEqual);
		}
	}
	
	void Update () {
		
	}
}
