using System;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swcommands;
using SolidWorks.Interop.swconst;
using System.Diagnostics;
using System.Windows.Input;


namespace AVConnectorProject
{

   public class ViewModel
    {
        
        IModelDoc2 SWmodel;  // документ детали
        SldWorks SwApp1; // объект приложения Solidworks

        public double RodRadius { get; set; }
        public double RodLong { get; set; }
        public double CapRadius { get; set; }
        public double СapDeep { get; set; }



        

        /*



        // Команда завершения Solidworks
        private ICommand _exitsolid;
        public ICommand Exit
        {
            get
            {
                return _exitsolid ?? (_exitsolid = new RelayCommand(() =>
                {
                    SwApp1.ExitApp();
                    SwApp1 = null;
                }
                ));
            }
        }
        // Команда открытия нового документа
        private ICommand _newdoc3dmodel;
        public ICommand NewDoc3dModel
        {
            get
            {
                return _newdoc3dmodel ?? (_newdoc3dmodel = new RelayCommand(() =>
                {
                    SwApp1.NewPart(); //документ
                                      //передать интфейс с деталью в ImodelDoc
                    SWmodel = SwApp1.IActiveDoc2;
                }
                ));
            }
        }


        // Команда проверки введенных данных и выдавливания детали
        private ICommand _createmodel;

        public ICommand CreateModel
        {
            get
            {
                return _createmodel ?? (_createmodel = new RelayCommand(() =>
                {
                    
                    
                    // проверка введенных значений
                    if ((RodRadius < 0) || (RodRadius > 10000))
                    {
                        MessageBox.Show("Значения не могут быть меньше 0 и больше 10000.", "Ошибка",
               MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    if ((RodLong < 0) || (RodLong > 10000))
                    {
                        MessageBox.Show("Значения не могут быть меньше 0 и больше 10000.", "Ошибка",
               MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    if ((CapRadius < 0) || (CapRadius > 10000))
                    {
                        MessageBox.Show("Значения не могут быть меньше 0 и больше 10000.", "Ошибка",
               MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    if ((СapDeep < 0) || (СapDeep > 10000))
                    {
                        MessageBox.Show("Значения не могут быть меньше 0 и больше 10000.", "Ошибка",
               MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    
                    // Создание эскизов и выдавливание детали

                    bool boolstatus = false;
                    SWmodel.Extension.SelectByID2("Спереди", "PLANE", 0, 0, 0, false, 0, null, 0);
                    SWmodel.SketchManager.InsertSketch(true);
                    SWmodel.ClearSelection2(true);
                    SWmodel.SketchManager.CreatePolygon(0, 0, 0, 0, -0.06, 0, 6, true);
                    SWmodel.ShowNamedView2("*Триметрия", 8);
                    SWmodel.ClearSelection2(true);
                    SWmodel.Extension.SelectByID2("Эскиз1", "SKETCH", 0, 0, 0, false, 4, null, 0);

                    SWmodel.FeatureManager.FeatureExtrusion2(true, false, false, 0, 0, 0.07, 0.01, false, false, false,
                        false, 1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false, true, true, (true), 0, 0, false);
                    SWmodel.SelectionManager.EnableContourSelection = false;

                    //       boolstatus = SWmodel.Extension.SelectByID2("Спереди", "PLANE", 0, 0, 0, false, 0, null, 0);
                    //      boolstatus = SWmodel.Extension.SelectByID2("Спереди", "PLANE", 0, 0, 0, false, 0, null, 0);
                    //     boolstatus = SWmodel.Extension.SelectByID2("Неизвестный", "BROWSERITEM", 0, 0, 0, false, 0, null, 0);

                    SWmodel.Extension.SelectByID2("Спереди", "PLANE", 0, 0, 0, false, 0, null, 0);
                    SWmodel.SketchManager.InsertSketch(true);
                    SWmodel.ClearSelection2(true);
                    SWmodel.SketchManager.CreateCircle(0, 0, 0, -0.001067, -0.01027, 0);
                    //   SWmodel.SketchManager.CreateCircle(0, 0, 0, CapRadius / 1000, 0, 0);
                    //        SWmodel.ClearSelection2(true);
                    //    SWmodel.Extension.SelectByID2("Arc1", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
                    //    SWmodel.ClearSelection2(true);
                    SWmodel.Extension.SelectByID2("Arc1", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
                    SWmodel.FeatureManager.FeatureCut3(true, false, true, 0, 0, 0.07, 0.07, false, false,
                        false, false, 1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false, false,
                        true, true, true, true, false, 0, 0, false);
                    SWmodel.ClearSelection2(true);
                    SWmodel.SketchManager.CreateCircle(0, 0, 0, -0.025609, -0.045216, 0);

                    SWmodel.ClearSelection2(true);
                    SWmodel.Extension.SelectByID2("Arc1", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
                    SWmodel.FeatureManager.FeatureExtrusion2(true, false, true, 0, 0, 0.02, 0.07, false,
                        false, false, false, 1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false,
                        true, true, true, 0, 0, false);

                    SWmodel.Extension.SelectByID2("Спереди", "PLANE", 0, 0, 0, false, 0, null, 0);
                    SWmodel.Extension.SelectByID2("Спереди", "PLANE", 0, 0, 0, false, 0, null, 0);
                    SWmodel.ClearSelection2(true);

                    SWmodel.SketchManager.CreateCircle(0, 0, 0, 0.0008, -0.046816, 0);
                    SWmodel.SketchManager.CreateCircle(0, 0, 0, 0, -0.042815, 0);

                    SWmodel.ClearSelection2(true);
                    SWmodel.ClearSelection2(true);
                    SWmodel.Extension.SelectByID2("Arc2", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
                    SWmodel.FeatureManager.FeatureExtrusion2(true, false, true, 0, 0, 0.04, 0.02, false, false, false,
                        false, 1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false, true, true, true,
                        0, 0, false);
                    //     SWmodel.Extension.SelectByID2("Спереди", "PLANE", 0, 0, 0, false, 0, null, 0);
                    //      SWmodel.Extension.SelectByID2("Спереди", "PLANE", 0, 0, 0, false, 0, null, 0);
                    //      SWmodel.Extension.SelectByID2("Неизвестный", "BROWSERITEM", 0, 0, 0, false, 0, null, 0);
                    //      SWmodel.Extension.SelectByID2("Спереди", "PLANE", 0, 0, 0, false, 0, null, 0);
                    SWmodel.ClearSelection2(true);

                    SWmodel.SketchManager.CreateCircle(0, 0, 0, 0.001067, -0.009203, 0);

                    SWmodel.ClearSelection2(true);
                    boolstatus = SWmodel.Extension.SelectByID2("Arc1", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
                    SWmodel.FeatureManager.FeatureExtrusion2(true, false, true, 0, 0, 0.1, 0.04, false, false, false,
                        false, 1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false, true, true, true,
                        0, 0, false);

                    SWmodel.ClearSelection2(true);
                 //   boolstatus = SWmodel.Extension.SelectByID2("", "EDGE", 0.0053957910507165252, 0.0068470210082978156, -0.06989040670725899, false, 1, null, 0);
                    SWmodel.Extension.SelectByID2("", "FACE", 0, 0, -0.1, false, 1, null, 0);


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
                    radiiArray = radiis;
                    dist2Array = dists2;
                    conicRhosArray = coniRhos;
                    setBackArray = setBacks;
                    pointArray = points;
                    pointDist2Array = pointsDist2;
                    pointRhoArray = pointsRhos;

                    Feature myFeature = null;

                    SWmodel.FeatureManager.FeatureFillet3(195, 0.004, 0.01, 0, 0, 0, 0, radiiArray, dist2Array, conicRhosArray, setBackArray, pointArray, pointDist2Array, pointRhoArray);

                }
                ));
            }
        }








        */
    }
    
}