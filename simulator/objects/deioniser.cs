using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HessModelEngine.Objects {
	public class Deionisier:ChemEObject {
		public CHPoint Inlet {get {return CHPoint.Inlet;}}  
		public CHPoint Outlet {get {return CHPoint.Outlet;}}
		
		private int volume = 3;
		
		private Dictionary<ChemEObject, float> possiblePositions = new Dictionary<ChemEObject, float>();

		public override float QuantumProbabilityCalc(Quantum quantum) {
			if (Quantums.Count < volume*2)
				return 1f;
			else
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