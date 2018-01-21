using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SVGImporter;
using HessModelEngine.Objects;
using System.Linq;
using System;
using System.Threading;

namespace HessModelEngine {
	public static class ThreadSafeRandom {
		[ThreadStatic] private static System.Random Local;

		public static System.Random ThisThreadsRandom {
			get { return Local ?? (Local = new System.Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId))); }
		}
	}	

	static class MyExtensions {
		public static void Shuffle<T>(this IList<T> list) {
			int n = list.Count;
			while (n > 1) {
				n--;
				int k = ThreadSafeRandom.ThisThreadsRandom.Next(n + 1);
				T value = list[k];
				list[k] = list[n];
				list[n] = value;
			}
		}
	}


	public partial class HessModel {
		private Color PaintColor;
		public List<Quantum> AllQuantums = new List<Quantum>();
		public List<ChemEObject> AllChemEObjects = new List<ChemEObject>();
		public string getQuantumName(int pos) {
			if (AllQuantums.Count > pos) 
				return AllQuantums[pos].Index.ToString() + " - " + AllQuantums[pos].Position.Name;
			else
				return "";		
		}

		public List<Quantum> AllQuantumsDebug {
			get {return AllQuantums;}
		}

		public Deionisier DI1 = new Deionisier();

		void GenerateQuantums(int Quantity, ChemEObject StartPosition) {
			for (int i = 1; i <= Quantity; i++) {
				Quantum newQuantum = new Quantum{Position = StartPosition};
				AllQuantums.Add(newQuantum);
				StartPosition.Quantums.Add(newQuantum);
			}
		}

		void HighlightQuanta() {
			for (int i = 0; i < AllChemEObjects.Count; i++) {
				
				if (AllChemEObjects[i] is Pipe ||
				    AllChemEObjects[i] is Hose ||
					AllChemEObjects[i] is Drain ||
					AllChemEObjects[i] is Deionisier ||
					AllChemEObjects[i] is HeatExchanger ||
					AllChemEObjects[i] is Co2Column ||
					AllChemEObjects[i] is Drain) {
					if (AllChemEObjects[i].Quantums.Count > 0)
						PaintColor = SimulationModel.highlightColor;
					else
						PaintColor = SimulationModel.defaultColor;	
					
					AllChemEObjects[i].AssociatedObject.GetComponent<SVGImage>().color  = PaintColor;
				}	

				if (AllChemEObjects[i] is Valve) {
					if ((AllChemEObjects[i] as Valve).ValveOn == true) {
						if (AllChemEObjects[i].Quantums.Count > 0)
							PaintColor = SimulationModel.highlightColor;
						else
							PaintColor = SimulationModel.defaultColor;	

						AllChemEObjects[i].AssociatedObject.GetComponent<SVGImage>().color  = PaintColor;
					}
				}

				
			}
		}

		public HessModel() {
			// Constructor
			// Names
			NameModel();
			AssembleModel();
			OrderModel();	
			GravityModel();
		}

		public void SimulationInitialise() {
			// Default states
			// V01.ValveOn = true;
			// V02.ValveOn = true;
			// V03.ValveOn = false;
			// V04.ValveOn = false;
			// V05.ValveOn = true;
			// V06.ValveOn = false;
			// V07.ValveOn = true;

			// V11.ValveOn = true;
			// V12.ValveOn = true;
			// V13.ValveOn = true;
		}
 
		public void Simulation() {
			for (int i = 0; i < AllChemEObjects.Count; i++) {
				AllChemEObjects[i].Quantums.Shuffle();
				for (int j = AllChemEObjects[i].Quantums.Count - 1; j>= 0; j--) {
					AllChemEObjects[i].Quantums[0].Move();
				}
			}

			// Quantum collector
			for (int i = AllQuantums.Count() - 1; i >= 0; i--) {
				if (AllQuantums[i].Position is Drain)
					AllQuantums[i] = null;
			}
			AllQuantums.RemoveAll(item => item == null);

			// AllQuantums.Shuffle();
			// for (int i = AllQuantums.Count - 1; i >= 0; i--) {
			// 	AllQuantums[i].Move();
			// 	if (AllQuantums[i].Position is Drain) {					
			// 		AllQuantums[i] = null;
			// 	}
			// }
			// AllQuantums.RemoveAll(item => item == null);

			// Quanta generator
			if (ProcessWater.Quantums.Count < ProcessWater.Volume*2)
				GenerateQuantums(6, ProcessWater);
				
			HighlightQuanta();
		}
		
	}
}
