using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using C1.Win.C1Tile;
using ImageGalleryDemo3.Properties;
using C1.C1Pdf;
using System.Drawing.Text;
using System.Windows.Forms.VisualStyles;
using C1.Win.C1ScrollBar;

namespace ImageGalleryDemo3
{
    public partial class ImageGallery : Form
    {

        DataFetcher datafetch = new DataFetcher();
        List<ImageItem> imagesList;
        int checkedItems = 0;

        // private TextBox txtBox = new TextBox();
        // private Button btnAdd = new Button();
        // private ListBox lstBox = new ListBox();
        // private CheckBox chkBox = new CheckBox();
        //private Label lblCount = new Label();
        private SplitContainer splitContainer1 = new SplitContainer();
        private TableLayoutPanel tableLayoutPanel1=new TableLayoutPanel();
        private Panel panel1 = new Panel();
        private TextBox _searchBox = new TextBox();
        private Panel panel2 = new Panel();
        private PictureBox _search = new PictureBox();
        private Panel panel3 = new Panel();
        private PictureBox _exportImage = new PictureBox();
        private C1TileControl _imageTileControl=new C1TileControl();
        private Group group1 = new Group();
        private Tile tile1 = new Tile();
        private Tile tile2 = new Tile();
        private Tile tile3 = new Tile();
        private Tile tile4 = new Tile();
        private Tile tile5 = new Tile();
        private Tile tile6 = new Tile();
        private Tile tile7 = new Tile();
        private Tile tile8 = new Tile();
        private Tile tile9 = new Tile();
        private Tile tile10 = new Tile();
        private StatusStrip statusStrip1 = new StatusStrip();
        private ToolStripProgressBar toolStripProgressBar1 = new ToolStripProgressBar();
        private PanelElement panelElement1=new PanelElement();
        private ImageElement imageElement1= new ImageElement();
        private TextElement textElement1=new TextElement();
        private C1PdfDocument imagePdfDocument = new C1PdfDocument();
        private C1HScrollBar hScroll = new C1HScrollBar();
        public ImageGallery()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Set up the form.


            // 
            // ImageGallery
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(764, 749);
            this.Controls.Add(this.splitContainer1);
            //this.Controls.Add(this.hScroll);
            this.MaximumSize = new Size(810, 810);
            this.MinimizeBox = true;
            this.MaximizeBox = true;
            this.Name = "ImageGallery";
            this.ShowIcon = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Image Gallery";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((ISupportInitialize)(this._search)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((ISupportInitialize)(this._exportImage)).EndInit();
            this.ResumeLayout(false);

            //Format controls. Note: Controls inherit color from parent form.

           /* this.hScroll.Dock = DockStyle.Bottom;
            this.hScroll.Height = 17;
            this.hScroll.Width = 750;
            this.hScroll.Minimum = 0;
            this.hScroll.Maximum = 100;*/

            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = DockStyle.Fill;
            this.splitContainer1.FixedPanel = FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new Point(0, 0);
            this.splitContainer1.Margin = new Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.statusStrip1);
            this.splitContainer1.Panel2.Controls.Add(this._imageTileControl);
            //this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Size = new System.Drawing.Size(764, 749);
            this.splitContainer1.SplitterDistance = 40;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.5F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(764, 40);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._searchBox);
            this.panel1.Dock = DockStyle.Fill;
            this.panel1.Location = new Point(194, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(280, 34);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new PaintEventHandler(this.panel1_Paint);
            // 
            // _searchBox
            // 
            this._searchBox.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom)
            | AnchorStyles.Left)
            | AnchorStyles.Right)));
            this._searchBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._searchBox.Location = new System.Drawing.Point(16, 9);
            this._searchBox.Name = "_searchBox";
            this._searchBox.Size = new System.Drawing.Size(244, 13);
            this._searchBox.TabIndex = 0;
            this._searchBox.Text = "Search Image";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this._search);
            this.panel2.Location = new System.Drawing.Point(479, 12);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 12, 45, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(40, 16);
            this.panel2.TabIndex = 1;
            // 
            // _search
            // 
            void LoadNewPict()
            {
                _search.Image = Image.FromFile(@"C:\Users\ROHAN\source\repos\ImageGalleryDemo3\ImageGalleryDemo3\resources\download.png");
            }
            LoadNewPict();
            this._search.Anchor = ((AnchorStyles)((((AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | AnchorStyles.Left)
            | AnchorStyles.Right)));
            //this._search.Image = ((System.Drawing.Image)(resources.GetObject("_search.Image")));
            this._search.Cursor = Cursors.Hand;
            this._search.Location = new System.Drawing.Point(4, 1);
            this._search.Margin = new System.Windows.Forms.Padding(0);
            this._search.Name = "_search";
            this._search.Size = new System.Drawing.Size(40, 16);
            this._search.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._search.TabIndex = 0;
            this._search.TabStop = false;
            this._search.Click += new System.EventHandler(this.Search_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new ToolStripItem[] {
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new Point(0, 683);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new Size(764, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.Visible = false;
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new Size(100, 16);
            this.toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
            // 
            // _imageTileControl
            // 
            this._imageTileControl.AllowChecking = true;
            this._imageTileControl.AllowRearranging = true;
            this._imageTileControl.CellHeight = 78;
            this._imageTileControl.CellSpacing = 11;
            this._imageTileControl.CellWidth = 78;
            // 
            // 
            // 
            panelElement1.Alignment = System.Drawing.ContentAlignment.BottomLeft;
            panelElement1.Children.Add(imageElement1);
            panelElement1.Children.Add(textElement1);
            panelElement1.Margin = new Padding(10, 6, 10, 6);
            this._imageTileControl.DefaultTemplate.Elements.Add(panelElement1);
            this._imageTileControl.Dock = DockStyle.Fill;
            this._imageTileControl.Groups.Add(this.group1);
            this._imageTileControl.Location = new Point(0, 0);
            this._imageTileControl.Name = "_imageTileControl";
            this._imageTileControl.Size = new Size(764, 705);
            this._imageTileControl.SurfacePadding = new Padding(12, 4, 12, 4);
            this._imageTileControl.SwipeDistance = 20;
            this._imageTileControl.SwipeRearrangeDistance = 98;
            this._imageTileControl.TabIndex = 3;
            this._imageTileControl.TileChecked += new EventHandler<C1.Win.C1Tile.TileEventArgs>(this._imageTileControl_TileChecked);
            this._imageTileControl.TileUnchecked += new EventHandler<C1.Win.C1Tile.TileEventArgs>(this._imageTileControl_TileUnchecked);
            this._imageTileControl.Paint += new PaintEventHandler(this._imageTileControl_Paint);
            // 
            // group1
            // 
            this.group1.Name = "group1";
            this.group1.Text = "Images";
            this.group1.Tiles.Add(this.tile1);
            this.group1.Tiles.Add(this.tile2);
            this.group1.Tiles.Add(this.tile3);
            this.group1.Tiles.Add(this.tile4);
            this.group1.Tiles.Add(this.tile5);
            this.group1.Tiles.Add(this.tile6);
            this.group1.Tiles.Add(this.tile7);
            this.group1.Tiles.Add(this.tile8);
            this.group1.Tiles.Add(this.tile9);
            this.group1.Tiles.Add(this.tile10);

            // 
            // tile1
            // 
            this.tile1.BackColor = System.Drawing.Color.LightCoral;
            this.tile1.Name = "tile1";
            this.tile1.HorizontalSize = 3;
            this.tile1.VerticalSize = 3;
            this.tile1.Image = Image.FromFile(@"C:\Users\ROHAN\source\repos\ImageGalleryDemo3\ImageGalleryDemo3\resources\grape1.jpg");
            // 
            // tile2
            // 
            this.tile2.BackColor = System.Drawing.Color.Teal;
            this.tile2.Name = "tile2";
            this.tile2.HorizontalSize = 3;
            this.tile2.VerticalSize = 3;
            this.tile2.Image = Image.FromFile(@"C:\Users\ROHAN\source\repos\ImageGalleryDemo3\ImageGalleryDemo3\resources\grape2.jpg");
            // 
            // tile3
            // 
            this.tile3.BackColor = System.Drawing.Color.SteelBlue;
            this.tile3.Name = "tile3";
            this.tile3.HorizontalSize = 3;
            this.tile3.VerticalSize = 3;
            this.tile3.Image = Image.FromFile(@"C:\Users\ROHAN\source\repos\ImageGalleryDemo3\ImageGalleryDemo3\resources\grape3.jpg");

            //
            // tile4
            //
            this.tile4.BackColor = Color.BlanchedAlmond;
            this.tile4.Name = "tile4";
            this.tile4.HorizontalSize = 3;
            this.tile4.VerticalSize = 3;
            this.tile4.Image = Image.FromFile(@"C:\Users\ROHAN\source\repos\ImageGalleryDemo3\ImageGalleryDemo3\resources\grapes4.png");

            //
            //tile5
            //
            this.tile5.BackColor = Color.AntiqueWhite;
            this.tile5.Name = "tile5";
            this.tile5.HorizontalSize = 3;
            this.tile5.VerticalSize = 3;
            this.tile5.Image = Image.FromFile(@"C:\Users\ROHAN\source\repos\ImageGalleryDemo3\ImageGalleryDemo3\resources\grape5.jpg");

            //tile 6
            this.tile6.BackColor = Color.Black;
            this.tile6.Name = "tile6";
            this.tile6.HorizontalSize = 3;
            this.tile6.VerticalSize = 3;
            this.tile6.Image = Image.FromFile(@"C:\Users\ROHAN\source\repos\ImageGalleryDemo3\ImageGalleryDemo3\resources\grape6.jpg");

            //tile7
            this.tile7.BackColor = Color.Chocolate;
            this.tile7.Name = "tile7";
            this.tile7.HorizontalSize = 3;
            this.tile7.VerticalSize = 3;
            this.tile7.Image = Image.FromFile(@"C:\Users\ROHAN\source\repos\ImageGalleryDemo3\ImageGalleryDemo3\resources\grapefinal.jpg");
            //tile8
            this.tile8.BackColor = Color.DarkSeaGreen;
            this.tile8.Name = "tile8";
            this.tile8.HorizontalSize = 3;
            this.tile8.VerticalSize = 3;
            this.tile8.Image = Image.FromFile(@"C:\Users\ROHAN\source\repos\ImageGalleryDemo3\ImageGalleryDemo3\resources\grape8.png");
            //tile9
            this.tile9.BackColor = Color.CornflowerBlue;
            this.tile9.Name = "tile9";
            this.tile9.HorizontalSize = 3;
            this.tile9.VerticalSize = 3;
            this.tile9.Image = Image.FromFile(@"C:\Users\ROHAN\source\repos\ImageGalleryDemo3\ImageGalleryDemo3\resources\grape9.jpg");
            //tile10
            this.tile10.BackColor = Color.DarkOrchid;
            this.tile10.Name = "tile10";
            this.tile10.HorizontalSize = 3;
            this.tile10.VerticalSize = 3;
            this.tile10.Image = Image.FromFile(@"C:\Users\ROHAN\source\repos\ImageGalleryDemo3\ImageGalleryDemo3\resources\grape10.jpg");
            //
            // panel3
            // 
            this.panel3.Controls.Add(this._exportImage);
            this.panel3.Location = new System.Drawing.Point(29, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(135, 28);
            this.panel3.TabIndex = 2;
            this.panel3.Visible =true;
            // 
            // _exportImage
            // 
            void LoadNewexportPic()
            {
                this._exportImage.Image = Image.FromFile(@"C:\Users\ROHAN\source\repos\ImageGalleryDemo3\ImageGalleryDemo3\resources\export.jpg");
            }
            LoadNewexportPic();
            //this._exportImage.Image = ((System.Drawing.Image)(resources.GetObject("_exportImage.Image")));
            this._exportImage.Location = new Point(0, 0);
            this._exportImage.Name = "_exportImage";
            this._exportImage.Size = new Size(135, 28);
            this._exportImage.SizeMode = PictureBoxSizeMode.StretchImage;
            this._exportImage.Cursor = Cursors.Hand;
            this._exportImage.TabIndex = 2;
            this._exportImage.TabStop = false;
            this._exportImage.Visible = false;
            this._exportImage.Click += new EventHandler(this._exportImage_Click);
            this._exportImage.Paint += new PaintEventHandler(this._exportImage_Paint);








        }

        private void AddTiles(List<ImageItem> imageList)
        {
            _imageTileControl.Groups[0].Tiles.Clear();
            foreach (var imageitem in imageList)
            {
                Tile tile = new Tile();
                tile.HorizontalSize = 3;
                tile.VerticalSize = 3;
                _imageTileControl.Groups[0].Tiles.Add(tile);
                Image img = Image.FromStream(new MemoryStream(imageitem.Base64));
                Template tl = new Template();
                ImageElement ie = new ImageElement();
                ie.ImageLayout = ForeImageLayout.Stretch;
                tl.Elements.Add(ie);
                tile.Template = tl;
                tile.Image = img;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Rectangle r = _searchBox.Bounds;
            r.Inflate(3, 3);
            Pen p = new Pen(Color.LightGray);
            e.Graphics.DrawRectangle(p, r);
        }

        private async void Search_Click(object sender, EventArgs e)
        {
            statusStrip1.Visible = true;
            imagesList = await datafetch.GetImageDataAsync(_searchBox.Text);
            AddTiles(imagesList);
            statusStrip1.Visible = false;
        }

        private void _exportImage_Click(object sender, EventArgs e)
        {
            List<Image> images = new List<Image>();
            foreach (Tile tile in _imageTileControl.Groups[0].Tiles)
            {
                if (tile.Checked)
                {
                    images.Add(tile.Image);
                }
            }
            ConvertToPdf(images);
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.DefaultExt = "pdf";
            saveFile.Filter = "PDF files (*.pdf)|*.pdf*";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                imagePdfDocument.Save(saveFile.FileName);
            }
        }
        private void ConvertToPdf(List<Image> images)
        {
            RectangleF rect = imagePdfDocument.PageRectangle;
            bool firstPage = true;
            foreach (var selectedimg in images)
            {
                if (!firstPage)
                {
                    imagePdfDocument.NewPage();
                }
                firstPage = false;
                rect.Inflate(-72, -72);
                imagePdfDocument.DrawImage(selectedimg, rect);
            }
        }

        private void _exportImage_Paint(object sender, PaintEventArgs e)
        {
            Rectangle r = new Rectangle(_exportImage.Location.X, _exportImage.Location.Y, _exportImage.Width, _exportImage.Height);
            r.X -= 29;
            r.Y -= 3;
            r.Width--;
            r.Height--;
            Pen p = new Pen(Color.LightGray);
            e.Graphics.DrawRectangle(p, r);
            e.Graphics.DrawLine(p, new Point(0, 43), new Point(this.Width, 43));
        }

        private void _imageTileControl_TileChecked(object sender, C1.Win.C1Tile.TileEventArgs e)
        {
            checkedItems++;
            _exportImage.Visible = true;
        }

        private void _imageTileControl_TileUnchecked(object sender, C1.Win.C1Tile.TileEventArgs e)
        {
            checkedItems--;
            if(checkedItems>0)
            {
                _exportImage.Visible = true;
            }
            else
            {
                _exportImage.Visible = false;
            }
        }

        private void _imageTileControl_Paint(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Color.LightGray);
            e.Graphics.DrawLine(p, 0, 43, 800, 43);
        }
        
    }
}
