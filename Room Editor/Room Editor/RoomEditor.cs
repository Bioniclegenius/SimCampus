using System;
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
    Button lineTool;
    Button nodeTool;
    Button nConTool;
    Button DelTool;
    Button ZoomIn;
    Button ZoomOut;
    bool clickStage;
    PointF clickC;
    int toolSel;
    Room r;
    //We need to move the room edit buttons to this panel, since this panel
    //should be controlling everything about room editting.
    //Furthermore, floor editting and so on will have different sets of buttons.
    //Things need to be localized.
    //As further reason, this class needs to be able to read what button is
    //selected, and adjust as necessary. Therefore...
    //
    //This also allows us to put a keyboard listener in here, as opposed to on
    //the form itself. I'm all for making things less global. Means less work on
    //the form and easier switching between different editors, since they handle
    //everything necessary for themselves on their own.
    public RoomEditor(int x,int y,int w,int h) {
      this.Location=new Point(x,y);
      this.Width=w;
      this.Height=h;
      this.DoubleBuffered=true;
      this.Paint+=new PaintEventHandler(this.paintEvent);
      this.MouseMove+=new MouseEventHandler(this.mouseMove);
      this.MouseClick+=new MouseEventHandler(this.mouseClick);

      #region buttons
      lineTool=new Button();
      lineTool.Location=new Point(0,0);
      lineTool.Size=new Size(32,32);
      lineTool.Image=Image.FromFile("linetool.png");
      this.Controls.Add(lineTool);

      nodeTool=new Button();
      nodeTool.Location=new Point(32,0);
      nodeTool.Size=new Size(32,32);
      nodeTool.Image=Image.FromFile("linetool.png");
      this.Controls.Add(nodeTool);
      #endregion

      clickStage=false;
      toolSel=1;
      mx=this.Width/2;
      my=this.Height/2;
      cx=0;
      cy=0;
      zoom=1;
      clickC=new PointF();
      r=new Room("test");
      Invalidate();
      lineTool.PerformClick();
    }

    private void mouseMove(Object sender,MouseEventArgs e) {
      mouseCalc(e.Location.X,e.Location.Y);
    }

    public void mouseCalc(int mousex,int mousey) {
      mx=(mousex-this.Width/2)/zoom/BARSPACE;
      my=(this.Height/2-mousey)/zoom/BARSPACE;
      snapTo();
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

    public void moveRight(){
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

    public void mouseClick(Object sender,MouseEventArgs e) {
      if(toolSel==1) {
        if(!clickStage) {
          clickStage=true;
          clickC=new PointF(mx,my);
        }
        else {
          r.addLine(clickC.X,clickC.Y,mx,my);
          r.saveFile();
          clickStage=false;
        }
      }
    }

    public int toScreenW(float num) {
      int goal=(int)(this.Width/2+num*zoom*BARSPACE+.5);
      return goal;
    }

    public int toScreenH(float num) {
      int goal=(int)(this.Height/2-num*zoom*BARSPACE+.5);
      return goal;
    }

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
      g.FillEllipse(b,toScreenW(mx)-3,toScreenH(my)-3,6,6);//mouse locator

      //Draw Room
      b.Color=Color.FromArgb(255,64,64);
      Pen p=new Pen(b.Color);
      p.Width=2;
      for(int x=0;x<r.lines.Count;x++) {
        g.DrawLine(p,toScreenW(r.lines[x][0].X),toScreenH(r.lines[x][0].Y),
                                    toScreenW(r.lines[x][1].X),toScreenH(r.lines[x][1].Y));
      }

      //Extra Renderings

      if(toolSel==1&&clickStage) {
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


      Invalidate();
    }
  }
}
