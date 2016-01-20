using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Room_Editor {
  public class RenderPanel:Panel {

    float cx,cy,zoom;
    float mx,my;
    const int BARSPACE=20;

    public RenderPanel(int x,int y,int w,int h) {
      this.Location=new Point(x,y);
      this.Width=w;
      this.Height=h;
      this.DoubleBuffered=true;
      this.Paint+=new PaintEventHandler(this.paintEvent);
      this.MouseMove+=new MouseEventHandler(this.mouseMove);
      mx=this.Width/2;
      my=this.Height/2;
      cx=0;
      cy=0;
      zoom=2;
      Invalidate();
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
      mx-=mx-(int)((mx/(1f/zoom)))*1f/zoom;
      /*if(mx>=0) {
        float mxC=mx-(int)((mx/(1f/zoom)))*1f/zoom;
        mxC*=zoom;
        if(mxC<1f/(zoom)) {
          mx-=mxC/zoom;
        }
        else
          mx+=1/zoom-mxC/zoom;
      }
      if(my>=0) {
        float myC=my-(int)((my/(1f/zoom)))*1f/zoom;
        myC*=zoom;
        if(myC<1f/(zoom)) {
          my-=myC/zoom;
        }
        else
          my+=1f/zoom-myC/zoom;
      }*/
    }

    public void zoomIn() {
      if(zoom<16)
        zoom*=2;
    }

    public void zoomOut() {
      if(zoom>.0625)
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

    public void paintEvent(Object sender,PaintEventArgs e) {
      Graphics g=e.Graphics;
      SolidBrush b=new SolidBrush(Color.FromArgb(0,0,0));
      g.FillRectangle(b,0,0,this.Width,this.Height);//Background Filling

      int zoompoint=1;
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
      g.FillEllipse(b,this.Width/2+mx*zoom*BARSPACE-3,this.Height/2-my*zoom*BARSPACE-3,6,6);

      b.Color=Color.FromArgb(160,160,160);//Coordinate Display

      g.FillRectangle(b,0,this.Height-33,129,33);//Border
      b.Color=Color.FromArgb(15,15,15);
      g.FillRectangle(b,0,this.Height-32,128,32);//Internal Box

      Font f=new Font("Arial",16);//Coordinate Drawing
      b.Color=Color.FromArgb(160,160,160);
      g.DrawString(Convert.ToString(mx)+","+Convert.ToString(my),f,b,new PointF(2,this.Height-30));


      Invalidate();
    }
  }
}
