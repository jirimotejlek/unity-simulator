using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SVGImporter;

namespace HessModelEngine.Objects {
	public class Pump:ChemEObject {
		public CHPoint Inlet {get {return CHPoint.Inlet;}}  
		public CHPoint Outlet {get {return CHPoint.Outlet;}}
		
		private float waterFlow = 10f;
		private bool pumpOn = false;
		private Dictionary<ChemEObject, float> possiblePositions = new Dictionary<ChemEObject, float>();
		private int volume = 3;
		
		public float WaterFlow {
			get{return waterFlow;}
			private set{waterFlow = value;}
		}
		public bool PumpOn {
			get {return pumpOn;}
			set {
				pumpOn = value; 
				RepaintState();
			}
		}

		void RepaintState() {
			if (this.AssociatedObject != null) {
				if (this.pumpOn)
					AssociatedObject.GetComponent<SVGImage>().color  = SimulationModel.runningColor;
				else
					AssociatedObject.GetComponent<SVGImage>().color  = SimulationModel.closedColor;
			}
		}


		public override void OnAssociatedObject() {
			RepaintState();
		}

		public override float QuantumProbabilityCalc(Quantum quantum) {
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
}