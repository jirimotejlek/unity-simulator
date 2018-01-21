/*
    Connects memory objects together to create
	a path for quantas
*/
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using SVGImporter;
using HessModelEngine.Objects;

namespace HessModelEngine {
	public partial class HessModel {
		public void AssembleModel() {
			// Connections
			ProcessWater.AssignConnection(Pipes[1], ProcessWater.Outlet, Pipes[1].Inlet);

			Pipes[1].AssignConnection(V01, Pipes[1].Outlet, V01.Inlet);
			V01.AssignConnection(Pipes[2], V01.Outlet, Pipes[2].Inlet);

			Pipes[2].AssignConnection(Pipes[3], Pipes[2].Outlet, Pipes[3].Inlet);
			Pipes[3].AssignConnection(Pipes[67], Pipes[3].Outlet, Pipes[67].Inlet);
            
            Pipes[67].AssignConnection(Pipes[4], Pipes[67].Outlet, Pipes[4].Inlet);
            Pipes[67].AssignConnection(Pipes[5], Pipes[67].Outlet, Pipes[5].Inlet);
            Pipes[67].AssignConnection(Pipes[66], Pipes[67].Outlet, Pipes[66].Inlet); // To the heater

			Pipes[3].AssignConnection(V02, Pipes[3].Outlet, V02.Inlet);
			V02.AssignConnection(Hoses[1], V02.Outlet, Hoses[1].Inlet);
			Hoses[1].AssignConnection(Drains[1], Hoses[1].Outlet, Drains[1].Inlet);

			Pipes[4].AssignConnection(V03, Pipes[4].Outlet, V03.Inlet);
			V03.AssignConnection(Hoses[2], V03.Outlet, Hoses[2].Inlet);
			Hoses[2].AssignConnection(Drains[2], Hoses[2].Outlet, Drains[2].Inlet);

			Pipes[5].AssignConnection(V04, Pipes[5].Outlet, V04.Inlet);
			V04.AssignConnection(Hoses[3], V04.Outlet, Hoses[3].Inlet);
			Hoses[3].AssignConnection(Drains[3], Hoses[3].Outlet, Drains[3].Inlet);

			Pipes[2].AssignConnection(Pipes[6], Pipes[2].Outlet, Pipes[6].Inlet);
			Pipes[6].AssignConnection(Pipes[7], Pipes[6].Outlet, Pipes[7].Inlet);
			Pipes[7].AssignConnection(V05, Pipes[7].Outlet, V05.Inlet);
			V05.AssignConnection(Pipes[8], V05.Outlet, Pipes[8].Inlet);
			Pipes[8].AssignConnection(DI1, Pipes[8].Outlet, DI1.Inlet);
			DI1.AssignConnection(Pipes[9], DI1.Outlet, Pipes[9].Inlet);
			Pipes[9].AssignConnection(V11, Pipes[9].Outlet, V11.Inlet);
			V11.AssignConnection(Pipes[12], V11.Outlet, Pipes[12].Inlet);
			Pipes[12].AssignConnection(Pipes[14], Pipes[12].Outlet, Pipes[14].Inlet);

			Pipes[6].AssignConnection(Pipes[10], Pipes[6].Outlet, Pipes[10].Inlet);
			Pipes[10].AssignConnection(V06, Pipes[10].Outlet, V06.Inlet);
			V06.AssignConnection(Pipes[11], V06.Outlet, Pipes[11].Inlet);
			Pipes[11].AssignConnection(Pipes[13], Pipes[11].Outlet, Pipes[13].Inlet);

			Pipes[13].AssignConnection(Pipes[14], Pipes[13].Outlet, Pipes[14].Inlet);

			Pipes[14].AssignConnection(Pipes[15], Pipes[14].Outlet, Pipes[15].Inlet);
			Pipes[15].AssignConnection(V12, Pipes[15].Outlet, V12.Inlet);
			V12.AssignConnection(Hoses[4], V12.Outlet, Hoses[4].Inlet);
			Hoses[4].AssignConnection(Drains[4], Hoses[4].Outlet, Drains[4].Inlet);

            // To the heater and CO2 column
            Pipes[66].AssignConnection(Pipes[65], Pipes[66].Outlet, Pipes[65].Inlet);
            Pipes[65].AssignConnection(Pipes[55], Pipes[65].Outlet, Pipes[55].Inlet);
            Pipes[55].AssignConnection(Pipes[52], Pipes[55].Outlet, Pipes[52].Inlet);

            // To the CO2 column
            Pipes[52].AssignConnection(V07, Pipes[52].Outlet, V07.Inlet);
            V07.AssignConnection(Pipes[53], V07.Outlet, Pipes[53].Inlet);
            Pipes[53].AssignConnection(Pipes[54], Pipes[53].Outlet, Pipes[54].Inlet);
			Pipes[54].AssignConnection(Pipes[171], Pipes[54].Outlet, Pipes[171].Inlet);
            Pipes[171].AssignConnection(C1, Pipes[171].Outlet, C1.Inlet);
			// From the reactor to the CO2 column
			RV1.AssignConnection(Hoses[5], RV1.GasOutlet, Hoses[5].Inlet);
			Hoses[5].AssignConnection(Pipes[29], Hoses[5].Outlet, Pipes[29].Inlet);
			Pipes[29].AssignConnection(V56, Pipes[29].Outlet, V56.Inlet);
			V56.AssignConnection(Pipes[28], V56.Outlet, Pipes[28].Inlet);
			Pipes[28].AssignConnection(Pipes[26], Pipes[28].Outlet, Pipes[26].Inlet);
			Pipes[26].AssignConnection(Pipes[25], Pipes[26].Outlet, Pipes[25].Inlet);
			Pipes[25].AssignConnection(PHE2, Pipes[25].Outlet, PHE2.Inlet);
			PHE2.AssignConnection(Pipes[20], PHE2.Outlet, Pipes[20].Inlet);
			Pipes[20].AssignConnection(Pipes[21], Pipes[20].Outlet, Pipes[21].Inlet);
			Pipes[21].AssignConnection(V57, Pipes[21].Outlet, V57.Inlet);
			V57.AssignConnection(Pipes[61], V57.Outlet, Pipes[61].Inlet);
			Pipes[61].AssignConnection(P3, Pipes[61].Outlet, P3.Inlet);
			P3.AssignConnection(Pipes[62], P3.Outlet, Pipes[62].Outlet);
			Pipes[62].AssignConnection(Pipes[63], Pipes[62].Outlet, Pipes[63].Inlet);
			Pipes[63].AssignConnection(Pipes[64], Pipes[63].Outlet, Pipes[64].Inlet);
			Pipes[64].AssignConnection(C1, Pipes[64].Outlet, C1.GasInlet);

			// CO2 Column - Internal circulation
			C1.AssignConnection(Pipes[68], C1.Outlet, Pipes[68].Inlet);
			Pipes[68].AssignConnection(Pipes[172], Pipes[68].Outlet, Pipes[172].Inlet);
			Pipes[172].AssignConnection(UT19_V01, Pipes[172].Outlet, UT19_V01.Inlet);
			Pipes[172].AssignConnection(Pipes[69], Pipes[172].Inlet, Pipes[69].Inlet); //Weird! Because of the flow
			UT19_V01.AssignConnection(Pipes[68], UT19_V01.Outlet, Pipes[68].Inlet);
			Pipes[68].AssignConnection(Pipes[69], Pipes[68].Outlet, Pipes[69].Inlet);
			Pipes[69].AssignConnection(UT19_V02, Pipes[69].Outlet, UT19_V02.Inlet);
			UT19_V02.AssignConnection(Pipes[70], UT19_V02.Outlet, Pipes[70].Inlet);
			Pipes[70].AssignConnection(UT19_P1, Pipes[70].Outlet, UT19_P1.Inlet);
			UT19_P1.AssignConnection(Pipes[71], UT19_P1.Outlet, Pipes[71].Inlet);
			Pipes[71].AssignConnection(Pipes[72], Pipes[71].Outlet, Pipes[72].Inlet);
			Pipes[72].AssignConnection(UT19_V04, Pipes[72].Outlet, UT19_V04.Inlet);
			UT19_V04.AssignConnection(Pipes[75], UT19_V04.Outlet, Pipes[75].Inlet);
			Pipes[75].AssignConnection(Pipes[76], Pipes[75].Outlet, Pipes[76].Inlet);
			Pipes[75].AssignConnection(Pipes[164], Pipes[75].Outlet, Pipes[164].Inlet);  // To the sample point
			Pipes[164].AssignConnection(Pipes[165], Pipes[164].Outlet, Pipes[165].Inlet); // To the sample point
			Pipes[165].AssignConnection(UT19_V05, Pipes[165].Outlet, UT19_V05.Inlet);   // To the sample point
			UT19_V05.AssignConnection(Drains[24], UT19_V05.Outlet, Drains[24].Inlet);   // To the sample point
			Pipes[76].AssignConnection(C1, Pipes[76].Outlet, C1.Inlet2);

			Pipes[72].AssignConnection(Pipes[74], Pipes[72].Outlet, Pipes[74].Inlet);
			Pipes[74].AssignConnection(UT19_V03, Pipes[74].Outlet, UT19_V03.Inlet);
			UT19_V03.AssignConnection(Pipes[73], UT19_V03.Outlet, Pipes[73].Inlet);
			Pipes[73].AssignConnection(C1, Pipes[73].Outlet, C1.Inlet);

			C1.AssignConnection(Pipes[77], C1.GasOutlet, Pipes[77].Inlet);			
			Pipes[77].AssignConnection(Pipes[78], Pipes[77].Outlet, Pipes[78].Inlet);
			Pipes[78].AssignConnection(Hoses[9], Pipes[78].Outlet, Hoses[9].Inlet);
			Hoses[9].AssignConnection(Vents[2], Hoses[9].Outlet, Vents[2].Inlet);	// Exhaust

			// Water source to the reactor
			Pipes[14].AssignConnection(Pipes[163], Pipes[14].Outlet, Pipes[163].Inlet);
			Pipes[163].AssignConnection(Pipes[16], Pipes[163].Outlet, Pipes[16].Inlet);
			Pipes[16].AssignConnection(V14, Pipes[16].Outlet, V14.Inlet);
			V14.AssignConnection(Pipes[23], V14.Outlet, Pipes[23].Inlet);
			Pipes[23].AssignConnection(V23, Pipes[23].Outlet, V23.Inlet);
			V23.AssignConnection(Pipes[133], V23.Outlet, Pipes[133].Inlet);
			Pipes[133].AssignConnection(CV34, Pipes[133].Outlet, CV34.Inlet);
			CV34.AssignConnection(SV35, CV34.Outlet, SV35.Inlet);
			SV35.AssignConnection(Pipes[27], SV35.Outlet, Pipes[27].Inlet);
			Pipes[27].AssignConnection(Hoses[6], Pipes[27].Outlet, Hoses[6].Inlet);
			Hoses[6].AssignConnection(RV1, Hoses[6].Outlet, RV1.Inlet);

			// Diversion of water source to the reactor through the heat exchanger
			Pipes[16].AssignConnection(Pipes[17], Pipes[16].Outlet, Pipes[17].Inlet);
			Pipes[17].AssignConnection(V13, Pipes[17].Outlet, V13.Inlet);
			V13.AssignConnection(Pipes[18], V13.Outlet, Pipes[18].Inlet);
			Pipes[18].AssignConnection(Pipes[19], Pipes[18].Outlet, Pipes[19].Inlet);
			Pipes[19].AssignConnection(PHE2, Pipes[19].Outlet, PHE2.Inlet2);
			PHE2.AssignConnection(Pipes[22], PHE2.Outlet2, Pipes[22].Inlet);
			Pipes[22].AssignConnection(V21, Pipes[22].Outlet, V21.Inlet);
			V21.AssignConnection(Pipes[24], V21.Outlet, Pipes[24].Inlet);
			Pipes[24].AssignConnection(Pipes[23], Pipes[24].Outlet, Pipes[23].Inlet);

			// Feeder

		}
    }
}