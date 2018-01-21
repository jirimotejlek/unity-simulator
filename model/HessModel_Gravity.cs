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
		public void SetGravityChemEObject(ChemEObject objToChange, int gravityOrder) {
            var item = AllChemEObjects.Find(x => x.Name == objToChange.Name);
			if (item != null)
				item.GravityOrder = gravityOrder;
		}      

        public void GravityModel() {
            Pipes[68].GravityOrder = 1001;
            
            Pipes[69].GravityOrder = 1002;
            UT19_V02.GravityOrder = 1002;
            Pipes[70].GravityOrder = 1002;
            UT19_P1.GravityOrder = 1002;

            Pipes[171].GravityOrder = 1003;
            UT19_V01.GravityOrder = 1004;
            Drains[8].GravityOrder = 1005;         
        }  
    }
}