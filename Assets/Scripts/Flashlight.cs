using UnityEngine;

public class Flashlight : MonoBehaviour {
	
	private Light flashlight;
	
	public AnimationCurve lightCurve;
	private bool switchOn = false;
	
	private float maxBatteryLife = 3600f;
	private float batteryLife;

	void Start(){
		flashlight = GetComponentInChildren<Light>().light;
		
		flashlight.range = 15f;
		flashlight.spotAngle = 60f;
		flashlight.intensity = 2f;
		
		batteryLife = Random.Range(maxBatteryLife*0.5f, maxBatteryLife);
		
		TurnOff();
	}
	
	void Update(){
		
		if(Input.GetKeyDown(KeyCode.F) && batteryLife > 0){
			TurnOnOff();
		}
		
		if(switchOn){
			batteryLife -= Time.deltaTime;
			
			if(batteryLife <= 0){
				batteryLife = 0;
				TurnOff();
			}
			
			float batteryCurveEval = lightCurve.Evaluate(1.0f-batteryLife/maxBatteryLife);
			flashlight.intensity -= (batteryCurveEval/maxBatteryLife*0.5f) * Time.time;
		}
	}
	
	void TurnOnOff(){
		switchOn = !switchOn;
		flashlight.enabled = !flashlight.enabled;
	}
	
	void TurnOff(){
		flashlight.enabled = false;
	}
}
