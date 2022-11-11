using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

public partial class Views_IBPP_Stock_Summary : System.Web.UI.Page
{
    readonly StockController chart = new StockController();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetCapAvailable();
            GetSpoutAvailble();
            GetSlitValveTotal();
            GetBottleAssyTotal();
        }
   
    }
    public void GetCapAvailable()
    {
        DataTable dt = new DataTable();
     
        dt = chart.GetCapTotal();
        string[] x = new string[dt.Rows.Count];
        int[] y = new int[dt.Rows.Count];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            x[i] = dt.Rows[i]["LINE"].ToString();
            y[i] = Convert.ToInt32(dt.Rows[i]["TOTAL"]);
        }
        CapChart.Series[0].Points.DataBindXY(x, y);
        CapChart.Series[0].ChartType = SeriesChartType.Bar;
        CapChart.Series[0].Label = "#VALY";
        CapChart.ChartAreas[0].AxisX.Title = "Stock Area";
        CapChart.ChartAreas[0].AxisY.Title = "Quantity Per Stock Area";
     
        CapChart.ChartAreas["CapAreaChart"].AxisX.Interval = 1;
        CapChart.ChartAreas["CapAreaChart"].AxisX.MajorGrid.Enabled = false;
        CapChart.ChartAreas["CapAreaChart"].AxisY.MajorGrid.Enabled = false;
    }
    public void GetSpoutAvailble()
    {
        DataTable dt = new DataTable();
        dt = chart.GetSpoutTotal();
        string[] x = new string[dt.Rows.Count];
        int[] y = new int[dt.Rows.Count];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            x[i] = dt.Rows[i]["LINE"].ToString();
            y[i] = Convert.ToInt32(dt.Rows[i]["TOTAL"]);
        }
        SpoutChart.Series[0].Points.DataBindXY(x, y);
        SpoutChart.Series[0].ChartType = SeriesChartType.Bar;
        SpoutChart.Series[0].Label = "#VALY";
        SpoutChart.ChartAreas[0].AxisX.Title = "Stock Area";
        SpoutChart.ChartAreas[0].AxisY.Title = "Quantity Per Stock Area";
        SpoutChart.ChartAreas["SpoutAreaChart"].AxisX.Interval = 1;
        SpoutChart.ChartAreas["SpoutAreaChart"].AxisX.MajorGrid.Enabled = false;
        SpoutChart.ChartAreas["SpoutAreaChart"].AxisY.MajorGrid.Enabled = false;
    }
    public void GetSlitValveTotal()
    {
        DataTable dt = new DataTable();
        dt = chart.GetSlitValveTotal();
        string[] x = new string[dt.Rows.Count];
        int[] y = new int[dt.Rows.Count];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            x[i] = dt.Rows[i]["LINE"].ToString();
            y[i] = Convert.ToInt32(dt.Rows[i]["TOTAL"]);
        }
        SlitValveChart.Series[0].Points.DataBindXY(x, y);
        SlitValveChart.Series[0].ChartType = SeriesChartType.Bar;
        SlitValveChart.Series[0].Label = "#VALY";
        SlitValveChart.ChartAreas[0].AxisX.Title = "Stock Area";
        SlitValveChart.ChartAreas[0].AxisY.Title = "Quantity Per Stock Area";
        SlitValveChart.ChartAreas["SlitValveAreaChart"].AxisX.Interval = 1;
        SlitValveChart.ChartAreas["SlitValveAreaChart"].AxisX.MajorGrid.Enabled = false;
        SlitValveChart.ChartAreas["SlitValveAreaChart"].AxisY.MajorGrid.Enabled = false;
    }
    public void GetBottleAssyTotal()
    {
        DataTable dt = new DataTable();
        dt = chart.GetBottleAssyTotal();
        string[] x = new string[dt.Rows.Count];
        int[] y = new int[dt.Rows.Count];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            x[i] = dt.Rows[i]["LINE"].ToString();
            y[i] = Convert.ToInt32(dt.Rows[i]["TOTAL"]);
        }
       BottleAssyChart.Series[0].Points.DataBindXY(x, y);
       BottleAssyChart.Series[0].ChartType = SeriesChartType.Bar;
       BottleAssyChart.Series[0].Label = "#VALY";
       BottleAssyChart.ChartAreas[0].AxisX.Title = "Stock Area";
       BottleAssyChart.ChartAreas[0].AxisY.Title = "Quantity Per Stock Area";
       BottleAssyChart.ChartAreas["BottleAssyAreaChart"].AxisX.Interval = 1;
       BottleAssyChart.ChartAreas["BottleAssyAreaChart"].AxisX.MajorGrid.Enabled = false;
       BottleAssyChart.ChartAreas["BottleAssyAreaChart"].AxisY.MajorGrid.Enabled = false;
    }

    protected void UpdateChartTimer_Tick(object sender, EventArgs e)
    {
        GetCapAvailable();
        GetSpoutAvailble();
        GetSlitValveTotal();
        GetBottleAssyTotal();
    }
}
