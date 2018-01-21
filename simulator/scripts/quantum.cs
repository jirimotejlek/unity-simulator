using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SVGImporter;
using System.Linq;

namespace HessModelEngine.Objects {
	public class Quantum {
		private Dictionary<ChemEObject, float> possiblePositions;
		private Dictionary<ChemEObject, float> possibleGravityPositions;
		private int index = 0;
		private float quantumSize = 100f; // Number of moles in one quantum
		private float temperature = 20f;
		private float speed = 1f;
		private float pressure = 1f;
		private float mass_Na = 0;
		private float mass_Ca = 0;
		private float mass_Cl = 0;
		private float mass_H2O = 0;
		private ChemEObject position;
		private ChemEObject previousPosition;
		private ChemEObject temporaryPosition;
		private CHPoint? entryPoint;

		public float Temperature {get; set;}
		public float Speed {get; set;}
		public float Pressure {get; set;}

		public float Mass_Na {get; set;}
		public float Mass_Ca {get; set;}
		public float Mass_Cl {get; set;}
		public float Mass_H20 {get; set;}
		public int Index {get{return index;} set{index = value;}}
		public CHPoint? EntryPoint {get {return entryPoint;} private set {entryPoint = value;}}
		// public CHPoint? EntryPoint {
		// 	get {
		// 		CHPoint? retValue = null;
		// 		for (int i = 0; i < PreviousPosition.NextPosition.Count; i++) {
		// 			if (PreviousPosition.NextPosition.Keys.ElementAt(i).Name == position.Name) {
		// 				retValue = PreviousPosition.NextPosition.Values.ElementAt(i);
		// 			}		
		// 		}
		// 		return retValue;
		// 	}
		// }

		public ChemEObject Position {
			get {return position;}
			set {position = value;}
		}	
		public ChemEObject PreviousPosition {
			get {return previousPosition;}
			set {previousPosition = value;}
		}

		public Quantum() {
			index = SimulationModel.QuantumIndex;
			SimulationModel.QuantumIndex++;
		}

		public void Move() {
			float sumProbabilities = 0;
			float sumGravityProbabilities = 0;
			float cumulativeLocMoveProbability = 0;
			float currentValue = 0;
			float randomNum = Random.Range(0f, 1f);
			
			possiblePositions = Position.CalculatePossiblePositions(this);
			possibleGravityPositions = Position.CalculatePossibleGravityPositions(this);

			for (int i = 0; i < possiblePositions.Count; i++) {
				sumProbabilities = sumProbabilities + possiblePositions.Values.ElementAt(i);
			}	

			cumulativeLocMoveProbability = 0;
			if (possibleGravityPositions.Count > 0) {
				for (int i = 0; i < possibleGravityPositions.Count; i++) {
					sumGravityProbabilities = sumGravityProbabilities + possibleGravityPositions.Values.ElementAt(i);
				}
				
				for (int i = 0; i < possibleGravityPositions.Count; i++) {
					currentValue = possibleGravityPositions.Values.ElementAt(i) / sumGravityProbabilities;
					cumulativeLocMoveProbability = cumulativeLocMoveProbability + currentValue;
				}
			}
			
			cumulativeLocMoveProbability = 0;
			if (Position.QuantumSpace(this)) { // Initiate movement if count > volume
				for (int i = 0; i < possiblePositions.Count; i++) {
					currentValue =  possiblePositions.Values.ElementAt(i) / sumProbabilities;
					cumulativeLocMoveProbability = cumulativeLocMoveProbability + currentValue;
					if (randomNum > cumulativeLocMoveProbability - currentValue &&
						randomNum < cumulativeLocMoveProbability) {
							Position.Quantums.RemoveAll(item => item.Equals(this));
							
							if (possiblePositions.Keys.ElementAt(i) is Drain) {
								Position = possiblePositions.Keys.ElementAt(i);
							}
							else {
								previousPosition = Position;
								Position = possiblePositions.Keys.ElementAt(i);

								// NOTE: Maybe there is a better solution, the problem is that
								//       we don't know from which direction the quanta is comming
								//       and PointOfExit and PointOfEntry are direction dependand
								//       maybe the solution is to combine them together in ChemEObject
								//       and call that function here (as well as eg in heatExchanger)
								entryPoint = null;
								entryPoint = position.PointOfExit2(previousPosition);
								if (entryPoint == null)
									entryPoint = position.PointOfEntry2(previousPosition);

								Position.Quantums.Add(this);
							}
						}
				}
			}
		}

		public float TotalMass {
			get {return mass_Ca + mass_Cl + mass_H2O + mass_H2O;}
		}
	}
}