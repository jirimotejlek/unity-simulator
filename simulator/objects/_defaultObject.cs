using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using SVGImporter;
using HessModelEngine;
using HessModelEngine.Objects;

namespace HessModelEngine.Objects {
	public abstract class ChemEObject {
		private string name;
		private float locMoveProbability; // Used to calculate junctions
		private int volume = 3*SimulationModel.VolumeMultiplier;
		private int gravityOrder = 1000; // Default gravity order for each instrument

		private float weight = 1f;
		private float maxPressure = 1000f;	
		private Dictionary<ChemEObject, float> possibleGravityPositions = new Dictionary<ChemEObject, float>();
		private Dictionary<ChemEObject, float> possiblePositionsTemp = new Dictionary<ChemEObject, float>();

		public float Weight {get; set;}
		private GameObject associatedObject = null;
		private Dictionary<ChemEObject, CHPoint> previousPosition = new Dictionary<ChemEObject, CHPoint>();
		private Dictionary<ChemEObject, CHPoint> nextPosition = new Dictionary<ChemEObject, CHPoint>();
		private List<Quantum> quantums = new List<Quantum>();

		public string Name {get {return name;} set{name = value;}}
		public Dictionary<ChemEObject, CHPoint> PreviousPosition {get {return previousPosition;} private set{previousPosition = value;}}
		public Dictionary<ChemEObject, CHPoint> NextPosition {get {return nextPosition;} private set{nextPosition = value;}}
		public List<Quantum> Quantums {get {return quantums;} set {quantums = value;}}
		
		public int GravityOrder {get {return gravityOrder;} set {gravityOrder = value;}}
		
		public CHPoint PointOfExit(int position) {
			return NextPosition.Keys.ElementAt(position).PreviousPosition.Values.ElementAt(0);
		}
		public CHPoint PointOfEntry(int position) {
			return PreviousPosition.Keys.ElementAt(position).NextPosition.Values.ElementAt(0);
		}

		public CHPoint? PointOfExit2(ChemEObject InspectNextPosition) {
			CHPoint? retValue = null;

			for (int d = 0; d < InspectNextPosition.previousPosition.Count; d++) {
				if (InspectNextPosition.previousPosition.Keys.ElementAt(d).name == this.name) {
					retValue = InspectNextPosition.PreviousPosition.Values.ElementAt(d);
				}
			}
						
			return retValue;
		}
		public CHPoint? PointOfEntry2(ChemEObject InspectPreviousPosition) {
			CHPoint? retValue = null;

			for (int d = 0; d < InspectPreviousPosition.nextPosition.Count; d++) {
				if (InspectPreviousPosition.nextPosition.Keys.ElementAt(d).name == this.name) {
					retValue = InspectPreviousPosition.nextPosition.Values.ElementAt(d);
				}
			}
				
			return retValue;
		}

		public GameObject AssociatedObject {
			get {return associatedObject;}
			set {
				associatedObject = value;
				OnAssociatedObject();
			}
		}

		public abstract void OnAssociatedObject();

		public virtual bool QuantumSpace(Quantum quantum) {
			// Before movement is initiated each Quantum checks whether there is pressure
			// and it needs to move in the first place. Default virtual function is used
			// in for simple instruments, like pipes, but when it comes to instruments
			// that operate with different molecules such instrument handles the space
			// for each molecule type (for example CO2 column)
			return (this.Quantums.Count > this.volume*SimulationModel.VolumeMultiplier);
		}

		public void AssignConnection(ChemEObject destination, CHPoint output, CHPoint input) {
			nextPosition.Add(destination, input);
			destination.previousPosition.Add(this, output);
		}

		// Called by the Quanta in the connected (previous or next) instrument 
		public abstract float QuantumProbabilityCalc(Quantum quantum);

		// Called by the Quanta inside the instrument
		public abstract Dictionary<ChemEObject, float> CalculatePossiblePositions(Quantum quantum);

		public Dictionary<ChemEObject, float> CalculatePossibleGravityPositions(Quantum quantum) {
			possibleGravityPositions.Clear();
			possiblePositionsTemp = CalculatePossiblePositions(quantum);

			for (int i = 0; i < NextPosition.Count; i++) {
				if (nextPosition.Keys.ElementAt(i).gravityOrder > this.gravityOrder)
					possibleGravityPositions.Add(nextPosition.Keys.ElementAt(i), nextPosition.Keys.ElementAt(i).QuantumProbabilityCalc(quantum));
			}
			for (int i = 0; i < PreviousPosition.Count; i++) {
				if (previousPosition.Keys.ElementAt(i).gravityOrder > this.gravityOrder)
					possibleGravityPositions.Add(previousPosition.Keys.ElementAt(i), previousPosition.Keys.ElementAt(i).QuantumProbabilityCalc(quantum));
			}

			// PossibleGravityPositions is a subset of PossiblePositions
			for (int i = 0; i < possibleGravityPositions.Count; i++) {
				if (!possiblePositionsTemp.Any(item => item.Equals(possibleGravityPositions.Keys.ElementAt(i)))) {
					possibleGravityPositions.Remove(possibleGravityPositions.Keys.ElementAt(i));
				}
			}
			
			return possibleGravityPositions;
		}	
	}
}