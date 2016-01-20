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
    public Form1() {
      InitializeComponent();
    }

    private void Form1_Load(object sender,EventArgs e) {
      this.ClientSize=new Size(800,600);//Inner window size setting, not counting window borders - actually useable space

      ZoomIn.Location=new Point(this.ClientSize.Width-ZoomIn.Width,LineTool.Location.Y);
      ZoomOut.Location=new Point(ZoomIn.Location.X-ZoomOut.Width,ZoomIn.Location.Y);

      /*Button LineTool=new Button();
      LineTool.Location=new Point(0,0);
      LineTool.Size=new Size(32,32);
      LineTool.Margin=new Padding(0,0,0,0);
      LineTool.Padding=new Padding(0,0,0,0);

      Button NodeTool=new Button();
      NodeTool.Location=new Point(LineTool.Location.X+LineTool.Width,0);
      NodeTool.Size=new Size(32,32);
      NodeTool.Margin=new Padding(0,0,0,0);
      NodeTool.Padding=new Padding(0,0,0,0);

      this.Controls.Add(LineTool);
      this.Controls.Add(NodeTool);*/
    }

    private void NodeTool_Click(object sender,EventArgs e) {

    }

    private void quitToolStripMenuItem_Click(object sender,EventArgs e) {
      this.Close();
    }
  }
}
