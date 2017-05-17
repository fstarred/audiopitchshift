using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PitchAndShiftAudio
{
    public partial class CustomControlListView : ListView
    {
        public CustomControlListView()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        internal void MoveSelectedListViewItem(bool moveUp)
        {
            string cache;

            ListViewItemCollection lvic = this.Items;

            if (lvic.Count > 0)
            {
                if (moveUp)
                {
                    foreach (int selIdx in this.SelectedIndices)
                    {
                        // ignore moveup of row(0)
                        if (selIdx == 0)
                            continue;

                        // move the subitems for the previous row
                        // to cache to make room for the selected row
                        for (int i = 0; i < lvic[selIdx].SubItems.Count; i++)
                        {
                            cache = lvic[selIdx - 1].SubItems[i].Text;
                            lvic[selIdx - 1].SubItems[i].Text = lvic[selIdx].SubItems[i].Text;
                            lvic[selIdx].SubItems[i].Text = cache;
                        }
                        lvic[selIdx].Selected = false;
                        lvic[selIdx - 1].Selected = true;
                    }
                }
                else
                {                    
                    // move the subitems for the next row
                    // to cache so we can move the selected row down
                    for (int idx = this.SelectedIndices.Count; --idx >= 0; )
                    {
                        int selIdx = this.SelectedIndices[idx];

                        // ignore movedown of last item
                        if (selIdx == lvic.Count - 1)
                            continue;

                        for (int i = 0; i < lvic[selIdx].SubItems.Count; i++)
                        {
                            cache = lvic[selIdx + 1].SubItems[i].Text;
                            lvic[selIdx + 1].SubItems[i].Text = lvic[selIdx].SubItems[i].Text;
                            lvic[selIdx].SubItems[i].Text = cache;
                        }
                        lvic[selIdx].Selected = false;
                        lvic[selIdx + 1].Selected = true;
                    }                    
                }
            }

            this.Refresh();
            this.Focus();
        }
    }
}
