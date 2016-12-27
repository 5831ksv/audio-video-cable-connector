using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AVConnectorProject;
using System.Diagnostics;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swcommands;
using SolidWorks.Interop.swconst;

namespace AVConnectorProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        IModelDoc2 SWmodel; // документ детали
        SldWorks SwApp1; // объект приложения Solidworks




        private void buttonStartSolid_Click(object sender, EventArgs e)
        {

            Process[] processes = Process.GetProcessesByName("SLDWORKS 2016");
            foreach (Process process in processes)
            {
                process.CloseMainWindow(); // если процесс запущен, убивает процесс и запускает его снова
                process.Kill();
            }

            object processseSW = System.Activator.CreateInstance(System.Type.GetTypeFromProgID("SldWorks.Application"));

            SwApp1 = (SldWorks) processseSW;
            SwApp1.UserControl = true;
            SwApp1.Visible = true;

            MessageBox.Show("Solidworks запущен. Создайте новый документ детали.");




            SwApp1.NewPart(); //документ
            //передать интфейс с деталью в ImodelDoc
            SWmodel = SwApp1.IActiveDoc2;
        }

        private void buttonBuildDetail_Click(object sender, EventArgs e)
        {


            //что с буллстатусом делать


            bool boolstatus = false;

            
            //выбор плоскости/эскиза
            SWmodel.Extension.SelectByID2("Спереди", "PLANE", 0, 0, 0, false, 0, null, 0);

            //хз зачем но видлимо надо (работа со скетчем?)
            SWmodel.SketchManager.InsertSketch(true);


            //сброс выбора элемента/плоскости?????
            SWmodel.ClearSelection2(true);


            //чертеж полигона (шестиугольник)  (что центр, что радиус, что угол)
            SWmodel.SketchManager.CreatePolygon(0, 0, 0, 0, -0.06, 0, 6, true);



            //видимо выбор вида. нужен ли он вообще??????
            SWmodel.ShowNamedView2("*Триметрия", 8);
            SWmodel.ClearSelection2(true);


            //выбор плоскости/эскиза
            SWmodel.Extension.SelectByID2("Эскиз1", "SKETCH", 0, 0, 0, false, 4, null, 0);



            //выдавливание после выбора эскиза (найти что отвечает за расстояние РАССТОЯНИЕ и НАПРАВЛЕНИЕ)
            SWmodel.FeatureManager.FeatureExtrusion2(true, false, false, 0, 0, 0.07, 0.01, false, false, false,
                false, 1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false, true, true, (true), 0, 0,
                false);

            //выбор контура? зачем он?
            SWmodel.SelectionManager.EnableContourSelection = false;

            //       boolstatus = SWmodel.Extension.SelectByID2("Спереди", "PLANE", 0, 0, 0, false, 0, null, 0);
            //      boolstatus = SWmodel.Extension.SelectByID2("Спереди", "PLANE", 0, 0, 0, false, 0, null, 0);
            //     boolstatus = SWmodel.Extension.SelectByID2("Неизвестный", "BROWSERITEM", 0, 0, 0, false, 0, null, 0);


            //снова
            SWmodel.Extension.SelectByID2("Спереди", "PLANE", 0, 0, 0, false, 0, null, 0);
            //и снова
            SWmodel.SketchManager.InsertSketch(true);
            //а зачем очистка после????
            SWmodel.ClearSelection2(true);



            //скетч круг (что центр, что радиус, что угол)
            SWmodel.SketchManager.CreateCircle(0, 0, 0, -0.001067, -0.01027, 0);



            //   SWmodel.SketchManager.CreateCircle(0, 0, 0, CapRadius / 1000, 0, 0);
            //        SWmodel.ClearSelection2(true);
            //    SWmodel.Extension.SelectByID2("Arc1", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
            //    SWmodel.ClearSelection2(true);




            //выбор кусочка на чертеже, ибо скетч сегмент, почему арк1 и повторяется
            SWmodel.Extension.SelectByID2("Arc1", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);


            //самое простое выдавливание (найти что отвечает за расстояние РАССТОЯНИЕ и НАПРАВЛЕНИЕ)
            SWmodel.FeatureManager.FeatureCut3(true, false, true, 0, 0, 0.07, 0.07, false, false,
                false, false, 1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false, false,
                true, true, true, true, false, 0, 0, false);

            //очередной сброс (видимо скетча)
            SWmodel.ClearSelection2(true);


            //круг (что центр, что радиус, что угол)
            SWmodel.SketchManager.CreateCircle(0, 0, 0, -0.025609, -0.045216, 0);

            SWmodel.ClearSelection2(true);
            SWmodel.Extension.SelectByID2("Arc1", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);


            SWmodel.FeatureManager.FeatureExtrusion2(true, false, true, 0, 0, 0.02, 0.07, false,
                false, false, false, 1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false,
                true, true, true, 0, 0, false);



         //   SWmodel.Extension.SelectByID2("Спереди", "PLANE", 0, 0, 0, false, 0, null, 0);


            SWmodel.Extension.SelectByID2("Спереди", "PLANE", 0, 0, 0, false, 0, null, 0);
            SWmodel.ClearSelection2(true);


            SWmodel.SketchManager.CreateCircle(0, 0, 0, 0.0008, -0.046816, 0);
            SWmodel.SketchManager.CreateCircle(0, 0, 0, 0, -0.042815, 0);

        //    SWmodel.ClearSelection2(true);
            SWmodel.ClearSelection2(true);


            //почему здесь арк 2, а не арк1 или эскиз1 (какая дуга)
            SWmodel.Extension.SelectByID2("Arc2", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);


            //функция выдавливание
            SWmodel.FeatureManager.FeatureExtrusion2(true, false, true, 0, 0, 0.04, 0.02, false, false, false,
                false, 1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false, true, true, true,
                0, 0, false);
            SWmodel.ClearSelection2(true);


            //скетч функция круг
            SWmodel.SketchManager.CreateCircle(0, 0, 0, 0.001067, -0.009203, 0);



            // выдавливание очередное
            SWmodel.ClearSelection2(true);
            boolstatus = SWmodel.Extension.SelectByID2("Arc1", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
            SWmodel.FeatureManager.FeatureExtrusion2(true, false, true, 0, 0, 0.05, 0.04, false, false, false,
                false, 1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false, true, true, true, 0, 0, false);



            //   SWmodel.Extension.SelectByID2("", "EDGE", 0, 0, -0.07, false, 0, null, 0);
            //    SWmodel.ClearSelection2(true);
            //      SWmodel.Extension.SelectByID2("", "EDGE", 0, 0, -0.07, false, 0, null, 0);


            //   boolstatus = SWmodel.Extension.SelectByID2("", "EDGE", 0.0053957910507165252, 0.0068470210082978156, -0.06989040670725899, false, 1, null, 0);
            //       SWmodel.Extension.SelectByID2("", "FACE", 0, 0, -0.07, false, 1, null, 0);

            // функция выбора плоскости
            //   SWmodel.Extension.SelectByID2("", "FACE", 0, 0, -0.1, false, 1, null, 0);


            SWmodel.Extension.SelectByID2("Спереди", "PLANE", 0, 0, 0, false, 0, null, 0);
            SWmodel.ClearSelection2(true);

            //сслылка на переменные-массивы???????
            //  SWmodel.Extension.SelectByID2("", "EDGE", 0, 0, -0.07, false, 0, null, 0);

            boolstatus = SWmodel.Extension.SelectByID2("", "FACE", 0, 0, -0.05, false, 1, null, 0);
            Array radiiArray0 = null;
            double[] radiis0 = new double[0];
            Array dist2Array0 = null;
            double[] dists20 = new double[0];
            Array conicRhosArray0 = null;
            double[] coniRhos0 = new double[0];
            Array setBackArray0 = null;
            double[] setBacks0 = new double[0];
            Array pointArray0 = null;
            double[] points0 = new double[0];
            Array pointDist2Array0 = null;
            double[] pointsDist20 = new double[0];
            Array pointRhoArray0 = null;
            double[] pointsRhos0 = new double[0];
            radiiArray0 = radiis0;
            dist2Array0 = dists20;
            conicRhosArray0 = coniRhos0;
            setBackArray0 = setBacks0;
            pointArray0 = points0;
            pointDist2Array0 = pointsDist20;
            pointRhoArray0 = pointsRhos0;
            SWmodel.FeatureManager.FeatureFillet3(195, 0.0050000000000000001, 0.01, 0, 0, 0, 0, radiiArray0, dist2Array0, conicRhosArray0, setBackArray0, pointArray0, pointDist2Array0, pointRhoArray0);
            boolstatus = SWmodel.Extension.SelectByID2("Спереди", "PLANE", 0, 0, 0, false, 0, null, 0);


            /*
                    boolstatus = SWmodel.Extension.SelectByID2("Сверху", "PLANE", 0, 0, 0, false, 0, null, 0);
                    SWmodel.ClearSelection2(true);
                    Array vSkLines = null;
                    vSkLines = ((Array)(SWmodel.SketchManager.CreatePolygon(0, 0, 0, 0, -0.050000000000000003, 0, 6, true)));
                    SWmodel.ShowNamedView2("*Триметрия", 8);
                    SWmodel.ClearSelection2(true);
                    boolstatus = SWmodel.Extension.SelectByID2("Line1", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
                    boolstatus = SWmodel.Extension.SelectByID2("Line2", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
                    boolstatus = SWmodel.Extension.SelectByID2("Line3", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
                    boolstatus = SWmodel.Extension.SelectByID2("Line4", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
                    boolstatus = SWmodel.Extension.SelectByID2("Line5", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
                    boolstatus = SWmodel.Extension.SelectByID2("Line6", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
                    Feature myFeature = null;
                    myFeature = ((Feature)(SWmodel.FeatureManager.FeatureExtrusion2(true, false, true, 0, 0, 0.070000000000000007, 0.01, false, false, false, false, 0.017453292519943334, 0.017453292519943334, false, false, false, false, true, true, true, 0, 0, false)));
                    SWmodel.ISelectionManager.EnableContourSelection = false;
                    boolstatus = SWmodel.Extension.SelectByID2("Сверху", "PLANE", 0, 0, 0, false, 0, null, 0);
                    SWmodel.SketchManager.InsertSketch(true);
                    SWmodel.ClearSelection2(true);
                    SketchSegment skSegment = null;
                    skSegment = ((SketchSegment)(SWmodel.SketchManager.CreateCircle(0.000000, 0.000000, 0.000000, 0.001196, -0.042023, 0.000000)));
                    SWmodel.ClearSelection2(true);
                    boolstatus = SWmodel.Extension.SelectByID2("Arc1", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
                    myFeature = ((Feature)(SWmodel.FeatureManager.FeatureExtrusion2(true, false, false, 0, 0, 0.01, 0.070000000000000007, false, false, false, false, 0.017453292519943334, 0.017453292519943334, false, false, false, false, true, true, true, 0, 0, false)));
                    SWmodel.ISelectionManager.EnableContourSelection = false;
                    boolstatus = SWmodel.Extension.SelectByID2("Сверху", "PLANE", 0, 0, 0, false, 0, null, 0);
                    SWmodel.ClearSelection2(true);
                    skSegment = ((SketchSegment)(SWmodel.SketchManager.CreateCircle(0.000000, 0.000000, 0.000000, 0.001196, -0.039331, 0.000000)));
                    SWmodel.ClearSelection2(true);
                    skSegment = ((SketchSegment)(SWmodel.SketchManager.CreateCircle(0.000000, 0.000000, 0.000000, 0.001495, -0.035144, 0.000000)));
                    SWmodel.ClearSelection2(true);
                    boolstatus = SWmodel.Extension.SelectByID2("Arc2", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
                    myFeature = ((Feature)(SWmodel.FeatureManager.FeatureExtrusion2(true, false, false, 0, 0, 0.02, 0.01, false, false, false, false, 0.017453292519943334, 0.017453292519943334, false, false, false, false, true, true, true, 0, 0, false)));
                    SWmodel.ISelectionManager.EnableContourSelection = false;
                    boolstatus = SWmodel.Extension.SelectByID2("Сверху", "PLANE", 0, 0, 0, false, 0, null, 0);
                    SWmodel.ClearSelection2(true);
                    skSegment = ((SketchSegment)(SWmodel.SketchManager.CreateCircle(0.000000, 0.000000, 0.000000, -0.000299, -0.008823, 0.000000)));
                    boolstatus = SWmodel.Extension.SelectByID2("Сверху", "PLANE", 0, 0, 0, false, 0, null, 0);
                    SWmodel.ClearSelection2(true);
                    vSkLines = ((Array)(SWmodel.SketchManager.CreatePolygon(0, 0, 0, 0, -0.050000000000000003, 0, 6, true)));
                    SWmodel.ShowNamedView2("*Триметрия", 8);
                    SWmodel.ClearSelection2(true);
                    boolstatus = SWmodel.Extension.SelectByID2("Line1", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
                    boolstatus = SWmodel.Extension.SelectByID2("Line2", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
                    boolstatus = SWmodel.Extension.SelectByID2("Line3", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
                    boolstatus = SWmodel.Extension.SelectByID2("Line4", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
                    boolstatus = SWmodel.Extension.SelectByID2("Line5", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
                    boolstatus = SWmodel.Extension.SelectByID2("Line6", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
                    myFeature = ((Feature)(SWmodel.FeatureManager.FeatureExtrusion2(true, false, true, 0, 0, 0.070000000000000007, 0.01, false, false, false, false, 0.017453292519943334, 0.017453292519943334, false, false, false, false, true, true, true, 0, 0, false)));
                    SWmodel.ISelectionManager.EnableContourSelection = false;
                    boolstatus = SWmodel.Extension.SelectByID2("Сверху", "PLANE", 0, 0, 0, false, 0, null, 0);
                    SWmodel.ClearSelection2(true);
                    skSegment = ((SketchSegment)(SWmodel.SketchManager.CreateCircle(0.000000, 0.000000, 0.000000, -0.001196, -0.041724, 0.000000)));
                    SWmodel.ClearSelection2(true);
                    boolstatus = SWmodel.Extension.SelectByID2("Arc1", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
                    boolstatus = SWmodel.Extension.SelectByID2("Сверху", "PLANE", 0, 0, 0, false, 0, null, 0);
                    SWmodel.ClearSelection2(true);
                    vSkLines = ((Array)(SWmodel.SketchManager.CreatePolygon(0, 0, 0, 0, -0.050000000000000003, 0, 6, true)));
                    SWmodel.ShowNamedView2("*Триметрия", 8);
                    SWmodel.ClearSelection2(true);
                    boolstatus = SWmodel.Extension.SelectByID2("Line1", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
                    boolstatus = SWmodel.Extension.SelectByID2("Line2", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
                    boolstatus = SWmodel.Extension.SelectByID2("Line3", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
                    boolstatus = SWmodel.Extension.SelectByID2("Line4", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
                    boolstatus = SWmodel.Extension.SelectByID2("Line5", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
                    boolstatus = SWmodel.Extension.SelectByID2("Line6", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
                    myFeature = ((Feature)(SWmodel.FeatureManager.FeatureExtrusion2(true, false, true, 0, 0, 0.070000000000000007, 0.01, false, false, false, false, 0.017453292519943334, 0.017453292519943334, false, false, false, false, true, true, true, 0, 0, false)));
                    SWmodel.ISelectionManager.EnableContourSelection = false;
                    boolstatus = SWmodel.Extension.SelectByID2("Сверху", "PLANE", 0, 0, 0, false, 0, null, 0);
                    SWmodel.ClearSelection2(true);
                    skSegment = ((SketchSegment)(SWmodel.SketchManager.CreateCircle(0.000000, 0.000000, 0.000000, -0.000598, -0.010020, 0.000000)));

                    SWmodel.ClearSelection2(true);
                    boolstatus = SWmodel.Extension.SelectByID2("Arc1", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
                    myFeature = ((Feature)(SWmodel.FeatureManager.FeatureCut3(true, false, false, 0, 0, 0.070000000000000007, 0.070000000000000007, false, false, false, false, 0.017453292519943334, 0.017453292519943334, false, false, false, false, false, true, true, true, true, false, 0, 0, false)));
                    SWmodel.ISelectionManager.EnableContourSelection = false;
                    boolstatus = SWmodel.Extension.SelectByID2("Сверху", "PLANE", 0, 0, 0, false, 0, null, 0);
                    SWmodel.ClearSelection2(true);
                    skSegment = ((SketchSegment)(SWmodel.SketchManager.CreateCircle(0.000000, 0.000000, 0.000000, 0.001196, -0.039630, 0.000000)));
                    SWmodel.ClearSelection2(true);
                    boolstatus = SWmodel.Extension.SelectByID2("Arc1", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
                    myFeature = ((Feature)(SWmodel.FeatureManager.FeatureExtrusion2(true, false, false, 0, 0, 0.01, 0.070000000000000007, false, false, false, false, 0.017453292519943334, 0.017453292519943334, false, false, false, false, true, true, true, 0, 0, false)));
                    SWmodel.ISelectionManager.EnableContourSelection = false;
                    boolstatus = SWmodel.Extension.SelectByID2("Сверху", "PLANE", 0, 0, 0, false, 0, null, 0);
                    SWmodel.ClearSelection2(true);
                    skSegment = ((SketchSegment)(SWmodel.SketchManager.CreateCircle(0.000000, 0.000000, 0.000000, 0.000897, -0.035742, 0.000000)));
                    SWmodel.ClearSelection2(true);
                    skSegment = ((SketchSegment)(SWmodel.SketchManager.CreateCircle(0.000000, 0.000000, 0.000000, 0.001196, -0.029461, 0.000000)));
                    SWmodel.ClearSelection2(true);
                    boolstatus = SWmodel.Extension.SelectByID2("Arc2", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
                    myFeature = ((Feature)(SWmodel.FeatureManager.FeatureExtrusion2(true, false, false, 0, 0, 0.029999999999999999, 0.01, false, false, false, false, 0.017453292519943334, 0.017453292519943334, false, false, false, false, true, true, true, 0, 0, false)));
                    SWmodel.ISelectionManager.EnableContourSelection = false;
                    boolstatus = SWmodel.Extension.SelectByID2("Сверху", "PLANE", 0, 0, 0, false, 0, null, 0);
                    SWmodel.ClearSelection2(true);
                    skSegment = ((SketchSegment)(SWmodel.SketchManager.CreateCircle(0.000000, 0.000000, 0.000000, 0.000299, -0.009421, 0.000000)));
                    SWmodel.ClearSelection2(true);
                    boolstatus = SWmodel.Extension.SelectByID2("Arc1", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
                    myFeature = ((Feature)(SWmodel.FeatureManager.FeatureExtrusion2(true, false, false, 0, 0, 0.050000000000000003, 0.029999999999999999, false, false, false, false, 0.017453292519943334, 0.017453292519943334, false, false, false, false, true, true, true, 0, 0, false)));
                    SWmodel.ISelectionManager.EnableContourSelection = false;



                 //   boolstatus = SWmodel.Extension.SelectByID2("", "EDGE", -0.0092719068117216308, 0.050000000000011369, -0.00014954688406061358, false, 0, null, 0);
                    boolstatus = SWmodel.Extension.SelectByID2("", "FACE", -0.0020936563768404193, 0.050000000000011369, 0.0037386721015000464, false, 0, null, 0);
                    SWmodel.ClearSelection2(true);
                    boolstatus = SWmodel.Extension.SelectByID2("", "FACE", -0.0020936563768404193, 0.050000000000011369, 0.0037386721015000464, false, 1, null, 0);
                    Array radiiArray0 = null;
                    double[] radiis0 = new double[0];
                    Array dist2Array0 = null;
                    double[] dists20 = new double[0];
                    Array conicRhosArray0 = null;
                    double[] coniRhos0 = new double[0];
                    Array setBackArray0 = null;
                    double[] setBacks0 = new double[0];
                    Array pointArray0 = null;
                    double[] points0 = new double[0];
                    Array pointDist2Array0 = null;
                    double[] pointsDist20 = new double[0];
                    Array pointRhoArray0 = null;
                    double[] pointsRhos0 = new double[0];
                    radiiArray0 = radiis0;
                    dist2Array0 = dists20;
                    conicRhosArray0 = coniRhos0;
                    setBackArray0 = setBacks0;
                    pointArray0 = points0;
                    pointDist2Array0 = pointsDist20;
                    pointRhoArray0 = pointsRhos0;
                    myFeature = ((Feature)(SWmodel.FeatureManager.FeatureFillet3(195, 0.0050000000000000001, 0.01, 0, 0, 0, 0, radiiArray0, dist2Array0, conicRhosArray0, setBackArray0, pointArray0, pointDist2Array0, pointRhoArray0)));
                    boolstatus = SWmodel.Extension.SelectByID2("Сверху", "PLANE", 0, 0, 0, false, 0, null, 0);
                    myModelView = ((ModelView)(SWmodel.ActiveView));
                    myModelView.RotateAboutCenter(0, -0.015745452440426206);
                    myModelView = ((ModelView)(SWmodel.ActiveView));
                    myModelView.RotateAboutCenter(-0.0061313611268945913, 0);
                    myModelView = ((ModelView)(SWmodel.ActiveView));
                    myModelView.RotateAboutCenter(0, -0.015745452440426206);
                    myModelView = ((ModelView)(SWmodel.ActiveView));
                    myModelView.RotateAboutCenter(0, -0.015745452440426206);
                    myModelView = ((ModelView)(SWmodel.ActiveView));
                    myModelView.RotateAboutCenter(-0.0061313611268945913, 0);

            */

        }
    }
}
