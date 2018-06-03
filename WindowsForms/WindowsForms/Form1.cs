using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        private Pen pen;
        private List<Segment> segments = new List<Segment>();
        private bool isSaved = false;
        private int x1 = -1;
        private int y1 = -1;
        private int y2 = -1;
        private int x2 = -1;

        public Form1()
        {
            InitializeComponent();
            graphics = panel.CreateGraphics();
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            pen = new Pen(Color.Black, 3);
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        private void NewToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (!isSaved) {
                var resultAnswer = MessageBox.Show("Save this file?", "Message", MessageBoxButtons.YesNo);
                if (resultAnswer == DialogResult.Yes)
                {
                    OnFileSavedClick(sender, e);
                }
            }
            panel.Invalidate();
        }

        private void OnFileSavedClick(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                FileName = "Lines",
                DefaultExt = "xml"
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                Serialization.Serialize(saveFileDialog.FileName, segments);
                isSaved = true;
            }
        }

        private void OpenToolStripMenuItemClick(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog {
                FileName = "Lines",
                DefaultExt = "xml"
            };
            if (openFile.ShowDialog() == DialogResult.OK) {
                panel.Refresh();
                segments.Clear();
                segments = Serialization.Deserialize(openFile.FileName);
                foreach (var i in segments)
                {
                    pen.Color = ColorTranslator.FromHtml(i.Color);
                    graphics.DrawLine(pen, new Point(i.X1, i.Y1), new Point(i.X2, i.Y2));
                }
            }
        }

        private void BlackToolStripMenuItemClick(object sender, EventArgs e)
        {
            pen = new Pen(Color.Black, 3);
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            x1 = e.X;
            y1 = e.Y;
            panel.Cursor = Cursors.Cross;
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            x2 = e.X;
            y2 = e.Y;
            graphics.DrawLine(pen, new Point(x1, y1), new Point(x2, y2));
            segments.Add(new Segment(x1, y1, x2, y2, ColorTranslator.ToHtml(pen.Color)));
            panel.Cursor = Cursors.Default;
            isSaved &= false;
        }
        private void YellowToolStripMenuItemClick(object sender, EventArgs e)
        {
            pen = new Pen(Color.Yellow, 3);
        }

        private void RedToolStripMenuItemClick(object sender, EventArgs e)
        {
            pen = new Pen(Color.Red, 3);
        }

        private void BlueToolStripMenuItemClick(object sender, EventArgs e)
        {
            pen = new Pen(Color.Blue, 3);
        }

        private void GreenToolStripMenuItemClick(object sender, EventArgs e)
        {
            pen = new Pen(Color.Green, 3);
        }

        private void onMouseMove(object sender, MouseEventArgs e) { }

        private void ColorToolStripMenuItem_Click(object sender, EventArgs e) { }

        private void Draw(object sender, PaintEventArgs e) { }

        private void toolStripComboBox1_Click(object sender, EventArgs e) { }
    }
}
