using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace WindowsFormsApplication12
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }
        class vrag {
        public vrag(int x, int y) { vx = x; vy = y; Random r = new Random(); int p = r.Next(100); if (p > 50) { to = 1; } else { to = -1; } dead = false; eated = false; s = "#"; }
         
        public int vx { get; set; }
        public int vy { get; set; }
        public int to { get; set; }
        public int tol { get; set; }
        public bool dead { get; set; }
        public bool eated { get; set; }
        public string s { get; set; }
    }
    class story
    {
        public story(int x, int y) { sx = x; sy = y; }
        public int sx { get; set; }
        public int sy { get; set; }
        public string s { get; set; }
    }
    List<vrag> vragi = new List<vrag>();
    List<story> storys = new List<story>();
    BufferedGraphicsContext con = BufferedGraphicsManager.Current;
    BufferedGraphics bg;

    Pen a = new Pen(Color.Black, 1);
    string[] map;

    int px, py, ex, ey;
    float movex = 0f;
    int maps = 2;
    int mapsl1 = 0;
    int vector = 1;
        int hd,hd2;
        bool prig = true;
        float imove = 0;
       public int score = 0;
        int kadr = 0;
       public int vded = 0;
        bool pd = false;
        bool door = false;
        bool mapse = false;
        string line;
        bool deadd = false;
        void mapload()
        {
            vragi.Clear();
            storys.Clear();
            int x = 0;
            string k = string.Concat(Application.StartupPath, "\\map", mapsl1.ToString(), ".txt");
            label1.Text = k;
            using (StreamReader sr = new StreamReader(k, System.Text.Encoding.Default))
            {

                while ((line = sr.ReadLine()) != null)
                {
                    x++;

                }
            }

            map = new string[x];
            using (StreamReader sr = new StreamReader(k, System.Text.Encoding.Default))
            {
                for (int i = 0; i < x; i++)
                {
                    line = sr.ReadLine();

                    map[i] = line;

                }

            }
            for (int i = 0; i < map.Length; i++)
            {
                for (int j = 0; j < map[i].Length; j++)
                {
                    if (map[i][j] == 'p') { px = j; py = i; }
                    if (map[i][j] == 'e') { ex = j; ey = i; }
                    if (map[i][j] == 'v') { vragi.Add(new vrag(j, i)); }
                }
            }
            for (int j = 0; j < map[0].Length; j++)
            {
                for (int i = 0; i < map.Length; i++)
                {
                    if (map[i][j] == 's')
                    {
                        storys.Add(new story(j, i));
                    }
                }
            }
            int v = 0;
            k = string.Concat(Application.StartupPath, "\\story", mapsl1.ToString(), ".txt");
            using (StreamReader sr = new StreamReader(k, System.Text.Encoding.Default))
            {
                
                while ((line = sr.ReadLine()) != null)
                {
                    if (v < storys.Count)
                    {
                        storys[v].s = line;
                    }
                    v++;

                }

            }
            timer1.Start();

        }
        public void move(int m)
        {
            if (m != 0)
            {
                if (px + m < map[py].Length && px + m >= 0 && map[py][px + m] != '*')
                {
                    if (map[py][px + m] == 'c')
                    {
                        score++;
                    }
                    if (map[py][px + m] == 'v' && !vragi.Find(x => x.vy == py && x.vx == px + m).dead)
                    {
                        pd = true;
                    }
                    map[py] = map[py].Remove(px + m, 1);
                    map[py] = map[py].Insert(px, "#");
                    px += m;


                    imove -= m;
                }

            }
            else
            {
                if (px + Convert.ToInt32(Math.Truncate(movex * 2.2)) < map[py].Length && px + Convert.ToInt32(Math.Truncate(movex * 2.2)) >= 0 && map[py][px + Convert.ToInt32(Math.Truncate(movex * 2.2))] != '*')
                {


                }
                else
                {
                    movex = 0f;
                }
            }


        }
        bool[] down = new bool[4];

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {

                down[0] = true;



                if (prig)
                {

                    vector = 8;



                };
            }
            if (e.KeyCode == Keys.S)
            {

                down[1] = true;
            }
            if (e.KeyCode == Keys.A)
            {

                down[2] = true;
            }
            if (e.KeyCode == Keys.D)
            {

                down[3] = true;
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            axWindowsMediaPlayer2.close();
            timer1.Stop();
        }

        private void Form2_SizeChanged(object sender, EventArgs e)
        {
            hd = this.Width / 50;
            hd2 = this.Height / 50;
            axWindowsMediaPlayer1.Height = this.Height;
            axWindowsMediaPlayer1.Width = this.Width;
            label1.Top = 38 * hd2;
       

            label2.Left = label2.Left/10 * hd;

            grass = new Bitmap(Properties.Resources.block, 5 * hd, 5 * hd2);
            trap = new Bitmap(Properties.Resources.trap, 5 * hd, 5 * hd2);
            mouse = new Bitmap(Properties.Resources.troll, 5 * hd, 5 * hd2);
            quest = new Bitmap(Properties.Resources.sup, 5 * hd, 5 * hd2);
            carrot = new Bitmap(Properties.Resources.lulz, 5 * hd, 5 * hd2);
            exit = new Bitmap(Properties.Resources.exit, 5 * hd, 5 * hd2);
            kolobki = new Bitmap(Properties.Resources.kolobok, 5 * hd, 5 * hd2);
            kolobki1 = new Bitmap(Properties.Resources.kolobok1, 5 * hd, 5 * hd2);
            kolobki2 = new Bitmap(Properties.Resources.kolobok2, 5 * hd, 5 * hd2);

            kolobki4 = new Bitmap(Properties.Resources.kolobok4, 5 * hd, 5 * hd2);
        }

        private void Form2_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.W)
            {

                down[0] = false;
            }
            if (e.KeyCode == Keys.S)
            {

                down[1] = false;
            }
            if (e.KeyCode == Keys.A)
            {

                down[2] = false;
            }
            if (e.KeyCode == Keys.D)
            {

                down[3] = false;
            }
            if(e.KeyCode == Keys.Q) { axWindowsMediaPlayer2.close(); }
        }
        Bitmap rabbit;
        Bitmap grass;
        Bitmap trap;
        Bitmap mouse;
        Bitmap quest;
        Bitmap carrot;
        Bitmap exit;
        Bitmap kolobki;
        Bitmap kolobki1;
        Bitmap kolobki2;
        Bitmap kolobki3;

   

        Bitmap kolobki4;
          private void Form2_Load(object sender, EventArgs e)
          {
            mapload();
            axWindowsMediaPlayer1.Visible = false;
            axWindowsMediaPlayer2.Visible = false;
            axWindowsMediaPlayer1.uiMode = "none";
            axWindowsMediaPlayer2.uiMode = "none";
            axWindowsMediaPlayer2.URL = Application.StartupPath + @"\sound.mp4";
            axWindowsMediaPlayer2.Ctlcontrols.play();
            hd = this.Width / 50;
            hd2 = this.Height / 50;
            axWindowsMediaPlayer2.settings.playCount = 1000;
            axWindowsMediaPlayer2.settings.volume = 3;
            grass = new Bitmap(Properties.Resources.block, 5 * hd, 5 * hd2);
            trap = new Bitmap(Properties.Resources.trap, 5 * hd, 5 * hd2);
            mouse = new Bitmap(Properties.Resources.troll, 5 * hd, 5 * hd2);
            quest = new Bitmap(Properties.Resources.sup, 5 * hd, 5 * hd2);
            carrot = new Bitmap(Properties.Resources.lulz, 5 * hd, 5 * hd2);
            exit = new Bitmap(Properties.Resources.exit, 5 * hd, 5 * hd2);
           kolobki  = new Bitmap(Properties.Resources.kolobok, 5 * hd, 5 * hd2);
           kolobki1  = new Bitmap(Properties.Resources.kolobok1, 5 * hd, 5 * hd2);
           kolobki2  = new Bitmap(Properties.Resources.kolobok2, 5 * hd, 5 * hd2);
       
            kolobki4 = new Bitmap(Properties.Resources.kolobok4, 5 * hd, 5 * hd2);
       
        }
        void kolobokdrawing(int kadr) {
            if (!pd)
            {


                if (down[2] || down[3] || vector > 0)
                {
                    switch (kadr % 3)
                    {
                        case 0: bg.Graphics.DrawImage(kolobki, 25 * hd, 25 * hd2); break;
                        case 1: bg.Graphics.DrawImage(kolobki1, 25 * hd, 25 * hd2); break;
                        case 2: bg.Graphics.DrawImage(kolobki2, 25 * hd, 25 * hd2); break;
                       
                    }
                }
                else
                {
                    bg.Graphics.DrawImage(kolobki, 25 * hd, 25 * hd2);
                }
            }
            else
            {
                bg.Graphics.DrawImage(kolobki4, 25 * hd, 25 * hd2);
                deadd = true;
            }
        
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            float movexold=0f;
            kadr++;
            bool n = false;
            if (kadr % 10 == 0)
            {
                foreach (vrag v in vragi)
                {
                    if ((v.vx - v.to >= 0 && v.vx - v.to < map[0].Length && map[v.vy][v.vx - v.to] != '*' && map[v.vy][v.vx - v.to] != 'v') && map[v.vy + 1][v.vx - v.to] != '#' && map[v.vy + 1][v.vx - v.to] != 'v' && map[v.vy + 1][v.vx - v.to] != 'p' && !v.dead)
                    {
                        if (map[v.vy][v.vx - v.to] == 'p' && !v.dead)
                        {

                            pd = true;
                            kolobokdrawing(kadr);
                         
                        }

                        string s = map[v.vy][v.vx - v.to].ToString();
                        map[v.vy] = map[v.vy].Remove(v.vx - v.to, 1);
                        map[v.vy] = map[v.vy].Insert(v.vx, s);
                        v.vx -= v.to;
                    }
                    else
                    {
                        v.to *= -1;
                    }
                }
            }




            if (kadr % 2 == 0)
            {
                if (vector > -1) { vector--; }
                if (vector > 0)
                {
                
                        if (py - 1 < map.Length && py - 1 >= 0 && map[py - 1][px + Convert.ToInt32(Math.Truncate(movex * 2.2))] != '*' && map[py - 1][px] != '*' && map[py - 1][px] != 's')
                        {
                            if (map[py - 1][px] == 'c') { score++; }
                            if (map[py - 1][px] == 'v')
                            {
                                vragi.Find(x => x.vy == py - 1 && x.vx == px).dead = true;
                                score += 10;
                                vded++;
                            }
                            map[py] = map[py].Remove(px, 1);
                            map[py] = map[py].Insert(px, "#");
                            map[py - 1] = map[py - 1].Remove(px, 1);
                            map[py - 1] = map[py - 1].Insert(px, "p");
                            py--;
                            prig = false;
                        }
                        else
                        {

                            vector = -1;
                        }
                   
                }
                else
                {
                    if (py + 1 < map.Length && py + 1 >= 0 && map[py + 1][px + Convert.ToInt32(Math.Truncate(movex * 2.2))] != '*' && map[py + 1][px] != '*' && map[py + 1][px] != 's')
                    {
                        if (map[py + 1][px] == 'c') { score++; }
                        if (map[py + 1][px] == 'v')
                        {
                            vragi.Find(x => x.vy == py + 1 && x.vx == px).dead = true;
                            score += 10;
                            vded++;
                        }
                        if (map[py + 1][px] == 'l')
                        {

                            pd = true;

                        }

                        map[py] = map[py].Remove(px, 1);
                        map[py] = map[py].Insert(px, "#");
                        map[py + 1] = map[py + 1].Remove(px, 1);
                        map[py + 1] = map[py + 1].Insert(px, "p"); py++;
                    }
                    else
                    {
                        prig = true;
                    }

                }
            }
            if (map[py + 1][px] == 's')
            {



                label1.Text = storys.Find(x => x.sy == py + 1 && x.sx == px).s;


            }
            else
            {
                if (!door)
                {
                    label1.Text = "Ваш счёт:"+score.ToString();
                }

            }

            if (down[2])
            {
                movex -= 0.5f;
                move(Convert.ToInt32(Math.Truncate(movex - 0.1f)));
            }
            if (down[3])
            {
                movex += 0.5f;
                move(Convert.ToInt32(Math.Truncate(movex + 0.1f)));
            }
           
            if (kadr == 60) { kadr = 0; }
            int pxmax, pxmim, pymax, pymin;

            Graphics g = this.CreateGraphics();
            bg = con.Allocate(g, new Rectangle(0, 0, this.Width, this.Height));
            bg.Graphics.Clear(Color.White);

            if (movex > -0.5 && movex < 0.5)
            {
                if (imove >= -5 && imove <= 5)
                {
                    bg.Graphics.DrawImage(Properties.Resources.og_og_1555587309215077976 , -25*hd + 5 *hd* (imove - (movex - Convert.ToSingle(Math.Truncate(movex)))), 0, this.Width, this.Height);
                    bg.Graphics.DrawImage(Properties.Resources.og_og_1555587309215077976, 25*hd + 5 * hd * (imove - (movex - Convert.ToSingle(Math.Truncate(movex)))), 0, this.Width, this.Height);
                }
                else
                {
                    imove = 0f;
                    bg.Graphics.DrawImage(Properties.Resources.og_og_1555587309215077976 , -25*hd + 5*hd * (imove - (movex - Convert.ToSingle(Math.Truncate(movex)))), 0, this.Width, this.Height);
                      bg.Graphics.DrawImage(Properties.Resources.og_og_1555587309215077976 , 25*hd + 5 * hd * (imove - (movex - Convert.ToSingle(Math.Truncate(movex)))), 0, this.Width, this.Height);
                }
            }
            else
            {
                if (imove >= -5 && imove <= 5)
                {
                    bg.Graphics.DrawImage(Properties.Resources.og_og_1555587309215077976 , -25*hd + 5*hd * imove, 0, this.Width, this.Height);
                    bg.Graphics.DrawImage(Properties.Resources.og_og_1555587309215077976 , 25*hd + 5*hd * imove, 0, this.Width, this.Height);
                }
                else
                {
                    imove = 0f;
                    bg.Graphics.DrawImage(Properties.Resources.og_og_1555587309215077976 , -25*hd + 5 *hd* imove, 0, this.Width, this.Height);
                      bg.Graphics.DrawImage(Properties.Resources.og_og_1555587309215077976 , 25*hd + 5 *hd* imove, 0, this.Width, this.Height);
                }

            }
            kolobokdrawing(kadr);
            movexold = movex;
            pxmim = px - 4;
            pymin = py - 4;
            pxmax = px + 4;
            pymax = py + 4;
            if (pxmim < 0) { pxmim = 0; }

            if (pymin < 0) { pymin = 0; ; }
            if (pymax >= map.Length) { pymax = map.Length; }
            if (pxmax >= map[0].Length) { pxmax = map[0].Length; }
            if (movex - 0.1f < -1f || movex + 0.1f > 1f) { movex = 0f; }
            for (int i = pymin; i < pymax; i++)
            {
                for (int j = pxmim; j < pxmax; j++)
                {
                    if (map[i][j] == '*')
                    {
                        bg.Graphics.DrawImage(grass, 25*hd - ((px - j + movex) * (5*hd)), 25*hd2 - ((py - i) * (5 * hd2)));
                    }
                    if (map[i][j] == 'c')
                    {
                        bg.Graphics.DrawImage(carrot, 25 * hd - ((px - j + movex) * (5 * hd)), 25 * hd2 - ((py - i) * (5 * hd2)));
                    }
                    if (map[i][j] == 'e')
                    {
                        bg.Graphics.DrawImage(exit, 25 * hd - ((px - j + movex) * (5 * hd)), 25 * hd2 - ((py - i) * (5 * hd2)));
                    }
                    if (map[i][j] == 'v')
                    {
                        bg.Graphics.DrawImage(mouse, 25 * hd - ((px - j + movex) * (5 * hd)), 25 * hd2 - ((py - i) * (5 * hd2)));
                    }
                    if (map[i][j] == 'l')
                    {
                        bg.Graphics.DrawImage(trap, 25 * hd - ((px - j + movex) * (5 * hd)), 25 * hd2 - ((py - i) * (5 * hd2)));
                    }
                    if (map[i][j] == 's')
                    {
                        bg.Graphics.DrawImage(quest, 25 * hd - ((px - j + movex) * (5 * hd)), 25 * hd2 - ((py - i) * (5 * hd2)));
                    }
                }

            }
            if ((ex != px || py != ey) && !pd) { map[ey] = map[ey].Remove(ex, 1); map[ey] = map[ey].Insert(ex, "e"); door = false; }
            else
            {
                door = true;
                label1.Text = "Нажмите S чтобы выйти"; if (down[1])
                {
                    if (mapsl1 + 1 < maps) { mapsl1++; timer1.Stop(); mapload(); } else { mapse = true; };
                }
                if ( deadd )
                {
                    axWindowsMediaPlayer2.close();
                    
                    label2.Left = label1.Left;
                    label1.Top = label2.Top - 30;
                    label1.Font = label2.Font;
                    label1.Text = "Ваш счет: " + score.ToString() + " врагов убито: " + vded.ToString();
                    label2.Text = "Азаза тебя затралировали";
                    bg.Graphics.DrawImage(Properties.Resources.og_og_1555587309215077976, 0, 0, this.Width, this.Height);
                    kolobokdrawing(kadr);
                    timer1.Stop();


                };
                if(mapse)
                {
                    label1.Font = label2.Font;
                    label1.Top = 20;
                    label1.Text = "Ваш счет " + score.ToString() + " врагов убито " + vded.ToString();

                    axWindowsMediaPlayer2.close();
                    axWindowsMediaPlayer1.Visible = true;
                    axWindowsMediaPlayer1.URL = Application.StartupPath + "\\damedane.mp4";
                    timer1.Stop();

                 

                }
            }

            bg.Render();
        }
    }
}
