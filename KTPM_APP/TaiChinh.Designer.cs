
namespace KTPM_APP
{
    partial class TaiChinh
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chartTienLuong = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartSoLuong = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartTienLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSoLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // chartTienLuong
            // 
            this.chartTienLuong.BackColor = System.Drawing.Color.Gainsboro;
            chartArea1.Name = "ChartArea1";
            this.chartTienLuong.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartTienLuong.Legends.Add(legend1);
            this.chartTienLuong.Location = new System.Drawing.Point(12, 37);
            this.chartTienLuong.Name = "chartTienLuong";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Đã Thanh Toán";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Dự Kiến";
            this.chartTienLuong.Series.Add(series1);
            this.chartTienLuong.Series.Add(series2);
            this.chartTienLuong.Size = new System.Drawing.Size(537, 480);
            this.chartTienLuong.TabIndex = 0;
            this.chartTienLuong.Text = "chart1";
            title1.Name = "Title1";
            title1.Text = "Tiền Lương";
            this.chartTienLuong.Titles.Add(title1);
            // 
            // chartSoLuong
            // 
            chartArea2.Name = "ChartArea1";
            this.chartSoLuong.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartSoLuong.Legends.Add(legend2);
            this.chartSoLuong.Location = new System.Drawing.Point(555, 37);
            this.chartSoLuong.Name = "chartSoLuong";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series3.Legend = "Legend1";
            series3.Name = "Số Lượng";
            this.chartSoLuong.Series.Add(series3);
            this.chartSoLuong.Size = new System.Drawing.Size(492, 550);
            this.chartSoLuong.TabIndex = 1;
            this.chartSoLuong.Text = "chart2";
            this.chartSoLuong.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.Normal;
            title2.Name = "Title1";
            title2.Text = "Trạng Thái Lương";
            this.chartSoLuong.Titles.Add(title2);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("#9Slide01 Tieu de ngan", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 34);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tài Chính";
            // 
            // TaiChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 600);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chartSoLuong);
            this.Controls.Add(this.chartTienLuong);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TaiChinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.TaiChinh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartTienLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSoLuong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartTienLuong;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSoLuong;
        private System.Windows.Forms.Label label1;
    }
}//this.chartTienLuong.Size = new System.Drawing.Size(520, 475);
 //this.chartSoLuong.Size = new System.Drawing.Size(480, 529);