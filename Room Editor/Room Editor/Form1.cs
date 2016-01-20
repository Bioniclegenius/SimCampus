using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Room_Editor {
  public partial class Form1:Form {

    public RenderPanel p;
    public Form1() {
      InitializeComponent();
    }

    private void Form1_Load(object sender,EventArgs e) {
      this.ClientSize=new Size(800,600);//Inner window size setting, not counting window borders - actually useable space

      ZoomIn.Location=new Point(this.ClientSize.Width-ZoomIn.Width,LineTool.Location.Y);
      ZoomOut.Location=new Point(ZoomIn.Location.X-ZoomOut.Width,ZoomIn.Location.Y);

      p=new RenderPanel(0,ZoomIn.Bottom,this.ClientSize.Width,this.ClientSize.Height-ZoomIn.Bottom);
      this.Controls.Add(p);
    }

    private void NodeTool_Click(object sender,EventArgs e) {

    }

    private void quitToolStripMenuItem_Click(object sender,EventArgs e) {
      this.Close();
    }

    private void ZoomIn_Click(object sender,EventArgs e) {
      p.zoomIn();
    }

    private void ZoomOut_Click(object sender,EventArgs e) {
      p.zoomOut();
    }

    private void Form1_MouseMove(object sender,MouseEventArgs e) {
      p.mouseCalc(e.Location.X-p.Location.X,e.Location.Y-p.Location.Y);
    }
  }
}
