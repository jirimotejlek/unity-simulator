using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HessModelEngine.Objects {
	public class Co2Column:ChemEObject {
		public CHPoint Inlet {get {return CHPoint.Inlet;}}  
		public CHPoint Outlet {get {return CHPoint.Outlet;}}

		public CHPoint Inlet2 {get {return CHPoint.Inlet2;}}  
		public CHPoint GasInlet {get {return CHPoint.GasInlet;}}  
		public CHPoint GasOutlet {get {return CHPoint.GasOutlet;}}

		private int volumeWater = 3;
		private int volumeAir = 3;

		private Dictionary<ChemEObject, float> possiblePositions = new Dictionary<ChemEObject, float>();
		public override float QuantumProbabilityCalc(Quantum quantum) {
			// Can the quantum move in?
			// If calculating water volume (TODO)
			if (quantum.Index != 0) {
				if (Quantums.Count < volumeWater*2)
					return 1f;
				else
					return 0f;
			} else
			// If calculating air volume (TODO)
			if (quantum.Index == 0) {
				if (Quantums.Count < volumeAir*2)
					return 1f;
				else
					return 0f;
			} else
				return 0f;
		}	

		public override bool QuantumSpace(Quantum quantum) {
			// Should the quantum move out?
			return (this.Quantums.Count > this.volumeWater*SimulationModel.VolumeMultiplier);
		}

		public override void OnAssociatedObject() {
		}

		public override Dictionary<ChemEObject, float> CalculatePossiblePositions(Quantum quantum) {
			possiblePositions.Clear();
			for (int i = 0; i < NextPosition.Count; i++) {
				//Debug.Log(PointOfExit(i).ToString());
				if (PointOfExit2(NextPosition.Keys.ElementAt(i)) != GasInlet 
				 && PointOfExit2(NextPosition.Keys.ElementAt(i)) != GasOutlet
				 && PointOfEntry2(PreviousPosition.Keys.ElementAt(i)) != Inlet2)
					possiblePositions.Add(NextPosition.Keys.ElementAt(i), NextPosition.Keys.ElementAt(i).QuantumProbabilityCalc(quantum));
			}				
			for (int i = 0; i < PreviousPosition.Count; i++) {
				//Debug.Log(PointOfEntry(i).ToString());
				if (PointOfEntry2(PreviousPosition.Keys.ElementAt(i)) != GasInlet 
				 && PointOfEntry2(PreviousPosition.Keys.ElementAt(i)) != GasOutlet
				 && PointOfEntry2(PreviousPosition.Keys.ElementAt(i)) != Inlet2)
					possiblePositions.Add(PreviousPosition.Keys.ElementAt(i), PreviousPosition.Keys.ElementAt(i).QuantumProbabilityCalc(quantum));
			}
								
			return possiblePositions;
		}
	
	}
}