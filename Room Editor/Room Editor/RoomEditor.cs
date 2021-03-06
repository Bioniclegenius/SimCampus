﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Room_Editor {
  public class RoomEditor:Panel {

    float cx,cy,zoom;
    float mx,my;
    const int BARSPACE=20;
    const int MAXZOOMLEVEL=4;
    const int MINZOOMLEVEL=4;
    int clickStage;
    PointF clickC;
    int nodeSel;
    int toolSel;
    public Room r;
    Button lineTool;
    Button nodeTool;
    Button nConTool;
    Button deleTool;
    Button zoomInBut;
    Button zoomOutBut;
    public RoomEditor(int x,int y,int w,int h) {
      this.Location=new Point(x,y);
      this.Width=w;
      this.Height=h;
      this.DoubleBuffered=true;
      this.Paint+=new PaintEventHandler(this.paintEvent);
      this.MouseMove+=new MouseEventHandler(this.mouseMove);
      this.MouseClick+=new MouseEventHandler(this.mouseClick);
      this.KeyPress+=new KeyPressEventHandler(this.keyPress);

      #region buttons
      lineTool=new Button();
      lineTool.Location=new Point(0,0);
      lineTool.Size=new Size(32,32);
      lineTool.Image=Image.FromFile("../../resources/linetool.png");
      lineTool.Click+=new System.EventHandler(this.lineTool_Click);
      this.Controls.Add(lineTool);

      nodeTool=new Button();
      nodeTool.Location=new Point(lineTool.Location.X+32,lineTool.Location.Y);
      nodeTool.Size=new Size(32,32);
      nodeTool.Image=Image.FromFile("../../resources/nodetool.png");
      nodeTool.Click+=new System.EventHandler(this.nodeTool_Click);
      this.Controls.Add(nodeTool);

      nConTool=new Button();
      nConTool.Location=new Point(lineTool.Location.X+64,lineTool.Location.Y);
      nConTool.Size=new Size(32,32);
      nConTool.Image=Image.FromFile("../../resources/ncontool.png");
      nConTool.Click+=new System.EventHandler(this.nConTool_Click);
      this.Controls.Add(nConTool);

      deleTool=new Button();
      deleTool.Location=new Point(lineTool.Location.X+96,lineTool.Location.Y);
      deleTool.Size=new Size(32,32);
      deleTool.Image=Image.FromFile("../../resources/delete.png");
      deleTool.Click+=new System.EventHandler(this.deleTool_Click);
      this.Controls.Add(deleTool);

      zoomInBut=new Button();
      zoomInBut.Location=new Point(this.Width-32,lineTool.Location.Y);
      zoomInBut.Size=new Size(32,32);
      zoomInBut.Image=Image.FromFile("../../resources/zoomin.png");
      zoomInBut.Click+=new System.EventHandler(this.zoomInBut_Click);
      this.Controls.Add(zoomInBut);

      zoomOutBut=new Button();
      zoomOutBut.Location=new Point(this.Width-64,lineTool.Location.Y);
      zoomOutBut.Size=new Size(32,32);
      zoomOutBut.Image=Image.FromFile("../../resources/zoomout.png");
      zoomOutBut.Click+=new System.EventHandler(this.zoomOutBut_Click);
      this.Controls.Add(zoomOutBut);
      #endregion

      clickStage=0;
      nodeSel=-1;
      toolSel=1;
      mx=this.Width/2;
      my=this.Height/2;
      cx=0;
      cy=0;
      zoom=1;
      clickC=new PointF();
      r=new Room("test");
      Invalidate();
    }

    private void mouseMove(Object sender,MouseEventArgs e) {
      mouseCalc(e.Location.X,e.Location.Y);
    }

    public void mouseCalc(int mousex,int mousey) {
      mx=(mousex-this.Width/2)/zoom/BARSPACE;
      my=(this.Height/2-mousey)/zoom/BARSPACE;
      if(clickStage!=-1)
        snapTo();
    }

    public void selectTool(int tool) {
      if(clickStage!=-1)
        clickStage=0;
      toolSel=tool;
      switch(toolSel) {
        case 1:
          lineTool.Select();
          break;
        case 2:
          nodeTool.Select();
          break;
        case 3:
          nConTool.Select();
          break;
        default:
          break;
      }
      if(clickStage==-1)
        deleTool.BackColor=Color.FromArgb(255,128,128);
      else
        deleTool.BackColor=default(Color);
    }

    private void snapTo() {
      float mxC=mx*zoom;
      if(mxC<0)
        mxC*=-1;
      int mxCI=(int)(mxC);
      mxC-=mxCI;
      if(mxC<.5)
        mxC=0;
      else
        mxC=1;
      mxC+=mxCI;
      mxC/=zoom;
      if(mx<0)
        mx=-mxC;
      else
        mx=mxC;
      float myC=my*zoom;
      if(myC<0)
        myC*=-1;
      int myCI=(int)(myC);
      myC-=myCI;
      if(myC<.5)
        myC=0;
      else
        myC=1;
      myC+=myCI;
      myC/=zoom;
      if(my<0)
        my=-myC;
      else
        my=myC;
    }

    public void zoomIn() {
      if(zoom<Math.Pow(2,MAXZOOMLEVEL))
        zoom*=2;
    }

    public void zoomOut() {
      if(zoom>1f/Math.Pow(2,MINZOOMLEVEL))
        zoom/=2;
    }

    public void moveRight() {
      cx+=1/zoom;
    }

    public void moveLeft() {
      cx-=1/zoom;
    }

    public void moveUp() {
      cy+=1/zoom;
    }

    public void moveDown() {
      cy-=1/zoom;
    }

    public void removeOnLine(float error) {
      for(int x=r.lines.Count-1;x>=0;x--) {
        double x1=r.lines[x][0].X;
        double y1=r.lines[x][0].Y;
        double x2=r.lines[x][1].X;
        double y2=r.lines[x][1].Y;
        double AB=Math.Sqrt(Math.Pow(x2-x1,2)+Math.Pow(y2-y1,2));
        double AP=Math.Sqrt(Math.Pow(x1-mx,2)+Math.Pow(y1-my,2));
        double PB=Math.Sqrt(Math.Pow(mx-x2,2)+Math.Pow(my-y2,2));
        if(AP+PB-AB<=error) {
          r.lines.RemoveAt(x);
          break;
        }
      }
    }

    public int checkOnNode(float error) {
      double mindist=error;
      int nodeSel=-1;
      for(int x=r.nodes.Count-1;x>=0;x--) {
        double x1=r.nodes[x].x;
        double y1=r.nodes[x].y;
        double dist=Math.Sqrt(Math.Pow(x1-mx,2)+Math.Pow(y1-my,2));
        if(dist<=error&&dist<=mindist) {
          mindist=dist;
          nodeSel=x;
        }
      }
      return nodeSel;
    }

    public void removeOnNode(float error) {
      int nodeSel=checkOnNode(error);
      if(nodeSel>=0)
        r.removeNode(r.nodes[nodeSel].x,r.nodes[nodeSel].y,r.nodes[nodeSel].z);
    }

    public void mouseClick(Object sender,MouseEventArgs e) {
      #region linetool
      if(toolSel==1) {
        if(clickStage==0) {
          clickStage=1;
          clickC=new PointF(mx,my);
        }
        else if(clickStage==1) {
          r.addLine(clickC.X,clickC.Y,mx,my);
          clickStage=0;
        }
        else {
          removeOnLine(1/zoom/BARSPACE);
        }
      }
      #endregion
      #region nodetool
      else if(toolSel==2) {
        if(clickStage==0)
          r.addNode(mx,my,0);
        else
          removeOnNode(1/zoom);
      }
      #endregion
      #region nodeconnectiontool
      else if(toolSel==3) {
        if(clickStage==0) {
          nodeSel=checkOnNode(1/zoom);
          if(nodeSel!=-1)
            clickStage=1;
        }
        else if(clickStage==1) {
          int nodeTo=checkOnNode(1/zoom);
          if(nodeTo!=-1&&nodeTo!=nodeSel) {
            clickStage=0;
            r.addConnection(nodeSel,nodeTo);
            nodeSel=-1;
          }
        }
        else {
        }
      }
      #endregion
    }

    #region Screen Coordinate Conversions
    public int toScreenW(float num) {
      int goal=(int)(this.Width/2+num*zoom*BARSPACE+.5);
      return goal;
    }

    public int toScreenW(double num) {
      return toScreenW((float)(num));
    }

    public int toScreenW(int num) {
      return toScreenW((float)(num));
    }

    public int toScreenH(float num) {
      int goal=(int)(this.Height/2-num*zoom*BARSPACE+.5);
      return goal;
    }

    public int toScreenH(double num) {
      return toScreenH((float)(num));
    }

    public int toScreenH(int num) {
      return toScreenH((float)(num));
    }
    #endregion

    public void paintEvent(Object sender,PaintEventArgs e) {
      Graphics g=e.Graphics;
      SolidBrush b=new SolidBrush(Color.FromArgb(0,0,0));
      g.FillRectangle(b,0,0,this.Width,this.Height);//Background Filling

      int zoompoint=4;
      if(zoom>4)
        zoompoint=1;
      if(zoom<=1)
        zoompoint=16;
      if(zoom<=.125)
        zoompoint=64;

      //Grid Filling
      for(int x=0;x<this.Width/BARSPACE;x++) {//Vertical Lines
        if((cx*zoom/zoompoint+x/zoom)%zoompoint==0)//Right of Center
          b.Color=Color.FromArgb(160,160,160);
        else
          b.Color=Color.FromArgb(48,48,48);
        g.FillRectangle(b,this.Width/2+BARSPACE*x,0,1,this.Height);
      }
      for(int x=1;x<this.Width/BARSPACE;x++) {
        if((cx*zoom/zoompoint-x/zoom)%zoompoint==0)//Left of Center
          b.Color=Color.FromArgb(160,160,160);
        else
          b.Color=Color.FromArgb(48,48,48);
        g.FillRectangle(b,this.Width/2-BARSPACE*x,0,1,this.Height);
      }


      for(int y=0;y<this.Height/BARSPACE;y++) {//Horizontal Lines
        if((cy*zoom/zoompoint+y/zoom)%zoompoint==0)//Above Center
          b.Color=Color.FromArgb(160,160,160);
        else
          b.Color=Color.FromArgb(48,48,48);
        g.FillRectangle(b,0,this.Height/2-BARSPACE*y,this.Width,1);
      }
      for(int y=1;y<this.Width/BARSPACE;y++) {
        if((cy*zoom/zoompoint-y/zoom)%zoompoint==0)//Below Center
          b.Color=Color.FromArgb(160,160,160);
        else
          b.Color=Color.FromArgb(48,48,48);
        g.FillRectangle(b,0,this.Height/2+BARSPACE*y,this.Width,1);
      }
      b.Color=Color.FromArgb(255,255,255);
      g.FillRectangle(b,toScreenW(mx)-2,toScreenH(my)-2,5,5);//mouse locator

      //Draw Room
      b.Color=Color.FromArgb(255,64,64);
      Pen p=new Pen(b.Color);
      p.Width=2;
      for(int x=0;x<r.lines.Count;x++) {
        g.DrawLine(p,toScreenW(r.lines[x][0].X),toScreenH(r.lines[x][0].Y),
                               toScreenW(r.lines[x][1].X),toScreenH(r.lines[x][1].Y));
      }
      p.Color=Color.FromArgb(255,255,0);
      p.Width=1;
      for(int x=0;x<r.nodes.Count;x++) {
        if(toolSel==2||toolSel==3) {
          if(checkOnNode(1/zoom)==x||nodeSel==x)
            p.Color=Color.FromArgb(255,0,0);
          else
            p.Color=Color.FromArgb(255,255,0);
        }
        g.DrawEllipse(p,toScreenW(r.nodes[x].x)-BARSPACE*zoom,toScreenH(r.nodes[x].y)-BARSPACE*zoom,
                                  BARSPACE*2*zoom,BARSPACE*2*zoom);
        p.Color=Color.FromArgb(255,255,0);
        for(int y=0;y<r.nodes[x].connections.Count;y++)
          g.DrawLine(p,toScreenW(r.nodes[x].x),toScreenH(r.nodes[x].y),
                       toScreenW(r.nodes[x].connections[y].x),toScreenH(r.nodes[x].connections[y].y));
      }

      //Extra Renderings

      if(toolSel==1&&clickStage==1) {
        b.Color=Color.FromArgb(255,255,255);
        g.DrawLine(new Pen(b.Color),toScreenW(clickC.X),toScreenH(clickC.Y),toScreenW(mx),toScreenH(my));
      }

      //End Extra Renderings

      b.Color=Color.FromArgb(160,160,160);//Coordinate Display

      string coordinateOutput=Convert.ToString(mx)+","+Convert.ToString(my);
      Font f=new Font("Arial",16);//Coordinate Drawing
      SizeF coordSize=g.MeasureString(coordinateOutput,f);

      g.FillRectangle(b,0,this.Height-coordSize.Height-2,coordSize.Width+2,coordSize.Height+2);//Border
      b.Color=Color.FromArgb(15,15,15);
      g.FillRectangle(b,0,this.Height-coordSize.Height-1,coordSize.Width+1,coordSize.Height+1);//Internal Box
      b.Color=Color.FromArgb(160,160,160);
      g.DrawString(coordinateOutput,f,b,new PointF(2,this.Height-coordSize.Height));//text
      //g.DrawString(Convert.ToString(clickStage),f,b,new PointF(5,35));//Debug text output

      foreach(var x in this.Controls.OfType<Button>()) {
        x.Invalidate();
        x.Update();
        x.Refresh();
      }
      Invalidate();
    }

    private void InitializeComponent() {
      this.SuspendLayout();
      this.ResumeLayout(false);
    }

    private void lineTool_Click(object sender,EventArgs e) {
      selectTool(1);
    }

    private void nodeTool_Click(object sender,EventArgs e) {
      selectTool(2);
    }

    private void nConTool_Click(object sender,EventArgs e) {
      selectTool(3);
    }

    private void deleTool_Click(object sender,EventArgs e) {
      if(clickStage!=-1)
        clickStage=-1;
      else
        clickStage=0;
      selectTool(toolSel);
    }

    private void zoomInBut_Click(object sender,EventArgs e) {
      zoomIn();
      selectTool(toolSel);
    }

    private void zoomOutBut_Click(object sender,EventArgs e) {
      zoomOut();
      selectTool(toolSel);
    }

    public void keyPress(object Sender,KeyPressEventArgs e) {
      if(e.KeyChar=='1') {
        lineTool.PerformClick();
      }
      if(e.KeyChar=='2') {
        nodeTool.PerformClick();
      }
      if(e.KeyChar=='3') {
        nConTool.PerformClick();
      }
      if(e.KeyChar=='4') {
        deleTool.PerformClick();
      }
      if(e.KeyChar=='-') {
        zoomOutBut.PerformClick();
      }
      if(e.KeyChar=='=') {
        zoomInBut.PerformClick();
      }
      if(e.KeyChar==(char)(27)) {
        clickStage=0;
        selectTool(toolSel);
      }
    }
  }
}
