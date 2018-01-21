using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HessModelEngine.Objects {
	public class Feeder:ChemEObject {
		public CHPoint SolidOutlet {get {return CHPoint.SolidOutlet;}}
		
		private Dictionary<ChemEObject, float> possiblePositions = new Dictionary<ChemEObject, float>();
		private int volume = 3;

		private float augerSpeed;

		public float Auger {
			get{return augerSpeed;}
			set{augerSpeed = value;}
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