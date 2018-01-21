/*
    Defines names for objcts in memory.
	Names are important because they connect to
	the display objects
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SVGImporter;
using HessModelEngine.Objects;

namespace HessModelEngine {
	public partial class HessModel {
        public void NameModel() {
			int i = 0;
			foreach (Pipe pipe in Pipes) {
				Pipes[i] = new Pipe();
				Pipes[i].Name = "Pipe" + i.ToString();
				i++;
			}

			i = 0;
			foreach (Hose hose in Hoses) {
				Hoses[i] = new Hose();
				Hoses[i].Name = "Hose" + i.ToString();
				i++;
			}

			i = 0;
			foreach (Drain drain in Drains) {
				Drains[i] = new Drain();
				Drains[i].Name = "Drain" + i.ToString();
				i++;
			}
			
			i = 0;
			foreach (Drain vent in Vents) {
				Vents[i] = new Drain();
				Vents[i].Name = "Vent" + i.ToString();
				i++;
			}

			ProcessWater.Name = "ProcessWater";
			V01.Name = "V01";
			V02.Name = "V02";
			V03.Name = "V03";
			V04.Name = "V04";
			V05.Name = "V05";
			V06.Name = "V06";
			V07.Name = "V07";

			V11.Name = "V11";
			V12.Name = "V12";

			C1.Name = "C1";
			DI1.Name = "DI1";	

			RV1.Name = "RV1";   
			V56.Name = "V56";
			PHE2.Name = "PHE2";
			V57.Name = "V57";
			P3.Name = "P3";
			UT19_V01.Name = "UT19_V01";
			UT19_V02.Name = "UT19_V02";
			UT19_P1.Name = "UT19_P1";
			UT19_V03.Name = "UT19_V03";
			UT19_V04.Name = "UT19_V04";
			UT19_V05.Name = "UT19_V05";

			V14.Name = "V14";
			V23.Name = "V23";
			CV34.Name = "CV34";
			SV35.Name = "SV35";
			V13.Name = "V13";
			V21.Name = "V21";
        }
    }
}