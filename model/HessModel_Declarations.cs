/*
    Declares memory objects
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SVGImporter;
using HessModelEngine.Objects;

namespace HessModelEngine {
	public partial class HessModel {
		public Source ProcessWater = new Source();

		public Pipe[] Pipes = new Pipe[180];
		public Hose[] Hoses = new Hose[14];
		public Drain[] Drains = new Drain[25];
		public Drain[] Vents = new Drain[20];

		public Valve V01 = new Valve();
		public Valve V02 = new Valve();
		public Valve V03 = new Valve();
		public Valve V04 = new Valve();
		public Valve V05 = new Valve();
		public Valve V06 = new Valve();
		public Valve V07 = new Valve();

		public Valve V11 = new Valve();
		public Valve V12 = new Valve();
		public Co2Column C1 = new Co2Column();   

        public Reactor RV1 = new Reactor(); 

        public Valve V56 = new Valve();
        public HeatExchanger PHE2 = new HeatExchanger();
		public Valve V57 = new Valve();
		public Pump P3 = new Pump();
		public Valve UT19_V01 = new Valve();
		public Valve UT19_V02 = new Valve();
		public Pump UT19_P1 = new Pump();
		public Valve UT19_V03 = new Valve();
		public Valve UT19_V04 = new Valve();
		public Valve UT19_V05 = new Valve();

		public Valve V14 = new Valve();
		public Valve V23 = new Valve();
		public Valve CV34 = new Valve();
		public Valve SV35 = new Valve();
		public Valve V13 = new Valve();
		public Valve V21 = new Valve();

		public Feeder CV1 = new Feeder();
    }
}