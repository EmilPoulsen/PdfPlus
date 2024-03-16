﻿using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;
using Rhino.Geometry;
using System;
using System.Collections.Generic;

using Sd = System.Drawing;

namespace PdfPlus.Components.Write.Pages
{
    public class GH_Pdf_Page_SetBlocks : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the GH_Pdf_Page_AddBlocks class.
        /// </summary>
        public GH_Pdf_Page_SetBlocks()
          : base("Set Blocks", "Set Blk",
              "Render a sequence of Blocks to PDF Pages.",
              Constants.ShortName, Constants.MigraDoc)
        {
        }

        /// <summary>
        /// Set Exposure level for the component.
        /// </summary>
        public override GH_Exposure Exposure
        {
            get { return GH_Exposure.tertiary; }
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter(Constants.Page.Name, Constants.Page.NickName, Constants.Page.Input, GH_ParamAccess.item);
            pManager.AddGenericParameter("Blocks", "B", "Blocks to add to the document", GH_ParamAccess.list);
            pManager[1].Optional = true;
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter(Constants.Page.Name, Constants.Page.NickName, Constants.Page.Output, GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            Page page = null;
            if (!DA.GetData(0, ref page)) return;
            page = new Page(page);

            List<IGH_Goo> geometry = new List<IGH_Goo>();
            if (!DA.GetDataList(1, geometry)) return;

            foreach (IGH_Goo goos in geometry) page.AddBlock(goos);

            //this.PrevPageShapes(page);
            DA.SetData(0, page);
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
            get { return new Guid("d9c71778-1a53-443f-a3d3-cdc72ec5c2b1"); }
        }
    }
}