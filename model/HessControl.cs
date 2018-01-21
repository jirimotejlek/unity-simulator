using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HessModelEngine;
using SVGImporter;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using HessModelEngine.Objects;

public class HessControl : MonoBehaviour {
	bool SimulationStarted = false;
	float timer = 0f;

	public Text DebugText;
	public Text Tooltip;
	

	void AssignObject(ChemEObject value) {
		// Events associations
		value.AssociatedObject = GameObject.Find(value.Name+"/Symbol");

		if (value.AssociatedObject != null) {
			if (value.AssociatedObject.transform.parent.gameObject.GetComponent<EventTrigger>() != null) {
				value.AssociatedObject.GetComponentInParent<EventTrigger>().triggers[0].callback.AddListener((eventData) => { ShowTooltip(value); });
				value.AssociatedObject.transform.parent.gameObject.GetComponentInParent<EventTrigger>().triggers[1].callback.AddListener((eventData) => { HideTooltip(); });
				// onClick
				if (value is Valve) 
					value.AssociatedObject.GetComponentInParent<EventTrigger>().triggers[2].callback.AddListener((eventData) => { ClickValve((Valve)value); });
					
				if (value is Pump)
					value.AssociatedObject.GetComponentInParent<EventTrigger>().triggers[2].callback.AddListener((eventData) => { ClickPump((Pump)value); });
								
			}
		}
	}

	public void ShowTooltip(ChemEObject value) {
		 for (int i = 0; i < value.Quantums.Count; i++)
		 	Tooltip.text = Tooltip.text + value.Quantums[i].Index.ToString() + "-" + value.Quantums[i].PreviousPosition.Name + "*" + "\n";
	}
	public void HideTooltip() {
		Tooltip.text = "";
	}


	void Start () {
		Tooltip = GameObject.Find("Canvas/Tooltiptext").GetComponent<Text>();

		AssignObject(SimulationModel.hModel.ProcessWater);

		//Assigning frontend to the backend
		foreach (ChemEObject pipe in SimulationModel.hModel.Pipes) 
			AssignObject(pipe);
		foreach (ChemEObject hose in SimulationModel.hModel.Hoses) 
			AssignObject(hose);
		foreach (ChemEObject drain in SimulationModel.hModel.Drains) 
			AssignObject(drain);			
		foreach (ChemEObject vent in SimulationModel.hModel.Vents) 
			AssignObject(vent);

		AssignObject(SimulationModel.hModel.V01);
		AssignObject(SimulationModel.hModel.V02);
		AssignObject(SimulationModel.hModel.V03);
		AssignObject(SimulationModel.hModel.V04);
		AssignObject(SimulationModel.hModel.V05);
		AssignObject(SimulationModel.hModel.V06);
		AssignObject(SimulationModel.hModel.V11);
		AssignObject(SimulationModel.hModel.V12);
		AssignObject(SimulationModel.hModel.DI1);

		AssignObject(SimulationModel.hModel.C1);
		AssignObject(SimulationModel.hModel.V07);

		AssignObject(SimulationModel.hModel.RV1);
		AssignObject(SimulationModel.hModel.V56);
		AssignObject(SimulationModel.hModel.PHE2);
		AssignObject(SimulationModel.hModel.V57);
		AssignObject(SimulationModel.hModel.P3);
		AssignObject(SimulationModel.hModel.UT19_V01);
		AssignObject(SimulationModel.hModel.UT19_V02);
		AssignObject(SimulationModel.hModel.UT19_P1);
		AssignObject(SimulationModel.hModel.UT19_V03);
		AssignObject(SimulationModel.hModel.UT19_V04);
		AssignObject(SimulationModel.hModel.UT19_V05);

		AssignObject(SimulationModel.hModel.V14);
		AssignObject(SimulationModel.hModel.V23);
		AssignObject(SimulationModel.hModel.CV34);
		AssignObject(SimulationModel.hModel.SV35);
		AssignObject(SimulationModel.hModel.V13);
		AssignObject(SimulationModel.hModel.V21);

		//SimulationModel.hModel.V01.AssociatedObject = V01.transform.Find("Symbol").gameObject;
		//SimulationModel.hModel.V01.AssociatedObject.GetComponent<SVGImage>().color  = highlightColor;
		SimulationModel.hModel.SimulationInitialise();
	}

	public void Simulation() {
		if (SimulationStarted)
			CancelInvoke("SimulationRepeatFunction");
		else
			InvokeRepeating("SimulationRepeatFunction", 0f, 0.01f);

		SimulationStarted = !SimulationStarted;
	}

	void SimulationRepeatFunction() {
		SimulationModel.hModel.Simulation();
		DebugText.text = "Total Count: " + SimulationModel.hModel.AllQuantums.Count + "\n";
		for (int i = 0; i < SimulationModel.hModel.AllQuantums.Count; i++) {
			string previousName = SimulationModel.hModel.AllQuantums[i].PreviousPosition != null ? SimulationModel.hModel.AllQuantums[i].PreviousPosition.Name : "xxx";
			string positionName = SimulationModel.hModel.AllQuantums[i].Position != null ? SimulationModel.hModel.AllQuantums[i].Position.Name : "";
		 	DebugText.text += SimulationModel.hModel.AllQuantums[i].Index.ToString() +
			 			   " - " + previousName + " -> " + positionName + "\n";	
		}
	}

	public void ClickValve(Valve value) {
		value.ValveOn = !value.ValveOn;
		Debug.Log("Valve clicked!");
	}
	public void ClickPump(Pump value) {
		value.PumpOn = !value.PumpOn;
		Debug.Log("Pump clicked!");
	}


	// Update is called once per frame
	void Update () {

	}
}
