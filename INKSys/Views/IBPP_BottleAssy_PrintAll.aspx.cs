using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web.UI.WebControls;
using Zen.Barcode;
public partial class Views_IBPP_BottleAssy_PrintAll : System.Web.UI.Page
{
    static IBPP_BottleAssy_Get assy_Get = new IBPP_BottleAssy_Get();
    protected void Page_Load(object sender, EventArgs e)
    {
      
            getIBPPBottleAssy();
            PrintLotLabel();
        

        //CrystalReportViewer1.Dispose();
        //CrystalReportViewer1 = null;
    }

    
    public void PrintLotLabel()
    {
        var dsLot = new dataBottleAssy();
        try
        {
            foreach (GridViewRow row in grvBottleAssy.Rows)
            {
                string strCode =        row.Cells[0].Text.ToString().Trim();
                string strAssyLot =     row.Cells[1].Text.ToString().Trim();
                string strBottleLot =   row.Cells[2].Text.ToString().Trim();
                string strSFLot =       row.Cells[3].Text.ToString().Trim();
                string strAmount =      row.Cells[4].Text.ToString().Trim();
                string strBoxNo =       row.Cells[5].Text.ToString().Trim();
                string strCavityNo =    row.Cells[6].Text.ToString().Trim();
                string strModel =       row.Cells[7].Text.ToString().Trim();
                string strDestination = row.Cells[8].Text.ToString().Trim();
                string strColor =       row.Cells[9].Text.ToString().Trim();
                string strSline =       row.Cells[10].Text.ToString().Trim();
                string strIncharge =    row.Cells[11].Text.ToString().Trim();
                       string strQRCode = "Z1" + strCode
                                  + "|" + "Z2" + strAssyLot
                                  + "|" + "Z5" + strAmount
                                  + "|" + "Z6" + strBoxNo
                                  + "|" + "Z7" + strCavityNo;

                string strPath = AppDomain.CurrentDomain.BaseDirectory;
                ReportDocument crystalReport = new ReportDocument();
                crystalReport.Load(strPath + "Reports/AssyBarcode.rpt");

                

                dsLot.dt_bottleassy.Adddt_bottleassyRow(
                    strCode
                    , imageToByteArray(BarcodeDrawFactory.Code128WithChecksum.Draw(strCode, 25, 10))
                    , strAssyLot
                    , imageToByteArray(BarcodeDrawFactory.Code128WithChecksum.Draw(strAssyLot, 25, 10))
                    , strBottleLot
                    , strSFLot
                    , strAmount
                    , imageToByteArray(BarcodeDrawFactory.Code128WithChecksum.Draw(strAmount, 25, 10))
                    , strBoxNo
                    , imageToByteArray(BarcodeDrawFactory.Code128WithChecksum.Draw(strBoxNo, 25, 10))
                    , strCavityNo
                    , strModel
                    , strDestination
                    , strColor
                    , strSline
                    , strIncharge
                    , imageToByteArray(BarcodeDrawFactory.CodeQr.Draw(strQRCode, 255))
                );

                var labelBox = (BoxObject)crystalReport.ReportDefinition.ReportObjects["labelBox"];
                //var txtHead = (TextObject)crystalReport.ReportDefinition.ReportObjects["Text1"];
                if (strColor == "BLACK")
                {
                    labelBox.FillColor = Color.LightGray;
                }
                else if (strColor == "CYAN")
                {
                    labelBox.FillColor = Color.Cyan;
                }
                else if (strColor == "MAGENTA")
                {
                    labelBox.FillColor = Color.Magenta;
                }
                else
                {
                    labelBox.FillColor = Color.Yellow;
                }
                  crystalReport.SetDataSource(dsLot);
               //crystalReport.PrintToPrinter(1, false, 0, 0);
                CrystalReportViewer1.ReportSource = crystalReport;
 

            }
      
            GC.Collect();
            GC.WaitForPendingFinalizers();


        }
          


        catch (Exception ex)
        {
            Response.Write(ex + "ERROR");
        }
    }

    public void getIBPPBottleAssy()
    {
        DataTable dt = new DataTable();
        dt = assy_Get.getBottleAssyBarcode();
        grvBottleAssy.DataSource = dt;
        grvBottleAssy.DataBind();
    }
    public byte[] imageToByteArray(System.Drawing.Image image)
    {
        using (MemoryStream stream = new MemoryStream())
        using (image)
        {
            image.Save(stream, ImageFormat.Jpeg);
            return stream.ToArray();
        }
    }

}