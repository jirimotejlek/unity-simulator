using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HessModelEngine.Objects {
	public class HeatExchanger:ChemEObject {
		CHPoint? instrumentNextPositionPoint;
		CHPoint? quantumPreviousPositionPoint;

		public CHPoint Inlet {get {return CHPoint.Inlet;}}  
		public CHPoint Outlet {get {return CHPoint.Outlet;}}

		public CHPoint Inlet2 {get {return CHPoint.Inlet2;}}  
		public CHPoint Outlet2 {get {return CHPoint.Outlet2;}}

		private int volume = 3;

		private Dictionary<ChemEObject, float> possiblePositions = new Dictionary<ChemEObject, float>();

		private float exchangeCoeficient;

		public float ExchangeCoeficient {
			get{return exchangeCoeficient;}
			set{exchangeCoeficient = value;}
		}

		public override void OnAssociatedObject() {
		}

		public override float QuantumProbabilityCalc(Quantum quantum) {
			if (Quantums.Count < volume*2)
				return 1f;
			else
				return 0f;
		}		

		public override Dictionary<ChemEObject, float> CalculatePossiblePositions(Quantum quantum) {
			possiblePositions.Clear();
			quantumPreviousPositionPoint = quantum.EntryPoint;
			for (int i = 0; i < NextPosition.Count; i++) {
				instrumentNextPositionPoint = PointOfExit2(NextPosition.Keys.ElementAt(i));
				Debug.Log(quantum.EntryPoint.ToString());
				if ((quantumPreviousPositionPoint == Inlet2 && instrumentNextPositionPoint == Outlet2)
				     || (quantumPreviousPositionPoint == Outlet2 && instrumentNextPositionPoint == Inlet2))
					possiblePositions.Add(NextPosition.Keys.ElementAt(i), NextPosition.Keys.ElementAt(i).QuantumProbabilityCalc(quantum)); 

				if ((quantumPreviousPositionPoint == Inlet && instrumentNextPositionPoint == Outlet)
					 || (quantumPreviousPositionPoint == Outlet && instrumentNextPositionPoint == Inlet))
					possiblePositions.Add(NextPosition.Keys.ElementAt(i), NextPosition.Keys.ElementAt(i).QuantumProbabilityCalc(quantum));

				if (quantumPreviousPositionPoint == instrumentNextPositionPoint)
					possiblePositions.Add(NextPosition.Keys.ElementAt(i), NextPosition.Keys.ElementAt(i).QuantumProbabilityCalc(quantum)); 
					
			}

			for (int i = 0; i < PreviousPosition.Count; i++) {
				instrumentNextPositionPoint = PointOfEntry2(PreviousPosition.Keys.ElementAt(i));
				if ((quantumPreviousPositionPoint == Inlet2 && instrumentNextPositionPoint == Outlet2)
				     || (quantumPreviousPositionPoint == Outlet2 && instrumentNextPositionPoint == Inlet2))
					possiblePositions.Add(PreviousPosition.Keys.ElementAt(i), PreviousPosition.Keys.ElementAt(i).QuantumProbabilityCalc(quantum)); 

				if ((quantumPreviousPositionPoint == Inlet && instrumentNextPositionPoint == Outlet)
					 || (quantumPreviousPositionPoint == Outlet && instrumentNextPositionPoint == Inlet))
					possiblePositions.Add(PreviousPosition.Keys.ElementAt(i), PreviousPosition.Keys.ElementAt(i).QuantumProbabilityCalc(quantum));

				if (quantumPreviousPositionPoint == instrumentNextPositionPoint)	
					possiblePositions.Add(PreviousPosition.Keys.ElementAt(i), PreviousPosition.Keys.ElementAt(i).QuantumProbabilityCalc(quantum));				
			}			
			return possiblePositions;
		}			
	}
}