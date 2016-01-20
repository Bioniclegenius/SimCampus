namespace Room_Editor {
  partial class Form1 {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components=null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if(disposing&&(components!=null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.LineTool = new System.Windows.Forms.Button();
      this.NodeTool = new System.Windows.Forms.Button();
      this.NodeConnTool = new System.Windows.Forms.Button();
      this.DelTool = new System.Windows.Forms.Button();
      this.ZoomIn = new System.Windows.Forms.Button();
      this.ZoomOut = new System.Windows.Forms.Button();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.roomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.floorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.buildingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.campusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.roomToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.floorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.buildingToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.campusToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.reCenterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // LineTool
      // 
      this.LineTool.Location = new System.Drawing.Point(0, 24);
      this.LineTool.Margin = new System.Windows.Forms.Padding(0);
      this.LineTool.Name = "LineTool";
      this.LineTool.Size = new System.Drawing.Size(32, 32);
      this.LineTool.TabIndex = 0;
      this.LineTool.Text = "/";
      this.LineTool.UseVisualStyleBackColor = true;
      // 
      // NodeTool
      // 
      this.NodeTool.Location = new System.Drawing.Point(32, 24);
      this.NodeTool.Margin = new System.Windows.Forms.Padding(0);
      this.NodeTool.Name = "NodeTool";
      this.NodeTool.Size = new System.Drawing.Size(32, 32);
      this.NodeTool.TabIndex = 1;
      this.NodeTool.Text = "O";
      this.NodeTool.UseVisualStyleBackColor = true;
      this.NodeTool.Click += new System.EventHandler(this.NodeTool_Click);
      // 
      // NodeConnTool
      // 
      this.NodeConnTool.Location = new System.Drawing.Point(64, 24);
      this.NodeConnTool.Margin = new System.Windows.Forms.Padding(0);
      this.NodeConnTool.Name = "NodeConnTool";
      this.NodeConnTool.Size = new System.Drawing.Size(32, 32);
      this.NodeConnTool.TabIndex = 2;
      this.NodeConnTool.Text = "O/";
      this.NodeConnTool.UseVisualStyleBackColor = true;
      // 
      // DelTool
      // 
      this.DelTool.Location = new System.Drawing.Point(96, 24);
      this.DelTool.Margin = new System.Windows.Forms.Padding(0);
      this.DelTool.Name = "DelTool";
      this.DelTool.Size = new System.Drawing.Size(32, 32);
      this.DelTool.TabIndex = 3;
      this.DelTool.Text = "X";
      this.DelTool.UseVisualStyleBackColor = true;
      // 
      // ZoomIn
      // 
      this.ZoomIn.Location = new System.Drawing.Point(751, 24);
      this.ZoomIn.Margin = new System.Windows.Forms.Padding(0);
      this.ZoomIn.Name = "ZoomIn";
      this.ZoomIn.Size = new System.Drawing.Size(32, 32);
      this.ZoomIn.TabIndex = 4;
      this.ZoomIn.Text = "+";
      this.ZoomIn.UseVisualStyleBackColor = true;
      // 
      // ZoomOut
      // 
      this.ZoomOut.Location = new System.Drawing.Point(719, 24);
      this.ZoomOut.Margin = new System.Windows.Forms.Padding(0);
      this.ZoomOut.Name = "ZoomOut";
      this.ZoomOut.Size = new System.Drawing.Size(32, 32);
      this.ZoomOut.TabIndex = 5;
      this.ZoomOut.Text = "-";
      this.ZoomOut.UseVisualStyleBackColor = true;
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.editToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
      this.menuStrip1.Size = new System.Drawing.Size(784, 24);
      this.menuStrip1.TabIndex = 6;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator2,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.quitToolStripMenuItem});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 24);
      this.fileToolStripMenuItem.Text = "File";
      // 
      // viewToolStripMenuItem
      // 
      this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reCenterToolStripMenuItem});
      this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
      this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
      this.viewToolStripMenuItem.Text = "View";
      // 
      // editToolStripMenuItem
      // 
      this.editToolStripMenuItem.Name = "editToolStripMenuItem";
      this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 24);
      this.editToolStripMenuItem.Text = "Edit";
      // 
      // openToolStripMenuItem
      // 
      this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.roomToolStripMenuItem,
            this.floorToolStripMenuItem,
            this.buildingToolStripMenuItem,
            this.campusToolStripMenuItem});
      this.openToolStripMenuItem.Name = "openToolStripMenuItem";
      this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.openToolStripMenuItem.Text = "Open";
      // 
      // roomToolStripMenuItem
      // 
      this.roomToolStripMenuItem.Name = "roomToolStripMenuItem";
      this.roomToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.roomToolStripMenuItem.Text = "Room";
      // 
      // floorToolStripMenuItem
      // 
      this.floorToolStripMenuItem.Name = "floorToolStripMenuItem";
      this.floorToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.floorToolStripMenuItem.Text = "Floor";
      // 
      // buildingToolStripMenuItem
      // 
      this.buildingToolStripMenuItem.Name = "buildingToolStripMenuItem";
      this.buildingToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.buildingToolStripMenuItem.Text = "Building";
      // 
      // campusToolStripMenuItem
      // 
      this.campusToolStripMenuItem.Name = "campusToolStripMenuItem";
      this.campusToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.campusToolStripMenuItem.Text = "Campus";
      // 
      // newToolStripMenuItem
      // 
      this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.roomToolStripMenuItem1,
            this.floorToolStripMenuItem1,
            this.buildingToolStripMenuItem1,
            this.campusToolStripMenuItem1});
      this.newToolStripMenuItem.Name = "newToolStripMenuItem";
      this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.newToolStripMenuItem.Text = "New";
      // 
      // roomToolStripMenuItem1
      // 
      this.roomToolStripMenuItem1.Name = "roomToolStripMenuItem1";
      this.roomToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
      this.roomToolStripMenuItem1.Text = "Room";
      // 
      // floorToolStripMenuItem1
      // 
      this.floorToolStripMenuItem1.Name = "floorToolStripMenuItem1";
      this.floorToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
      this.floorToolStripMenuItem1.Text = "Floor";
      // 
      // buildingToolStripMenuItem1
      // 
      this.buildingToolStripMenuItem1.Name = "buildingToolStripMenuItem1";
      this.buildingToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
      this.buildingToolStripMenuItem1.Text = "Building";
      // 
      // campusToolStripMenuItem1
      // 
      this.campusToolStripMenuItem1.Name = "campusToolStripMenuItem1";
      this.campusToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
      this.campusToolStripMenuItem1.Text = "Campus";
      // 
      // saveToolStripMenuItem
      // 
      this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
      this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.saveToolStripMenuItem.Text = "Save";
      // 
      // saveAsToolStripMenuItem
      // 
      this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
      this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.saveAsToolStripMenuItem.Text = "Save As";
      // 
      // reCenterToolStripMenuItem
      // 
      this.reCenterToolStripMenuItem.Name = "reCenterToolStripMenuItem";
      this.reCenterToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.reCenterToolStripMenuItem.Text = "Re-Center";
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
      // 
      // quitToolStripMenuItem
      // 
      this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
      this.quitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.quitToolStripMenuItem.Text = "Quit";
      this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(784, 561);
      this.Controls.Add(this.ZoomOut);
      this.Controls.Add(this.ZoomIn);
      this.Controls.Add(this.DelTool);
      this.Controls.Add(this.NodeConnTool);
      this.Controls.Add(this.NodeTool);
      this.Controls.Add(this.LineTool);
      this.Controls.Add(this.menuStrip1);
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button LineTool;
    private System.Windows.Forms.Button NodeTool;
    private System.Windows.Forms.Button NodeConnTool;
    private System.Windows.Forms.Button DelTool;
    private System.Windows.Forms.Button ZoomIn;
    private System.Windows.Forms.Button ZoomOut;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem roomToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem floorToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem buildingToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem campusToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem roomToolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem floorToolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem buildingToolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem campusToolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem reCenterToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
  }
}

