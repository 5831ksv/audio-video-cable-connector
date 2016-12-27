using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AVConnectorProject;
using System.Diagnostics;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swcommands;
using SolidWorks.Interop.swconst;

namespace SolidworksApi
{
    class Fillet
    {

        IModelDoc2 SWmodel; // документ детали
        SldWorks SwApp1; // объект приложения Solidworks

        Array radiiArray = null;
        double[] radiis = new double[0];
        Array dist2Array = null;
        double[] dists2 = new double[0];
        Array conicRhosArray = null;
        double[] coniRhos = new double[0];
        Array setBackArray = null;
        double[] setBacks = new double[0];
        Array pointArray = null;
        double[] points = new double[0];
        Array pointDist2Array = null;
        double[] pointsDist2 = new double[0];
        Array pointRhoArray = null;
        double[] pointsRhos = new double[0];

        //сслылка на переменные-массивы???????

            radiiArray = radiis;
            dist2Array = dists2;
            conicRhosArray = coniRhos;
            setBackArray = setBacks;
            pointArray = points;
            pointDist2Array = pointsDist2;
            pointRhoArray = pointsRhos;

        SWmodel.FeatureManager.FeatureFillet3(195, 0.004, 0.01, 0, 0, 0, 0, radiiArray, dist2Array, conicRhosArray,
                setBackArray, pointArray, pointDist2Array, pointRhoArray);

    }
}
