using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using System.Drawing;

namespace UnitConverter
{
    public class RGBtoColor : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the RGBtoColor class.
        /// </summary>
        public RGBtoColor()
          : base("RGBtoColor", "RGBtoClr",
              "Converts RGB values into a Color",
              "Unit Converter", "Display")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddIntegerParameter("R", "R", "Provide the value for Red(0-255)",GH_ParamAccess.item, 255);
            pManager.AddIntegerParameter("G", "G", "Provide the value for Green(0-255)",GH_ParamAccess.item, 255);
            pManager.AddIntegerParameter("B", "B", "Provide the value for Blue(0-255)",GH_ParamAccess.item, 255);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddColourParameter("Color", "C", "Provides color form the RGB Value", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            int r = 0, g = 0, b = 0;
            if (!DA.GetData(0, ref r)) return;
            if (!DA.GetData(0, ref g)) return;
            if (!DA.GetData(0, ref b)) return;

            //Clamp values to the valid range of 0-255
            r = Clamp255(r);
            r = Clamp255(g);
            r = Clamp255(b);
            Color color = Color.FromArgb(r, g, b);
            DA.SetData(0, color);
        }

        private int Clamp255(int value)
        {
            if (value < 0) return 0;
            if (value > 255) return 255;
            return value;
        }
        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("0A409AD7-E150-460D-AECB-3D8F17097392"); }
        }
    }
}