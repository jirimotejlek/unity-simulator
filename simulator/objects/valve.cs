using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SVGImporter;

namespace HessModelEngine.Objects {
	public class Valve:ChemEObject {
		public CHPoint Inlet {get {return CHPoint.Inlet;}}  
		public CHPoint Outlet {get {return CHPoint.Outlet;}}
		
		private bool valveOn = false;
		private Dictionary<ChemEObject, float> possiblePositions = new Dictionary<ChemEObject, float>();
		private int volume = 3;

		public Valve() {
			ValveOn = false;
		}

		void RepaintState() {
			if (this.AssociatedObject != null) {
				if (this.valveOn)
					AssociatedObject.GetComponent<SVGImage>().color  = SimulationModel.defaultColor;
				else
					AssociatedObject.GetComponent<SVGImage>().color  = SimulationModel.closedColor;
			}
		}

		public override void OnAssociatedObject() {
			RepaintState();
		}

		public bool ValveOn {
			get{return valveOn;} 
			set {
				valveOn = value;
				RepaintState();
			}
		}

		public override float QuantumProbabilityCalc(Quantum quantum) {
			if (valveOn && Quantums.Count < volume*2)
				return 1f;
			else
				return 0f;
		}
		public override Dictionary<ChemEObject, float> CalculatePossiblePositions(Quantum quantum) {
			possiblePositions.Clear();
			for (int i = 0; i < NextPosition.Count; i++) {
				possiblePositions.Add(NextPosition.Keys.ElementAt(i), NextPosition.Keys.ElementAt(i).QuantumProbabilityCalc(quantum));
			}	
			for (int i = 0; i< PreviousPosition.Count; i++) {
				possiblePositions.Add(PreviousPosition.Keys.ElementAt(i), PreviousPosition.Keys.ElementAt(i).QuantumProbabilityCalc(quantum));
			}							
			return possiblePositions;
		}			
	}

	public class ControlValve:ChemEObject {
		public CHPoint Inlet() {return CHPoint.Inlet;}  
		public CHPoint Outlet() {return CHPoint.Outlet;}
		
		private float openValue = 0f;
		private Dictionary<ChemEObject, float> possiblePositions = new Dictionary<ChemEObject, float>();
		private int volume = 3;

		public ControlValve() {
			
		}

		public override float QuantumProbabilityCalc(Quantum quantum) {
			return openValue;
		}

		public float OpenValue {
			get {return openValue;}
			set {openValue = value;}
		}

		public override void OnAssociatedObject() {
		}

		public override Dictionary<ChemEObject, float> CalculatePossiblePositions(Quantum quantum) {
			possiblePositions.Clear();
			for (int i = 0; i < NextPosition.Count; i++) {
				possiblePositions.Add(NextPosition.Keys.ElementAt(i), NextPosition.Keys.ElementAt(i).QuantumProbabilityCalc(quantum));
			}				
			return possiblePositions;
		}			
	}

	public class SafetyValve:ChemEObject {
		public CHPoint Inlet() {return CHPoint.Inlet;}  
		public CHPoint Outlet() {return CHPoint.Outlet;}
		
		private bool valveOn = false;
		private float designatedPressure = 30f;
		private Dictionary<ChemEObject, float> possiblePositions = new Dictionary<ChemEObject, float>();
		private int volume = 3;

		public bool ValveOn {
			get{return valveOn;}
			set{valveOn = value;} 
		}
		public float DesignatedPressure {
			get{return designatedPressure;}
			set{designatedPressure = value;}
		}

		public override float QuantumProbabilityCalc(Quantum quantum) {
			return 0f;
		}	

		public override void OnAssociatedObject() {
		}

		public override Dictionary<ChemEObject, float> CalculatePossiblePositions(Quantum quantum) {
			possiblePositions.Clear();
			for (int i = 0; i < NextPosition.Count; i++) {
				possiblePositions.Add(NextPosition.Keys.ElementAt(i), NextPosition.Keys.ElementAt(i).QuantumProbabilityCalc(quantum));
			}				
			return possiblePositions;
		}				
	}
}