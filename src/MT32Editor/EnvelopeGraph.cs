namespace MT32Edit;

/// <summary>
/// Plot graphs to represent MT-32 pitch, filter and amplitude envelopes
/// </summary>
internal class EnvelopeGraph
{
    // MT32Edit: EnvelopeGraph Class
    // S.Fryers May 2024

    public const int PITCH_GRAPH = 0;
    public const int TVF_GRAPH = 1;
    public const int TVA_GRAPH = 2;

    //left edge of graph box
    private readonly int xStart;

    //top edge of graph box
    private readonly int yStart;

    //width of graph box
    private readonly int xWidth;

    //height of graph box
    private readonly int yHeight;

    //midpoint of y-axis
    private readonly int yMid;

    private readonly Pen yellowPen = new Pen(Color.Orange, 2);
    private readonly Pen bluePen = new Pen(Color.LightBlue, 2);
    private readonly Pen redPen = new Pen(Color.Red, 2);
    private readonly Pen contrastPen = new Pen(Color.DarkGray, 1);
    private readonly Pen greyPen = new Pen(Color.LightGray, 2);

    private readonly SolidBrush brush = new SolidBrush(Color.FromArgb(32, 32, 32));
    private readonly Font font = new Font("Segoe UI", 8, FontStyle.Regular);

    // Time (x) axis values
    private int[,] T = new int[6, 4];
    private int[] TSus = new int[4];

    // Level (y) axis values
    private int[,] L = new int[5, 4];
    private int[] LSus = new int[4];
    private int[] LRel = new int[4];

    public EnvelopeGraph(int xPos, int yPos, int xSize, int ySize)
    {
        xStart = xPos;
        yStart = yPos;
        xWidth = xSize;
        yHeight = ySize;
        yMid = yHeight / 2;
    }

    /// <summary>
    /// Draws a Pitch, TVA or TVF envelope graph illustrating the current timbre settings.
    /// </summary>
    public void Plot(Graphics envelope, TimbreStructure timbre, int graphType, int activePartial, bool drawAllPartials = false, bool showLabels = false)
    {
        if (UITools.DarkMode)
        {
            greyPen.Color = Color.Gray;
            yellowPen.Color = Color.Yellow;
            contrastPen.Color = Color.White;
            brush.Color = Color.White;
        }

        envelope.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        for (int partial = 0; partial < 4; partial++)
        {
            if (timbre.GetPartialMuteStatus()[partial])
            {
                //don't draw muted partials
                continue;
            }
            else if (partial == activePartial)
            {
                //don't draw active partial yet
                continue;
            }
            else if (!drawAllPartials)
            {
                //don't draw partials unless drawAllPartials is true
                continue;
            }

            //draw background partial
            DrawEnvelope(envelope, timbre, graphType, partial, highlight: false, label: false);
        }
        if (timbre.GetPartialMuteStatus()[activePartial])
        {
            //don't draw muted active partial
            return;
        }

        //draw active partial last
        DrawEnvelope(envelope, timbre, graphType, activePartial, highlight: true, label: showLabels);

        void DrawEnvelope(Graphics envelope, TimbreStructure timbre, int graphType, int partial, bool highlight, bool label)
        {
            switch (graphType)
            {
                case PITCH_GRAPH:
                    DrawPitchEnvelope(envelope, timbre, partial, highlight, label);
                    break;

                case TVF_GRAPH:
                    DrawTVFEnvelope(envelope, timbre, partial, highlight, label);
                    break;

                case TVA_GRAPH:
                    DrawTVAEnvelope(envelope, timbre, partial, highlight, label);
                    break;

                default:
                    break;
            }
        }
    }

    private void DrawPitchEnvelope(Graphics envelope, TimbreStructure timbre, int partial, bool highlight, bool label)
    {
        SetTimeValues(partial, timbre.GetUIParameter(partial, 0x0B), timbre.GetUIParameter(partial, 0x0C), timbre.GetUIParameter(partial, 0x0D), timbre.GetUIParameter(partial, 0x0E), 0, 0);
        SetLevelValues(partial, timbre.GetUIParameter(partial, 0x0F), timbre.GetUIParameter(partial, 0x10), timbre.GetUIParameter(partial, 0x11), 0, timbre.GetUIParameter(partial, 0x12), timbre.GetUIParameter(partial, 0x13));
        PlotPitchGraph(envelope, partial, highlight);
        if (label)
        {
            DrawPitchLabels(envelope, partial);
        }
    }

    private void DrawTVAEnvelope(Graphics envelope, TimbreStructure timbre, int partial, bool highlight, bool label)
    {
        SetTimeValues(partial, timbre.GetUIParameter(partial, 0x31), timbre.GetUIParameter(partial, 0x32), timbre.GetUIParameter(partial, 0x33), timbre.GetUIParameter(partial, 0x34), timbre.GetUIParameter(partial, 0x35), 0);
        SetLevelValues(partial, 0, timbre.GetUIParameter(partial, 0x36), timbre.GetUIParameter(partial, 0x37), timbre.GetUIParameter(partial, 0x38), timbre.GetUIParameter(partial, 0x39), 0);
        PlotTVATVFGraph(envelope, partial, highlight);
        if (label)
        {
            DrawTVATVFLabels(envelope, partial);
        }
    }

    private void DrawTVFEnvelope(Graphics envelope, TimbreStructure timbre, int partial, bool highlight, bool label)
    {
        SetTimeValues(partial, timbre.GetUIParameter(partial, 0x20), timbre.GetUIParameter(partial, 0x21), timbre.GetUIParameter(partial, 0x22), timbre.GetUIParameter(partial, 0x23), timbre.GetUIParameter(partial, 0x24), 0);
        SetLevelValues(partial, 0, timbre.GetUIParameter(partial, 0x25), timbre.GetUIParameter(partial, 0x26), timbre.GetUIParameter(partial, 0x27), timbre.GetUIParameter(partial, 0x28), 0);
        PlotTVATVFGraph(envelope, partial, highlight);
        if (label)
        {
            DrawTVATVFLabels(envelope, partial);
        }
    }

    private void DrawPitchLabels(Graphics envelope, int partial)
    {
        int p = partial;
        envelope.DrawString("L0", font, brush, xStart - 15, yStart + (yMid - L[0, p]) - 7, StringFormat.GenericTypographic);
        envelope.DrawString("L1", font, brush, xStart + T[1, p] - 5, yStart + (yMid - L[1, p]) - 20, StringFormat.GenericTypographic);
        envelope.DrawString("L2", font, brush, xStart + T[2, p] - 5, yStart + (yMid - L[2, p]) - 20, StringFormat.GenericTypographic);
        envelope.DrawString("Sustain", font, brush, xStart + TSus[p] - 48, yStart + (yMid - LSus[p]) - 20, StringFormat.GenericTypographic);
        envelope.DrawString("Release", font, brush, xStart + T[4, p] - 5, yStart + (yMid - LRel[p]) - 20, StringFormat.GenericTypographic);
        envelope.DrawString("T1", font, brush, xStart + T[1, p] - 5, yStart + yMid + 5, StringFormat.GenericTypographic);
        envelope.DrawString("T2", font, brush, xStart + T[2, p] - 5, yStart + yMid + 5, StringFormat.GenericTypographic);
        envelope.DrawString("T3", font, brush, xStart + T[3, p] - 5, yStart + yMid + 5, StringFormat.GenericTypographic);
        envelope.DrawString("T4", font, brush, xStart + T[4, p] - 5, yStart + yMid + 5, StringFormat.GenericTypographic);
    }

    private void DrawTVATVFLabels(Graphics envelope, int partial)
    {
        int p = partial;
        envelope.DrawString("L1", font, brush, xStart + T[1, p] - 5, yStart + (yHeight - L[1, p]) - 20, StringFormat.GenericTypographic);
        envelope.DrawString("L2", font, brush, xStart + T[2, p] - 5, yStart + (yHeight - L[2, p]) - 20, StringFormat.GenericTypographic);
        envelope.DrawString("L3", font, brush, xStart + T[3, p] - 5, yStart + (yHeight - L[3, p]) - 20, StringFormat.GenericTypographic);
        envelope.DrawString("Sustain", font, brush, xStart + TSus[p] - 38, yStart + (yHeight - LSus[p]) - 20, StringFormat.GenericTypographic);
        envelope.DrawString("T1", font, brush, xStart + T[1, p] - 5, yStart + yHeight + 5, StringFormat.GenericTypographic);
        envelope.DrawString("T2", font, brush, xStart + T[2, p] - 5, yStart + yHeight + 5, StringFormat.GenericTypographic);
        envelope.DrawString("T3", font, brush, xStart + T[3, p] - 5, yStart + yHeight + 5, StringFormat.GenericTypographic);
        envelope.DrawString("T4", font, brush, xStart + T[4, p] - 5, yStart + yHeight + 5, StringFormat.GenericTypographic);
        envelope.DrawString("T5", font, brush, xStart + T[5, p] - 5, yStart + yHeight + 5, StringFormat.GenericTypographic);
    }

    private void PlotTVATVFGraph(Graphics envelope, int partial, bool highlight)
    {
        int p = partial;
        T[1, p] = T[1, p] * (xWidth / 6) / 100;
        T[2, p] = T[1, p] + T[2, p] * (xWidth / 6) / 100;
        T[3, p] = T[2, p] + T[3, p] * (xWidth / 6) / 100;
        T[4, p] = T[3, p] + T[4, p] * (xWidth / 6) / 100;
        TSus[p] = T[4, p] + (xWidth / 6);
        T[5, p] = TSus[p] + T[5, p] * (xWidth / 6) / 100;

        Pen env = greyPen;
        Pen sust = greyPen;

        //only draw axes and vertical gridlines for the highlighted partial
        if (highlight)
        {
            env = yellowPen;
            sust = bluePen; 
            envelope.DrawLine(contrastPen, xStart, yStart + yHeight, xStart + xWidth, yStart + yHeight);                            //draw x-axis
            envelope.DrawLine(contrastPen, xStart, yStart, xStart, yStart + yHeight);                                               //draw y-axis
            envelope.DrawLine(contrastPen, xStart + T[1, p], yStart + yHeight, xStart + T[1, p], yStart + (yHeight - L[1, p]));     //draw L1 vertical
            envelope.DrawLine(contrastPen, xStart + T[2, p], yStart + yHeight, xStart + T[2, p], yStart + (yHeight - L[2, p]));     //draw L2 vertical
            envelope.DrawLine(contrastPen, xStart + T[3, p], yStart + yHeight, xStart + T[3, p], yStart + (yHeight - L[3, p]));     //draw L3 vertical
            envelope.DrawLine(contrastPen, xStart + T[4, p], yStart + yHeight, xStart + T[4, p], yStart + (yHeight - LSus[p]));     //draw L4 vertical
            envelope.DrawLine(contrastPen, xStart + TSus[p], yStart + yHeight, xStart + TSus[p], yStart + (yHeight - LSus[p]));     //draw key off vertical
        }

        //plot envelope
        envelope.DrawLine(env, xStart, yStart + yHeight, xStart + T[1, p], yStart + (yHeight - L[1, p]));                           //draw start to T1/L1
        envelope.DrawLine(env, xStart + T[1, p], yStart + (yHeight - L[1, p]), xStart + T[2, p], yStart + (yHeight - L[2, p]));     //draw T1/L1 to T2/L2
        envelope.DrawLine(env, xStart + T[2, p], yStart + (yHeight - L[2, p]), xStart + T[3, p], yStart + (yHeight - L[3, p]));     //draw T2/L2 to T3/T4
        envelope.DrawLine(env, xStart + T[3, p], yStart + (yHeight - L[3, p]), xStart + T[4, p], yStart + (yHeight - LSus[p]));     //draw T3/L3 to T4/Sustain
        envelope.DrawLine(sust, xStart + T[4, p], yStart + (yHeight - LSus[p]), xStart + TSus[p], yStart + (yHeight - LSus[p]));    //draw Sust horizontal
        envelope.DrawLine(env, xStart + TSus[p], yStart + (yHeight - LSus[p]), xStart + T[5, p], yStart + yHeight);                 //draw Sust/T5 to End
    }

    private void PlotPitchGraph(Graphics envelope, int partial, bool highlight)
    {
        int p = partial;
        T[1, p] = (T[1, p] * (xWidth / 5)) / 100;
        T[2, p] = T[1, p] + T[2, p] * (xWidth / 5) / 100;
        T[3, p] = T[2, p] + T[3, p] * (xWidth / 5) / 100;
        TSus[p] = T[3, p] + (xWidth / 5);
        T[4, p] = TSus[p] + T[4, p] * (xWidth / 5) / 100;

        Pen env = greyPen;
        Pen sust = greyPen;
        Pen rel = greyPen;

        //only draw axes and vertical gridlines for the highlighted partial
        if (highlight)
        {
            env = yellowPen;
            sust = bluePen;
            rel = redPen;
            envelope.DrawLine(contrastPen, xStart, yStart + yMid, xStart + xWidth, yStart + yMid);                    		//draw x-axis
            envelope.DrawLine(contrastPen, xStart, yStart, xStart, yStart + yHeight);                                       //draw y-axis
            envelope.DrawLine(contrastPen, xStart, yStart + yMid, xStart, yStart + (yMid - L[0, p]));                       //draw L0 vertical
            envelope.DrawLine(contrastPen, xStart + T[1, p], yStart + yMid, xStart + T[1, p], yStart + (yMid - L[1, p]));   //draw L1 vertical
            envelope.DrawLine(contrastPen, xStart + T[2, p], yStart + yMid, xStart + T[2, p], yStart + (yMid - L[2, p]));   //draw L2 vertical
            envelope.DrawLine(contrastPen, xStart + T[3, p], yStart + yMid, xStart + T[3, p], yStart + (yMid - LSus[p]));   //draw Sust vertical
            envelope.DrawLine(contrastPen, xStart + TSus[p], yStart + yMid, xStart + TSus[p], yStart + (yMid - LSus[p]));   //draw key off vertical
            envelope.DrawLine(contrastPen, xStart + T[4, p], yStart + yMid, xStart + T[4, p], yStart + (yMid - LRel[p]));   //draw release vertical
        }

        //plot envelope
        envelope.DrawLine(env, xStart, yStart + (yMid - L[0, p]), xStart + T[1, p], yStart + (yMid - L[1, p]));             //draw L0 to T1/L1
        envelope.DrawLine(env, xStart + T[1, p], yStart + (yMid - L[1, p]), xStart + T[2, p], yStart + (yMid - L[2, p]));   //draw T1/L1 to T2/L2
        envelope.DrawLine(env, xStart + T[2, p], yStart + (yMid - L[2, p]), xStart + T[3, p], yStart + (yMid - LSus[p]));   //draw T2/L2 to T3/Sust. L
        envelope.DrawLine(sust, xStart + T[3, p], yStart + (yMid - LSus[p]), xStart + TSus[p], yStart + (yMid - LSus[p]));  //draw Sust horizontal
        envelope.DrawLine(env, xStart + TSus[p], yStart + (yMid - LSus[p]), xStart + T[4, p], yStart + (yMid - LRel[p]));   //draw Sust/T4 to End
        envelope.DrawLine(rel, xStart + T[4, p], yStart + (yMid - LRel[p]), xStart + xWidth, yStart + (yMid - LRel[p]));    //draw end horizontal
    }

    private void SetTimeValues(int activePartial, int T1, int T2, int T3, int T4, int T5, int TSustain)
    {
        int p = activePartial;
        T[0, p] = 0;
        T[1, p] = T1;
        T[2, p] = T2;
        T[3, p] = T3;
        T[4, p] = T4;
        T[5, p] = T5;
        TSus[p] = TSustain;
    }

    private void SetLevelValues(int activePartial, int L0, int L1, int L2, int L3, int LSustain, int LRelease)
    {
        int p = activePartial;
        L[0, p] = L0 * yHeight / 100;
        L[1, p] = L1 * yHeight / 100;
        L[2, p] = L2 * yHeight / 100;
        L[3, p] = L3 * yHeight / 100;
        L[4, p] = 0;
        LSus[p] = LSustain * yHeight / 100;
        LRel[p] = LRelease * yHeight / 100;
    }
}