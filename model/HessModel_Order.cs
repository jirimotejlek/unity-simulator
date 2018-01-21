/*
    Defines calculation order
*/
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using SVGImporter;
using HessModelEngine.Objects;

namespace HessModelEngine {  
	public partial class HessModel {
		public void AddAllChemEObject(ChemEObject value) {
			if (!AllChemEObjects.Any(item => item.Name == value.Name))
				AllChemEObjects.Add(value);
		}      

        public void OrderModel() {
            
            for (int i = 1; i < Drains.Count(); i++)
                AddAllChemEObject(Drains[i]);    

            AddAllChemEObject(ProcessWater);
            AddAllChemEObject(Pipes[1]);
            AddAllChemEObject(V01);
            AddAllChemEObject(Pipes[2]);
            AddAllChemEObject(Pipes[3]);
            AddAllChemEObject(Pipes[67]);
            AddAllChemEObject(V02);
            AddAllChemEObject(Hoses[1]);
            AddAllChemEObject(Pipes[4]);
            AddAllChemEObject(V03);
            AddAllChemEObject(Hoses[2]);
            AddAllChemEObject(Pipes[5]);
            AddAllChemEObject(V04);
            AddAllChemEObject(Hoses[3]);
            AddAllChemEObject(Pipes[6]);
            AddAllChemEObject(Pipes[7]);
            AddAllChemEObject(V05);
            AddAllChemEObject(Pipes[8]);
            AddAllChemEObject(DI1);
            AddAllChemEObject(Pipes[9]);
            AddAllChemEObject(V11);
            AddAllChemEObject(Pipes[12]);
            AddAllChemEObject(Pipes[10]);
            AddAllChemEObject(V06);
            AddAllChemEObject(Pipes[11]);
            AddAllChemEObject(Pipes[13]);
            AddAllChemEObject(Pipes[14]);
            AddAllChemEObject(Pipes[15]);
            AddAllChemEObject(V12);
            AddAllChemEObject(Hoses[4]);
            AddAllChemEObject(Pipes[66]);
            AddAllChemEObject(Pipes[65]);
            AddAllChemEObject(Pipes[55]);
            AddAllChemEObject(Pipes[52]);
            AddAllChemEObject(V07);
            AddAllChemEObject(Pipes[53]);
            AddAllChemEObject(Pipes[54]);
            AddAllChemEObject(Pipes[171]);
            AddAllChemEObject(RV1);
            AddAllChemEObject(Hoses[5]);
            AddAllChemEObject(Pipes[29]);
            AddAllChemEObject(V56);
            AddAllChemEObject(Pipes[28]);
            AddAllChemEObject(Pipes[26]);
            AddAllChemEObject(Pipes[25]);
            AddAllChemEObject(PHE2);
            AddAllChemEObject(Pipes[20]);
            AddAllChemEObject(Pipes[21]);
            AddAllChemEObject(V57);
            AddAllChemEObject(Pipes[61]);
            AddAllChemEObject(P3);
            AddAllChemEObject(Pipes[62]);
            AddAllChemEObject(Pipes[63]);
            AddAllChemEObject(Pipes[64]);
            AddAllChemEObject(C1);
            AddAllChemEObject(Pipes[172]);
            AddAllChemEObject(UT19_V01);
            AddAllChemEObject(Pipes[68]);
            AddAllChemEObject(Pipes[69]);
            AddAllChemEObject(UT19_V02);
            AddAllChemEObject(Pipes[70]);
            AddAllChemEObject(UT19_P1);
            AddAllChemEObject(Pipes[71]);
            AddAllChemEObject(Pipes[72]);
            AddAllChemEObject(UT19_V04);
            AddAllChemEObject(Pipes[75]);
            AddAllChemEObject(Pipes[164]);
            AddAllChemEObject(Pipes[165]);
            AddAllChemEObject(UT19_V05);
            AddAllChemEObject(Pipes[76]);
            AddAllChemEObject(Pipes[72]);
            AddAllChemEObject(Pipes[74]);
            AddAllChemEObject(UT19_V03);
            AddAllChemEObject(Pipes[73]);
            AddAllChemEObject(C1);
            AddAllChemEObject(Pipes[77]);
            AddAllChemEObject(Pipes[78]);
            AddAllChemEObject(Hoses[9]);
            AddAllChemEObject(Pipes[14]);
            AddAllChemEObject(Pipes[163]);
            AddAllChemEObject(Pipes[16]);
            AddAllChemEObject(V14);
            AddAllChemEObject(Pipes[23]);
            AddAllChemEObject(V23);
            AddAllChemEObject(Pipes[133]);
            AddAllChemEObject(CV34);
            AddAllChemEObject(SV35);
            AddAllChemEObject(Pipes[27]);
            AddAllChemEObject(Hoses[6]);
            AddAllChemEObject(Pipes[16]);
            AddAllChemEObject(Pipes[17]);
            AddAllChemEObject(V13);
            AddAllChemEObject(Pipes[18]);
            AddAllChemEObject(Pipes[19]);
            //AddAllChemEObject(PHE2);
            AddAllChemEObject(Pipes[22]);
            AddAllChemEObject(V21);
            AddAllChemEObject(Pipes[24]);
        }  
    }
}