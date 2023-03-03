using Avalonia.Controls;
using ClosedXML.Excel;
using ScottPlot.Avalonia;
using System.Collections.Generic;

namespace testtesttest
{
    public partial class MainWindow : Window
    {
        double[] dataX = new double[450];
        string xlsxpath = "..\\..\\..\\data.xlsx";
        double[] dataY = new double[450];


        public MainWindow()
        {
            InitializeComponent();
            Diagram();
        }
        public void LoadData(string xlsxpath)
        {
            // ��������� �����
            var workbook = new XLWorkbook(xlsxpath);
            // ����� � ��� ������ ����
            var worksheet = workbook.Worksheets.Worksheet(1);

            // ���������� �������� ������ �����
            for (int row = 3; row <= 452; ++row)
            {
                // �� ������ ������ ��������� ������

                dataX[row - 3] = worksheet.Cell(row, 4).GetValue<float>();
                dataY[row - 3] = worksheet.Cell(row, 5).GetValue<float>();

            }
                           
        }
        public void Diagram()
        {

            LoadData(xlsxpath);
            AvaPlot avaPlot1 = this.Find<AvaPlot>("Aplot");
            avaPlot1.Plot.AddScatter(dataX[0..149], dataY[0..149]);
            avaPlot1.Plot.AddScatter(dataX[150..300], dataY[150..300]);
            avaPlot1.Plot.AddScatter(dataX[300..450], dataY[300..450]);
            avaPlot1.Refresh();
        }
    }
}
