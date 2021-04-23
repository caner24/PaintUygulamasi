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
using System.Drawing.Imaging;
using System.Diagnostics;

namespace Paint_Uygulaması
{
    public partial class Form1 : Form
    {
        // Fırça veya şekiller ile çizme işlemimizi yapabilmemiz için   grafik değişkenimiz oluşturuldu.
        Graphics g;
        public Form1()
        {
            InitializeComponent();
        }
        // ***********************************************        DEVELOPED BY : CANER24         *********************************************** // 

        // Fırça veya uygulamada olan dikdörtgen gibi şekillere basınca geçiş yapmak için durum değişkeni oluşturuldu.
        int durum;

        // Mouse'dan elimizi çekince çizme işlemini yapmaması için true false ile bu adımı kontrol etmek için bool veritipinde cizme işlemi adında değişken oluşturuldu.
        bool cizmeislemi;

        // Çizme işlemimizi konumu için konum değişkenleri oluşturuldu.
        int xkonum, ykonum;

        // Çizme işlemi kalem kalınlığı için kalınlik değişkeni oluşturuldu.
        int kalınlik = 3;

        // Çizme işlemi kalem rengi için renksec değişkeni oluşturuldu.
        ColorDialog renksec = new ColorDialog();

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            // Faremiz eğerki mause down işlemini gerçekleştirire yani mause'a basıp çizme işlemi yaparsak.Bool tanımladığımız veri tipini true yaparak çizme işleminin başlaması için kontrol verme işlemi.
            cizmeislemi = true;

            // Çizme işlemi yaparken konumun mouse ile güncel olan konumu tanımlaması için 'e' özelliği ile güncel konumun xkonum ve ykonum değişkenlerine tanıtılması
            xkonum = e.X;
            ykonum = e.Y;
        }
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            // Eğer mause ile çizme işlemi yapmayacaksak yani basılı tutmuyorsak çizme işleminin olmaması için kontrol ettiğimiz bool değişkenini false yapıldı.
            cizmeislemi = false;
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            // Fırça için durum değişkeninde 1 atandı.
            if (durum == 1)
            {
                // Grafik değişkenimiz panel üzerinde görüntü oluşturmak için işlemler yapıldı.
                g = panel1.CreateGraphics();

                // Kalem değişkenimiz ile kalemimizin rengi ve kalınlığı belirlendi.
                Pen p = new Pen(renksec.Color, kalınlik);

                // Çizeceğimiz nesnenin konumu belirlendi.
                Point konum1 = new Point(xkonum, ykonum);
                Point konum2 = new Point(e.X, e.Y);


                label3.Text = e.X.ToString();
                label4.Text = e.Y.ToString();

                // Çizme işlemini kontrol ettiğimiz zamanda true ise yani mause basılıyor ise işlemlerin gerçekleşmesi için if bloğu oluşturuldu.
                if (cizmeislemi == true)
                {
                    // 1.durumumuz çizgi olduğu için graphics özelliğinden yararlanarak DrawLine yani çizgi değişkenimizi oluşturduk.
                    g.DrawLine(p, konum1, konum2);
                    xkonum = e.X;
                    ykonum = e.Y;
                }
            }


            // Dikdörtgen için durum değişkeninde 2 atandı.
            if (durum == 2)
            {
                // Grafik değişkenimiz panel üzerinde görüntü oluşturmak için işlemler yapıldı.
                g = panel1.CreateGraphics();

                // Kalem değişkenimiz ile kalemimizin rengi ve kalınlığı belirlendi.
                Pen p = new Pen(renksec.Color, kalınlik);

                // 2.durumumuz dikdörtgen olduğu için point yerine rectangle ' dan yararlanarak dikdörtgenin köşelerinin uzunluğunu belirledik.
                Rectangle rec = new Rectangle(e.X, e.Y, 100, 100);

                label3.Text = e.X.ToString();
                label4.Text = e.Y.ToString();

                // Çizme işlemini kontrol ettiğimiz zamanda true ise yani mause basılıyor ise işlemlerin gerçekleşmesi için if bloğu oluşturuldu.
                if (cizmeislemi == true)
                {
                    // 2.durumumuz dikdörtgen olduğu için graphics özelliğinden yararlanarak DrawRectangle yani dikdörtgen değişkenimizi oluşturduk.
                    g.DrawRectangle(p, rec);
                    xkonum = e.X;
                    ykonum = e.Y;
                }
            }

            // Elips için durum değişkeninde 3 atandı.
            if (durum == 3)
            {
                g = panel1.CreateGraphics();

                // Kalem değişkenimiz ile kalemimizin rengi ve kalınlığı belirlendi.
                Pen kalem = new Pen(renksec.Color, kalınlik);

                // 3.durumumuz elips olduğu için point yerine rectangle ' dan yararlanarak elips'in uzunluğunu belirledik.
                Rectangle rec = new Rectangle(e.X, e.Y, 100, 100);

                // Çizme işlemini kontrol ettiğimiz zamanda true ise yani mause basılıyor ise işlemlerin gerçekleşmesi için if bloğu oluşturuldu.      
                if (cizmeislemi == true)
                {
                    // 3.durumumuz elips olduğu için graphics özelliğinden yararlanarak DrawEllipse yani elips değişkenimizi oluşturduk.
                    g.DrawEllipse(kalem, rec);
                    xkonum = e.X;
                    ykonum = e.Y;
                }
            }

            // Koni için durum değişkeninde 4 atandı.
            if (durum == 4)
            {
                g = panel1.CreateGraphics();

                // Kalem değişkenimiz ile kalemimizin rengi ve kalınlığı belirlendi.
                Pen kalem = new Pen(renksec.Color, kalınlik);

                // 4.durumumuz koni olduğu için point yerine rectangle ' dan yararlanarak koni'in uzunluğunu belirledik.
                Rectangle rec = new Rectangle(e.X, e.Y, 100, 100);

                // Çizme işlemini kontrol ettiğimiz zamanda true ise yani mause basılıyor ise işlemlerin gerçekleşmesi için if bloğu oluşturuldu.    
                if (cizmeislemi == true)
                {
                    // 4.durumumuz elips olduğu için graphics özelliğinden yararlanarak DrawPie yani koni değişkenimizi oluşturduk.
                    g.DrawPie(kalem, rec, e.X,e.Y);
                    xkonum = e.X;
                    ykonum = e.Y;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kalemimizin kalınlığının kontrolü için combobax'dan yararlanarak kalemin kalınlığı ayarlandı.
            kalınlik = int.Parse(comboBox1.SelectedItem.ToString());
        }
        private void button13_Click(object sender, EventArgs e)
        {
            // Kalemimizin renk kontrolünü kullanıcı istediği rengi seçmesi için colordialog'dan yaralanıldı.
            renksec.ShowDialog();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            // İstenilen bölgeyi silme işlemi için sil butonuna basılması durumunda formun kendi stok rengi kalem rengine aktarılması işlemi.
            renksec.Color = Form1.DefaultBackColor;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Butonlara koyulan renk ressimlerinden istenilen renk resmi olan butona basılınca kalem renginin ayalarlanması işlemi.
            renksec.Color = Color.Black;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Butonlara koyulan renk ressimlerinden istenilen renk resmi olan butona basılınca kalem renginin ayalarlanması işlemi.
            renksec.Color = Color.Gray;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            // Butonlara koyulan renk ressimlerinden istenilen renk resmi olan butona basılınca kalem renginin ayalarlanması işlemi.
            renksec.Color = Color.Red;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Butonlara koyulan renk ressimlerinden istenilen renk resmi olan butona basılınca kalem renginin ayalarlanması işlemi.
            renksec.Color = Color.Green;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Butonlara koyulan renk ressimlerinden istenilen renk resmi olan butona basılınca kalem renginin ayalarlanması işlemi.
            renksec.Color = Color.Blue;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Butonlara koyulan renk ressimlerinden istenilen renk resmi olan butona basılınca kalem renginin ayalarlanması işlemi.
            renksec.Color = Color.Cyan;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Butonlara koyulan renk ressimlerinden istenilen renk resmi olan butona basılınca kalem renginin ayalarlanması işlemi.
            renksec.Color = Color.Pink;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Butonlara koyulan renk ressimlerinden istenilen renk resmi olan butona basılınca kalem renginin ayalarlanması işlemi.
            renksec.Color = Color.Purple;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // Butonlara koyulan renk ressimlerinden istenilen renk resmi olan butona basılınca kalem renginin ayalarlanması işlemi.
            renksec.Color = Color.Beige;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            // Butonlara koyulan renk ressimlerinden istenilen renk resmi olan butona basılınca kalem renginin ayalarlanması işlemi.
            renksec.Color = Color.Gold;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            // Butonlara koyulan renk ressimlerinden istenilen renk resmi olan butona basılınca kalem renginin ayalarlanması işlemi.
            renksec.Color = Color.Yellow;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            // Temiz bir sayfa için veya çizilen nesnelerin hepsinin silinmesi için clear işleminden yararlanıldı.
            g.Clear(Form1.DefaultBackColor);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            // Fırça 1.Durumda olduğunda durum değişkenimizi 1'e atadık ve fırçanın seçili olduğu belirli olması için arkaplan rengi yeşil yapıldı.
            durum = 1;
            button15.BackColor = Color.Green;
            button14.BackColor = Color.White;
            button17.BackColor = Color.White;
            button16.BackColor = Color.White;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            durum = 1;
            button15.BackColor = Color.Green;
            kalınlik = 5;
            comboBox1.Text = kalınlik.ToString();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            // Dikdörtgen 2.Durumda olduğunda durum değişkenimizi 1'e atadık ve dikdörtgenin seçili olduğu belirli olması için arkaplan rengi yeşil yapıldı.
            durum = 2;
            button15.BackColor = Color.White;
            button14.BackColor = Color.Green;
            button17.BackColor = Color.White;
            button16.BackColor = Color.White;

        }

        private void button17_Click(object sender, EventArgs e)
        {
            // Elips 3.Durumda olduğunda durum değişkenimizi 1'e atadık ve elipsin seçili olduğu belirli olması için arkaplan rengi yeşil yapıldı.
            durum = 3;
            button15.BackColor = Color.White;
            button14.BackColor = Color.White;
            button17.BackColor = Color.Green;
            button16.BackColor = Color.White;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            // Koni 4.Durumda olduğunda durum değişkenimizi 1'e atadık ve koninin seçili olduğu belirli olması için arkaplan rengi yeşil yapıldı.
            durum = 4;
            button15.BackColor = Color.White;
            button14.BackColor = Color.White;
            button16.BackColor = Color.Green;
            button17.BackColor = Color.White;
        }


        private void simpleButton3_Click(object sender, EventArgs e)
        {
            // Çizdiğimiz şekilleri kayıt etmek için savefiledialog aracı kullanıldı.
            saveFileDialog1.Title = "Kayit Ediniz";

            // Çizdiğimiz şekilleri kayıt etmek için jpg formatı kullanıldı.
            saveFileDialog1.Filter="Resim Dosyasi(*.jpg) | *.jpg";

            // Savefiledialog aracımızda kayıt etme işleminde kullanıcı kaydet butonuna basılınca olması gereken işlemler if bloğunun içerisine yazıldı.
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Kaydedeceğimiz çizimin adı için savefiledialog'un filename özelliğinden yararlanıldı.
                var filefullname = saveFileDialog1.FileName;

                // Kaydedeceğimiz çizimin genişliği ve konumu işlemleri.
                var bitmap = new Bitmap(panel1.Width, panel1.Height);
                var graphics = Graphics.FromImage(bitmap);
                var rectangle = panel1.RectangleToScreen(panel1.ClientRectangle);
                graphics.CopyFromScreen(rectangle.Location, Point.Empty, panel1.Size);

                // Kaydedilecek resmin filedialog penceresinde yazılan isme ve konuma göre kaydetmesi işlemleri gerçekleştirildi.
                bitmap.Save(filefullname);
            }
        }
    }
}
