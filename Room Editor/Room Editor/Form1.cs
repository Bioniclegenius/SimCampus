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

    public RoomEditor p;
    public Form1() {
      InitializeComponent();
    }

    private void Form1_Load(object sender,EventArgs e) {
      this.ClientSize=new Size(800,600);//Inner window size setting, not counting window borders - actually useable space

      p=new RoomEditor(0,menuStrip1.Bottom,this.ClientSize.Width,this.ClientSize.Height-menuStrip1.Bottom);
      this.Controls.Add(p);
    }

    private void quitToolStripMenuItem_Click(object sender,EventArgs e) {
      this.Close();
    }

    private void Form1_MouseMove(object sender,MouseEventArgs e) {
      p.mouseCalc(e.Location.X-p.Location.X,e.Location.Y-p.Location.Y);
    }

    private void roomToolStripMenuItem_Click(object sender,EventArgs e) {
      p.r.loadFile();
    }

    private void Form1_KeyPress(object sender,KeyPressEventArgs e) {
      p.keyPress(sender,e);
    }

    private void saveToolStripMenuItem_Click(object sender,EventArgs e) {
      p.r.saveFile();
    }

    private void saveAsToolStripMenuItem_Click(object sender,EventArgs e) {
      p.r.location="";
      p.r.saveFile();
    }
  }
}
