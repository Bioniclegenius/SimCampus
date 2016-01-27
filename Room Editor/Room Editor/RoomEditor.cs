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
      mx=this.Width/2;
      my=this.Height/2;
      cx=0;
      cy=0;
      zoom=1;
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