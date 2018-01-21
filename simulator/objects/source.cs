using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HessModelEngine.Objects {
	public class Source:ChemEObject {
		public CHPoint Outlet {get {return CHPoint.Outlet;}}

		public int Volume = 3;		
		private Dictionary<ChemEObject, float> possiblePositions = new Dictionary<ChemEObject, float>();

		public override void OnAssociatedObject() {
		}
		
		// The Generator?
		public override float QuantumProbabilityCalc(Quantum quantum) {
			return 0f; // Acts as a stop plug
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