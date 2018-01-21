using HessModelEngine;
using UnityEngine;

namespace HessModelEngine.Objects {
	public enum CHPoint {Inlet, Outlet, Inlet2, Outlet2, Inlet3, Outlet3, SolidInlet, SolidOutlet, GasInlet, GasOutlet};
	public static class SimulationModel {
		public static int QuantumIndex = 0;
		public static int VolumeMultiplier = 1;
		public static HessModel hModel = new HessModel(); 
		public static Color defaultColor = new Color32(0xFF, 0xFF, 0xFF, 0xFF);   // White
		public static Color runningColor = new Color32(0xA6, 0xFF, 0x42, 0xFF);   // Greenish
		public static Color highlightColor = new Color32(0x42, 0xB8, 0xFF, 0xFF); // Bluish
		public static Color closedColor = new Color32(0xFF, 0x7A, 0x7A, 0xFF); // Redish
	}
}