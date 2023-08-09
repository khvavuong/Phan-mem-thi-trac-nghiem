using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using CrystalDecisions.CrystalReports.Engine;

namespace CrystalReport_Tutorial
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnXem_Click(object sender, RoutedEventArgs e)
        {
            ReportDocument report = new ReportDocument();
           // report.Load("");
            crystalReportsViewer1.ViewerCore.ReportSource = report;
        }
    }
}
