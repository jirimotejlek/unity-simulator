using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HessModelEngine.Objects {
	public class Boiler:ChemEObject {
		public CHPoint Inlet {get {return CHPoint.Inlet;}}  
		public CHPoint Outlet {get {return CHPoint.Outlet;}}

		public CHPoint Inlet2 {get {return CHPoint.Inlet2;}}  
		public CHPoint Outlet2 {get {return CHPoint.Outlet2;}}
		
		private float temperature = 75f;
		private Dictionary<ChemEObject, float> possiblePositions = new Dictionary<ChemEObject, float>();
		
		public float Temperature {
			get{return temperature;}
			set{temperature = value;}
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
			for (int i = 0; i< PreviousPosition.Count; i++) {
				possiblePositions.Add(PreviousPosition.Keys.ElementAt(i), PreviousPosition.Keys.ElementAt(i).QuantumProbabilityCalc(quantum));
			}								
			return possiblePositions;
		}
				
	}
}