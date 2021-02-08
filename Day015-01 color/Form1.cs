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

namespace Day015_01_color
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //전역 변수
        byte[,,] inImage = null, outImage = null;
        int inH, inW, outH, outW;
        string fileName;
        Bitmap paper, bitmap;
        const int RGB = 3, RR = 0, GG = 1, BB = 2, LISTSIZE = 7;
        bool mouseYN = false, isUndo = false;
        int mouseSX, mouseSY, mouseEX, mouseEY;
        List<byte[,,]> undoList = new List<byte[,,]>();
        List<byte[,,]> redoList = new List<byte[,,]>();
        //메뉴 이벤트 처리부
        private void 실행취소ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undoImage();
        }
        private void 다시실행ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            redoImage();
        }
        private void 저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveImage();
        }
        private void 스트레칭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stretching();
        }
        private void 평활화ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            equalized();
        }
        private void 엔드인탐색ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            endInSearch();
        }
        private void 히스토그램그리기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawHistogram();
        }
        private void 미디언필터ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            medianFilter();
        }
        private void erosionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            erosion();
        }
        private void dilationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dilation();
        }
        private void openingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            opening();
        }
        private void closingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closing();
        }
        private void 반전이미지ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reverseImage();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.O:
                        openImage();
                        break;
                    case Keys.S:
                        break;
                    case Keys.Z:
                        undoImage();
                        break;
                    case Keys.Y:
                        redoImage();
                        break;
                }
            }
            if (e.Alt)
            {
                switch (e.KeyCode)
                {
                    case Keys.E:
                        break;
                    case Keys.B:
                        break;
                    case Keys.S:
                        break;
                    case Keys.M:
                        break;
                }
            }
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (!mouseYN)
            {
                return;
            }
            mouseEX = e.X;
            mouseEY = e.Y;

            if (mouseSX > mouseEX)
            {
                int tmp = mouseSX;
                mouseSX = mouseEX;
                mouseEX = tmp;
            }
            if (mouseSY > mouseEY)
            {
                int tmp = mouseSY;
                mouseSY = mouseEY;
                mouseEY = tmp;
            }

            reverseImage();
            mouseYN = false;
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (!mouseYN)
            {
                return;
            }
            mouseSX = e.X; mouseSY = e.Y;
        }
        private void 반전선택ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mouseYN = true;
        }
        private void 동일이미지ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            equal_image();
        }
        private void 이진화ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bwImage();
        }
        private void 열기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openImage();
        }
        private void 확대ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sizeUpImage();
        }
        private void 축소ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sizeDownImage();
        }
        private void 밝게어둡게ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            brightImage();
        }
        private void 그레이스케일ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grayScale();
        }
        private void 회전ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rotateImage();
        }
        //공통 함수부
        void saveImage() //미구현 함수 누르면 오류발생
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "";
            sfd.Filter = "칼라 필터 | *.png;*.jpg;*.bmp;*.tif;";
            if (sfd.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string saveFname = sfd.FileName;
            pictureBox1.Image.Save(fileName);
        }
        void openImage()
        {
            OpenFileDialog ofd = new OpenFileDialog();  // 객체 생성
            ofd.DefaultExt = "";
            ofd.Filter = "칼라 필터 | *.png;*.jpg;*.bmp;*.tif;";
            if(ofd.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            fileName = ofd.FileName;
            //파일 -> 비트맵
            bitmap = new Bitmap(fileName);
            // 중요! 입력이미지의 높이, 폭 알아내기
            inW = bitmap.Height;
            inH = bitmap.Width;
            inImage = new byte[RGB, inH, inW]; // 메모리 할당
            //비트맵 -> 메모리 (로딩)
            for (int i = 0; i < inH; i++)
            {
                for (int j = 0; j < inW; j++)
                {
                    Color c = bitmap.GetPixel(i,j);
                    inImage[RR, i, j] = c.R;
                    inImage[GG, i, j] = c.G;
                    inImage[BB, i, j] = c.B;
                }
            }
            equal_image();
        }
        void equal_image()
        {
            if (inImage == null)
            {
                return;
            }
            // 중요! 출력이미지의 높이, 폭을 결정  --> 알고리즘에 영향
            outH = inH; outW = inW;
            outImage = new byte[RGB, outH, outW];
            for (int rgb = 0; rgb < RGB; rgb++)
            {
                for (int i = 0; i < inH; i++)
                {
                    for (int j = 0; j < inW; j++)
                    {
                        outImage[rgb, i, j] = inImage[rgb, i, j];
                    }
                }
            }
            displayImage();
        }
        void displayImage()
        {
            if (!isUndo)//undo로 접근하지 않았을때
            {
                redoList.Clear();//새로운 작업시 리스트를 초기화
                if (undoList.Count == LISTSIZE)
                {//LISTSIZE이상 저장하지 않음
                    undoList.RemoveAt(0);
                }
                undoList.Add(outImage);
            }
            // 벽, 게시판, 종이 크기 조절
            paper = new Bitmap(outH, outW); // 종이
            pictureBox1.Size = new Size(outH, outW); // 캔버스
            this.Size = new Size(outH + 20, outW + 80); // 벽

            Color pen; // 펜(콕콕 찍을 용도)
            for (int i = 0; i < outH; i++)
            {
                for (int j = 0; j < outW; j++)
                {
                    byte r = outImage[RR,i, j]; // 잉크(색상값)
                    byte g = outImage[GG,i, j]; // 잉크(색상값)
                    byte b = outImage[BB,i, j]; // 잉크(색상값)
                    pen = Color.FromArgb(r, g, b); // 펜에 잉크 묻히기
                    paper.SetPixel(i, j, pen); // 종이에 콕 찍기
                }
            }
            pictureBox1.Image = paper; // 게시판에 종이를 붙이기.
            //실행 취소 -> 파일경로 구현 못함
            toolStripStatusLabel1.Text =
                outH.ToString() + "x" + outW.ToString() + "  " + fileName;
        }
        double getValue()
        {
            subform sub = new subform();//서브폼 준비
            if (sub.ShowDialog() == DialogResult.Cancel)
            {
                return 0.0;
            }
            double value = (double)sub.numUp_value.Value;
            return value;
        }
        private void 엠보싱ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            embossImage();
        }
        private void 블러링ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            blurrImage();
        }
        private void 샤프닝ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sharpImage();
        }
        //영상처리 함수부
        void brightImage()
        {
            if (inImage == null)
            {
                return;
            }
            // 중요! 출력이미지의 높이, 폭을 결정  --> 알고리즘에 영향
            outH = inH; outW = inW;
            outImage = new byte[RGB, outH, outW];
            int value = (int)getValue();
            for (int rgb = 0; rgb < RGB; rgb++)
            {
                for (int i = 0; i < inH; i++)
                {
                    for (int j = 0; j < inW; j++)
                    {
                        if(inImage[rgb, i, j] + value > 255)
                        {
                            outImage[rgb, i, j] = 255;
                        } else if(inImage[rgb, i, j] + value < 0)
                        {
                            outImage[rgb, i, j] = 0;
                        } else
                        {
                            outImage[rgb, i, j] = (byte)(inImage[rgb, i, j] + value);
                        }
                    }
                }
            }
            displayImage();
        }
        void grayScale()
        {
            if (inImage == null)
            {
                return;
            }
            // 중요! 출력이미지의 높이, 폭을 결정  --> 알고리즘에 영향
            outH = inH; outW = inW;
            outImage = new byte[RGB, outH, outW];
            for (int i = 0; i < inH; i++)
            {
                for (int j = 0; j < inW; j++)
                {
                    int hap = inImage[RR, i, j] + inImage[GG, i, j] + inImage[BB, i, j];
                    byte rgb = (byte)(hap / 3.0); 
                    outImage[RR, i, j] = rgb;
                    outImage[GG, i, j] = rgb;
                    outImage[BB, i, j] = rgb;
                }
            }
            displayImage();
        }
        void reverseImage()
        {
            if (inImage == null)
            {
                return;
            }
            outH = inH;
            outW = inW;
            outImage = new byte[RGB, outH, outW];

            if (!mouseYN)
            {
                mouseSX = 0; mouseEX = inH;
                mouseSY = 0; mouseEY = inW;
            }

            for (int i = 0; i < inH; i++)
            {
                for (int j = 0; j < inW; j++)
                {
                    if ((mouseSX <= i && i <= mouseEX) && (mouseSY <= j && j <= mouseEY))
                    {
                        outImage[RR, i, j] = (byte)(255 - inImage[RR, i, j]);
                        outImage[GG, i, j] = (byte)(255 - inImage[GG, i, j]);
                        outImage[BB, i, j] = (byte)(255 - inImage[BB, i, j]);
                    }
                    else
                    {
                        outImage[RR, i, j] = inImage[RR, i, j];
                        outImage[GG, i, j] = inImage[GG, i, j];
                        outImage[BB, i, j] = inImage[BB, i, j];
                    }
                }
            }
            displayImage();
        }
        void bwImage()
        {
            if (inImage == null)
            {
                return;
            }
            outH = inH;
            outW = inW;
            outImage = new byte[RGB, outH, outW];
            for (int i = 0; i < inH; i++)
            {
                for (int j = 0; j < inW; j++)
                {
                    if (inImage[RR, i, j] > 127)
                    {
                        outImage[RR, i, j] = 255;
                    } else if(inImage[GG, i, j] > 127)
                    {
                        outImage[GG, i, j] = 255;
                    } else if (inImage[BB, i, j] > 127)
                    {
                        outImage[BB, i, j] = 255;
                    }
                    else
                    {
                        outImage[RR, i, j] = 0;
                        outImage[GG, i, j] = 0;
                        outImage[BB, i, j] = 0;
                    }
                }
            }
            displayImage();
        }
        void sizeUpImage()
        {//확대 알고리즘
            if (inImage == null)
            {
                return;
            }
            int mul = (int)getValue();
            outH = inH * mul;
            outW = inW * mul;
            outImage = new byte[RGB, outH, outW];
            for (int i = 0; i < outH; i++)
            {
                for (int j = 0; j < outW; j++)
                {
                    outImage[RR, i, j] = inImage[RR, i / mul, j / mul];
                    outImage[GG, i, j] = inImage[GG, i / mul, j / mul];
                    outImage[BB, i, j] = inImage[BB, i / mul, j / mul];
                }
            }
            displayImage();
        }
        void sizeDownImage()
        {//축소 알고리즘
            if (inImage == null)
            {
                return;
            }
            int div;
            div = (int)getValue();
            outH = inH / div;
            outW = inW / div;
            outImage = new byte[RGB, outH, outW];
            int sumR, sumG, sumB;
            for (int i = 0; i < outH; i++)
            {//평균값으로 계산
                for (int j = 0; j < outW; j++)
                {
                    sumR = 0;
                    sumG = 0;
                    sumB = 0;
                    for (int k = 0; k < div; k++)
                    {
                        for (int m = 0; m < div; m++)
                        {
                            sumR = sumR + inImage[RR, i * div + k, j * div + m];
                            sumG = sumG + inImage[GG, i * div + k, j * div + m];
                            sumB = sumB + inImage[BB, i * div + k, j * div + m];
                        }
                    }
                    outImage[RR, i, j] = (byte)(sumR / (double)(div * div));
                    outImage[GG, i, j] = (byte)(sumG / (double)(div * div));
                    outImage[BB, i, j] = (byte)(sumB / (double)(div * div));
                }
            }
            displayImage();
        }
        void rotateImage()
        {//회전 알고리즘
            if (inImage == null)
            {
                return;
            }
            int degree = (int)getValue();
            outH = inH;
            outW = inW;
            outImage = new byte[RGB, outH, outW];
            int center_w = inW / 2;//중심축 계산
            int center_h = inH / 2;
            int new_w;
            int new_h;
            double pi = 3.141592;
            double seta = pi / (180.0 / degree);
            //회전 알고리즘
            for (int i = 0; i < inH; i++)
            {
                for (int j = 0; j < inW; j++)
                {
                    new_w = (int)((i - center_h) * Math.Sin(seta) + (j - center_w) * Math.Cos(seta) + center_w);
                    new_h = (int)((i - center_h) * Math.Cos(seta) - (j - center_w) * Math.Sin(seta) + center_h);
                    if (new_w < 0) continue;
                    if (new_w >= inW) continue;
                    if (new_h < 0) continue;
                    if (new_h >= inH) continue;
                    outImage[RR, i, j] = inImage[RR, new_h, new_w];
                    outImage[GG, i, j] = inImage[GG, new_h, new_w];
                    outImage[BB, i, j] = inImage[BB, new_h, new_w];
                }
            }
            displayImage();
        }
        void fillEdges(double[,,] tmpInput, double[,,] inputCopy)
        {//가장자리 처리 알고리즘 5x5 마스크 전용
            for (int rgb = 0; rgb < RGB; rgb++)
            {
                for (int i = 0; i < inH + 4; i++)
                {
                    for (int j = 0; j < inW + 4; j++)
                    {
                        if (i < 2 && j < 2)//왼쪽 위 모서리
                        {
                            tmpInput[rgb, i, j] = inputCopy[rgb, i, j];
                        }
                        else if (i < 2 && j > inW + 1) //오른쪽 위 모서리
                        {
                            tmpInput[rgb, i, j] = inputCopy[rgb, i, j - 4];
                        }
                        else if (i < 2)//맨 위 2줄
                        {
                            tmpInput[rgb, i, j] = inputCopy[rgb, i, j - 2];
                        }
                        else if (i > inH + 1 && j < 2)//왼쪽 아래 모서리
                        {
                            tmpInput[rgb, i, j] = inputCopy[rgb, i - 4, j];
                        }
                        else if (i > inH + 1 && j > inW + 1)//오른쪽 아래 모서리
                        {
                            tmpInput[rgb, i, j] = inputCopy[rgb, i - 4, j - 4];
                        }
                        else if (j < 2)//맨 왼쪽 2줄
                        {
                            tmpInput[rgb, i, j] = inputCopy[rgb, i - 2, j];
                        }
                        else if (j > inW + 1)//맨 오른쪽 2줄
                        {
                            tmpInput[rgb, i, j] = inputCopy[rgb, i - 2, j - 4];
                        }
                        else if (i > inH + 1)//맨 아래 2줄
                        {
                            tmpInput[rgb, i, j] = inputCopy[rgb, i - 4, j - 2];
                        }
                        else
                        {
                            tmpInput[rgb, i, j] = inputCopy[rgb, i - 2, j - 2];
                        }
                    }
                }
            }
        }
        void maskOP(double[,,] tmpInput, double[,,] tmpOutput, double[,] mask)
        {
            double sumR = 0.0;
            double sumG = 0.0;
            double sumB = 0.0;
            for (int i = 2; i < inH + 2; i++)
            {
                for (int j = 2; j < inW + 2; j++)
                {
                    for (int k = 0; k < 5; k++)
                    {
                        for (int m = 0; m < 5; m++)
                        {
                            sumR += tmpInput[RR, i - 2 + k, j - 2 + m] * mask[k, m];
                            sumG += tmpInput[GG, i - 2 + k, j - 2 + m] * mask[k, m];
                            sumB += tmpInput[BB, i - 2 + k, j - 2 + m] * mask[k, m];
                        }
                    }
                    tmpOutput[RR, i - 2, j - 2] = sumR;
                    tmpOutput[GG, i - 2, j - 2] = sumG;
                    tmpOutput[BB, i - 2, j - 2] = sumB;
                    sumR = 0.0;
                    sumG = 0.0;
                    sumB = 0.0;
                }
            }
        }
        void outCopy(double[,,] tmpOutput)
        { //임시 출력 -> 원래 출력
            for (int rgb = 0; rgb < RGB; rgb++)
            {
                for (int i = 0; i < inH; i++)
                {
                    for (int j = 0; j < inW; j++)
                    {
                        if (tmpOutput[rgb, i, j] > 255.0)
                        {
                            outImage[rgb, i, j] = (byte)255;
                        }
                        else if (tmpOutput[rgb, i, j] < 0.0)
                        {
                            outImage[rgb, i, j] = (byte)0;
                        }
                        else
                        {
                            outImage[rgb, i, j] = (byte)tmpOutput[rgb, i, j];
                        }
                    }
                }
            }
        }
        void embossImage()
        {
            if (inImage == null)
            {
                return;
            }
            outH = inH;
            outW = inW;
            outImage = new byte[RGB, outH, outW];
            //마스크 결정
            double[,] mask = {
                { -1.0, 0.0, 0.0, 0.0, 0.0},
                { 0.0, 0.0, 0.0, 0.0, 0.0},
                { 0.0, 0.0, 0.0, 0.0, 0.0},
                { 0.0, 0.0, 0.0, 0.0, 0.0},
                { 0.0, 0.0, 0.0, 0.0, 1.0} };
            //임시 입력 출력 메모리 할당
            double[,,] tmpInput = new double[RGB ,inH + 4, inW + 4];//확장된 메모리
            double[,,] inputCopy = new double[RGB, inH, inW];//가장자리 처리를 위한 복사본 메모리
            double[,,] tmpOutput = new double[RGB, inH, inW];//후처리를 위한 출력 메모리
            //입력 -> 복사본 복사
            for (int i = 0; i < inH; i++)
            {
                for (int j = 0; j < inW; j++)
                {
                    inputCopy[RR, i, j] = inImage[RR, i, j];
                    inputCopy[GG, i, j] = inImage[GG, i, j];
                    inputCopy[BB, i, j] = inImage[BB, i, j];
                }
            }
            //가장자리 처리
            fillEdges(tmpInput, inputCopy);
            //마스크연산
            maskOP(tmpInput, tmpOutput, mask);
            var findAvg = calculImage();
            //후처리
            for (int i = 0; i < inH; i++)
            {
                for (int j = 0; j < inW; j++)
                {
                    tmpOutput[RR, i, j] += findAvg.rAvg;
                    tmpOutput[GG, i, j] += findAvg.gAvg;
                    tmpOutput[BB, i, j] += findAvg.bAvg;
                }
            }
            //임시 출력 -> 원래 출력
            outCopy(tmpOutput);
            displayImage();
        }
        void blurrImage()
        {
            if (inImage == null)
            {
                return;
            }
            outH = inH;
            outW = inW;
            outImage = new byte[RGB, outH, outW];
            //마스크 결정
            double[,] mask = {
                { 1.0/25.0, 1.0/25.0, 1.0/25.0, 1.0/25.0, 1.0/25.0},
                { 1.0/25.0, 1.0/25.0, 1.0/25.0, 1.0/25.0, 1.0/25.0},
                { 1.0/25.0, 1.0/25.0, 1.0/25.0, 1.0/25.0, 1.0/25.0},
                { 1.0/25.0, 1.0/25.0, 1.0/25.0, 1.0/25.0, 1.0/25.0},
                { 1.0/25.0, 1.0/25.0, 1.0/25.0, 1.0/25.0, 1.0/25.0} };
            //임시 입력 출력 메모리 할당
            double[,,] tmpInput = new double[RGB, inH + 4, inW + 4];//확장된 메모리
            double[,,] inputCopy = new double[RGB, inH, inW];//가장자리 처리를 위한 복사본 메모리
            double[,,] tmpOutput = new double[RGB, inH, inW];//후처리를 위한 출력 메모리
            //입력 -> 복사본 복사
            for (int i = 0; i < inH; i++)
            {
                for (int j = 0; j < inW; j++)
                {
                    inputCopy[RR, i, j] = inImage[RR, i, j];
                    inputCopy[GG, i, j] = inImage[GG, i, j];
                    inputCopy[BB, i, j] = inImage[BB, i, j];
                }
            }
            //가장자리 처리
            fillEdges(tmpInput, inputCopy);
            //마스크 연산
            maskOP(tmpInput, tmpOutput, mask);
            //임시 출력 -> 원래 출력
            outCopy(tmpOutput);
            displayImage();
        }
        void sharpImage()
        {
            if (inImage == null)
            {
                return;
            }
            outH = inH;
            outW = inW;
            outImage = new byte[RGB, outH, outW];
            //마스크 결정
            double[,] mask = {
                { -1, -1, -1, -1, -1},
                { -1, -1, -1, -1, -1},
                { -1, -1, 24, -1, -1},
                { -1, -1, -1, -1, -1},
                { -1, -1, -1, -1, -1} };
            //임시 입력 출력 메모리 할당
            double[,,] tmpInput = new double[RGB, inH + 4, inW + 4];//확장된 메모리
            double[,,] inputCopy = new double[RGB, inH, inW];//가장자리 처리를 위한 복사본 메모리
            double[,,] tmpOutput = new double[RGB, inH, inW];//후처리를 위한 출력 메모리
            //입력 -> 복사본 복사
            for (int i = 0; i < inH; i++)
            {
                for (int j = 0; j < inW; j++)
                {
                    inputCopy[RR, i, j] = inImage[RR, i, j];
                    inputCopy[GG, i, j] = inImage[GG, i, j];
                    inputCopy[BB, i, j] = inImage[BB, i, j];
                }
            }
            //가장자리 처리
            fillEdges(tmpInput, inputCopy);
            //마스크 연산
            maskOP(tmpInput, tmpOutput, mask);
            //임시 출력 -> 원래 출력
            outCopy(tmpOutput);
            displayImage();
        }
        void morphologyOP(double[,,] tmpInput, double[,,] tmpOutput, int isErosion)
        { //침식(isErosion = 1) min 팽창(isErosion = 0) max 
            double min, max;
            for (int rgb = 0; rgb < RGB; rgb++)
            {
                for (int i = 2; i < inH + 2; i++)
                {
                    for (int j = 2; j < inW + 2; j++)
                    {
                        min = 255;
                        max = 0;
                        for (int k = 0; k < 5; k++)
                        {
                            for (int m = 0; m < 5; m++)
                            {
                                if (isErosion == 1)//침식
                                {
                                    if (tmpInput[rgb, i - 2 + k, j - 2 + m] < min)
                                    {
                                        min = tmpInput[rgb, i - 2 + k, j - 2 + m];
                                    }
                                }
                                else//팽창
                                {
                                    if (tmpInput[rgb, i - 2 + k, j - 2 + m] > max)
                                    {
                                        max = tmpInput[rgb, i - 2 + k, j - 2 + m];
                                    }
                                }
                            }
                        }
                        if (isErosion == 1)//침식
                        {
                            tmpOutput[rgb, i - 2, j - 2] = min;
                        }
                        else
                        {
                            tmpOutput[rgb, i - 2, j - 2] = max;
                        }
                    }
                }
            }
        }
        void erosion()
        {
            if (inImage == null)
            {
                return;
            }
            outH = inH;
            outW = inW;
            outImage = new byte[RGB, outH, outW];
            double[,,] tmpInput = new double[RGB, inH + 4, inW + 4];//확장된 메모리
            double[,,] inputCopy = new double[RGB, inH, inW];//가장자리 처리를 위한 복사본 메모리
            double[,,] tmpOutput = new double[RGB, inH, inW];//후처리를 위한 출력 메모리
            //입력 -> 복사본 복사
            for (int i = 0; i < inH; i++)
            {
                for (int j = 0; j < inW; j++)
                {
                    inputCopy[RR, i, j] = inImage[RR, i, j];
                    inputCopy[GG, i, j] = inImage[GG, i, j];
                    inputCopy[BB, i, j] = inImage[BB, i, j];
                }
            }
            //가장자리 처리
            fillEdges(tmpInput, inputCopy);
            morphologyOP(tmpInput, tmpOutput, 1);
            //임시 출력 -> 원래 출력
            outCopy(tmpOutput);
            displayImage();
        }
        void dilation()
        {
            if (inImage == null)
            {
                return;
            }
            outH = inH;
            outW = inW;
            outImage = new byte[RGB, outH, outW];
            double[,,] tmpInput = new double[RGB, inH + 4, inW + 4];//확장된 메모리
            double[,,] inputCopy = new double[RGB, inH, inW];//가장자리 처리를 위한 복사본 메모리
            double[,,] tmpOutput = new double[RGB, inH, inW];//후처리를 위한 출력 메모리
            //입력 -> 복사본 복사
            for (int i = 0; i < inH; i++)
            {
                for (int j = 0; j < inW; j++)
                {
                    inputCopy[RR, i, j] = inImage[RR, i, j];
                    inputCopy[GG, i, j] = inImage[GG, i, j];
                    inputCopy[BB, i, j] = inImage[BB, i, j];
                }
            }
            //가장자리 처리
            fillEdges(tmpInput, inputCopy);
            morphologyOP(tmpInput, tmpOutput, 0);
            //임시 출력 -> 원래 출력
            outCopy(tmpOutput);
            displayImage();
        }
        void opening()
        {
            if (inImage == null)
            {
                return;
            }
            outH = inH;
            outW = inW;
            outImage = new byte[RGB, outH, outW];
            double[,,] tmpInput = new double[RGB, inH + 4, inW + 4];//확장된 메모리
            double[,,] inputCopy = new double[RGB, inH, inW];//가장자리 처리를 위한 복사본 메모리
            double[,,] tmpOutput = new double[RGB, inH, inW];//후처리를 위한 출력 메모리
            //입력 -> 복사본 복사
            for (int i = 0; i < inH; i++)
            {
                for (int j = 0; j < inW; j++)
                {
                    inputCopy[RR, i, j] = inImage[RR, i, j];
                    inputCopy[GG, i, j] = inImage[GG, i, j];
                    inputCopy[BB, i, j] = inImage[BB, i, j];
                }
            }
            //가장자리 처리
            fillEdges(tmpInput, inputCopy);
            morphologyOP(tmpInput, tmpOutput, 1);
            //2번 가장차리 처리 연산을 위한 메모리 
            double[,,] outBufImage = new double[RGB, outH + 4, outW + 4];
            //가장자리 처리
            fillEdges(outBufImage, tmpOutput);
            morphologyOP(outBufImage, tmpOutput, 0);
            //임시 출력 -> 원래 출력
            outCopy(tmpOutput);
            displayImage();
        }
        void closing()
        {
            if (inImage == null)
            {
                return;
            }
            outH = inH;
            outW = inW;
            outImage = new byte[RGB, outH, outW];
            double[,,] tmpInput = new double[RGB, inH + 4, inW + 4];//확장된 메모리
            double[,,] inputCopy = new double[RGB, inH, inW];//가장자리 처리를 위한 복사본 메모리
            double[,,] tmpOutput = new double[RGB, inH, inW];//후처리를 위한 출력 메모리
            //입력 -> 복사본 복사
            for (int i = 0; i < inH; i++)
            {
                for (int j = 0; j < inW; j++)
                {
                    inputCopy[RR, i, j] = inImage[RR, i, j];
                    inputCopy[GG, i, j] = inImage[GG, i, j];
                    inputCopy[BB, i, j] = inImage[BB, i, j];
                }
            }
            //가장자리 처리
            fillEdges(tmpInput, inputCopy);
            morphologyOP(tmpInput, tmpOutput, 0);
            //2번 가장차리 처리 연산을 위한 메모리 
            double[,,] outBufImage = new double[RGB, outH + 4, outW + 4];
            //가장자리 처리
            fillEdges(outBufImage, tmpOutput);
            morphologyOP(outBufImage, tmpOutput, 1);
            //임시 출력 -> 원래 출력
            outCopy(tmpOutput);
            displayImage();
        }
        void medianFilter()
        {//노이즈 제거 알고리즘 노이즈 이미지 저장기능 구현하지 않음
            if (inImage == null)
            {
                return;
            }
            outH = inH;
            outW = inW;
            outImage = new byte[RGB, outH, outW];
            double[,,] tmpInput = new double[RGB, inH + 4, inW + 4];//확장된 메모리
            double[,,] inputCopy = new double[RGB, inH, inW];//가장자리 처리를 위한 복사본 메모리
            double[,,] tmpOutput = new double[RGB, inH, inW];//후처리를 위한 출력 메모리
            //입력 -> 복사본 복사
            for (int i = 0; i < inH; i++)
            {
                for (int j = 0; j < inW; j++)
                {
                    inputCopy[RR, i, j] = inImage[RR, i, j];
                    inputCopy[GG, i, j] = inImage[GG, i, j];
                    inputCopy[BB, i, j] = inImage[BB, i, j];
                }
            }
            int amount = 13;//잡음 개수 조절
                            //가로 x 세로 x (amout / 100)
            int noiseCount = (int)(inH * inW * ((double)amount / 100));
            salt_pepper(noiseCount, inputCopy);//영상에 잡음추가
            //잡음 이미지 출력
            for (int i = 0; i < inH; i++)
            {
                for (int j = 0; j < inW; j++)
                {
                    outImage[RR, i, j] = (byte)inputCopy[RR, i, j];
                    outImage[GG, i, j] = (byte)inputCopy[GG, i, j];
                    outImage[BB, i, j] = (byte)inputCopy[BB, i, j];
                }
            }
            displayImage();
            Delay(3000);
            fillEdges(tmpInput, inputCopy);
            int sortSize = 5;
            byte[] medianSort = new byte[sortSize * sortSize];//정렬을 위한 1차원 배열
            //inImage 값이 아닌 노이즈가 생긴 tmpInput 값을 가져온다.
            int temp = 0;//임시변수(배열 인덱스 값)
            for (int rgb = 0; rgb < RGB; rgb++)
            {
                for (int i = 2; i < inH + 2; i++)
                {//엣지는 처리하지 않음
                    for (int j = 2; j < inW + 2; j++)
                    {
                        temp = 0;
                        for (int k = 0; k < sortSize; k++)
                        {
                            for (int m = 0; m < sortSize; m++)
                            {
                                medianSort[temp++] = (byte)tmpInput[rgb, i - 2 + k, j - 2 + m];
                            }
                        }
                        Array.Sort(medianSort);
                        outImage[rgb, i - 2, j - 2] = medianSort[(sortSize * sortSize) / 2];//중간 값으로 출력
                    }
                }
            }
            //제거 이미지 출력
            displayImage();
        }
        //프로그램 ms만큼 대기
        private DateTime Delay(int MS)
        {
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime AfterWards = ThisMoment.Add(duration);

            while (AfterWards >= ThisMoment)
            {
                System.Windows.Forms.Application.DoEvents();
                ThisMoment = DateTime.Now;
            }

            return DateTime.Now;
        }
        void salt_pepper(int noiseCount, double[,,] inputCopy)
        {//영상에 잡음 추가
            Random r = new Random();
            int salt_or_pepper;
            int row, col;
            //잡음 추가
            for (int i = 0; i < noiseCount; i++)
            {
                row = r.Next(0, inH);
                col = r.Next(0, inW);
                // 랜덤하게 0 또는 255, 0이면 후추, 255면 소금
                salt_or_pepper = r.Next(0, 2) * 255;
                inputCopy[RR, row, col] = salt_or_pepper;
                inputCopy[GG, row, col] = salt_or_pepper;
                inputCopy[BB, row, col] = salt_or_pepper;
            }
        }
        void drawHistogram()
        {
            long[] rHisto = new long[256];
            long[] gHisto = new long[256];
            long[] bHisto = new long[256];
            for (int i = 0; i < outH; i++)
            {
                for (int j = 0; j < outW; j++)
                {
                    rHisto[outImage[RR, i, j]]++;
                    gHisto[outImage[GG, i, j]]++;
                    bHisto[outImage[BB, i, j]]++;
                }
            }
            HistoForm hform = new HistoForm(rHisto, gHisto, bHisto);
            hform.ShowDialog();
        }
        //이미지 최대, 최소, 합계, 평균값 반환 함수
        private (byte rMin, byte rMax, byte gMin, 
            byte gMax, byte bMin, byte bMax, 
            long rSum, long gSum, long bSum, 
            double rAvg, double gAvg, double bAvg) calculImage()
        {
            byte rMin = 255;
            byte rMax = 0;
            byte gMin = 255;
            byte gMax = 0;
            byte bMin = 255;
            byte bMax = 0;
            long rSum = 0;
            long gSum = 0;
            long bSum = 0;
            for(int i = 0; i < inH; i++)
            {
                for(int j = 0; j < inW; j++)
                {
                    rSum += inImage[RR, i, j];
                    gSum += inImage[GG, i, j];
                    bSum += inImage[BB, i, j];
                    if (rMin > inImage[RR, i, j])
                    {
                        rMin = inImage[RR, i, j];
                    }
                    if (gMin > inImage[GG, i, j])
                    {
                        gMin = inImage[GG, i, j];
                    }
                    if (bMin > inImage[BB, i, j])
                    {
                        bMin = inImage[BB, i, j];
                    }
                    if (rMax < inImage[RR, i, j])
                    {
                        rMax = inImage[RR, i, j];
                    }
                    if (gMax < inImage[GG, i, j])
                    {
                        gMax = inImage[GG, i, j];
                    }
                    if (bMax < inImage[BB, i, j])
                    {
                        bMax = inImage[BB, i, j];
                    }
                }
            }
            double rAvg = rSum / ((double)inH * inW);
            double gAvg = gSum / ((double)inH * inW);
            double bAvg = bSum / ((double)inH * inW);
            return (rMin, rMax, gMin, gMax, bMin, bMax, rSum, gSum, bSum, rAvg, gAvg, bAvg);
        }
        void stretching()
        {
            if (inImage == null)
                return;
            outH = inH;
            outW = inW;
            outImage = new byte[RGB, outH, outW];
            var findMinMax = calculImage();
            byte rMin = findMinMax.rMin;
            byte rMax = findMinMax.rMax;
            byte gMin = findMinMax.gMin;
            byte gMax = findMinMax.gMax;
            byte bMin = findMinMax.bMin;
            byte bMax = findMinMax.bMax;
            for (int i = 0; i < inH; i++)
            {
                for (int j = 0; j < inW; j++)
                {
                    outImage[RR, i, j] = (byte)(((double)(inImage[RR, i, j] - rMin) / (rMax - rMin)) * 255);
                    outImage[GG, i, j] = (byte)(((double)(inImage[GG, i, j] - gMin) / (gMax - gMin)) * 255);
                    outImage[BB, i, j] = (byte)(((double)(inImage[BB, i, j] - bMin) / (bMax - bMin)) * 255);
                }
            }
            displayImage();
        }
        void endInSearch()
        {
            if (inImage == null)
                return;
            outH = inH;
            outW = inW;
            outImage = new byte[RGB, outH, outW];
            var findMinMax = calculImage();
            int rMin = findMinMax.rMin - 50;
            int rMax = findMinMax.rMax + 50;
            int gMin = findMinMax.gMin - 50;
            int gMax = findMinMax.gMax + 50;
            int bMin = findMinMax.bMin - 50;
            int bMax = findMinMax.bMax + 50;
            //min max값을 강제로 변경
            for (int i = 0; i < inH; i++)
            {
                for (int j = 0; j < inW; j++)
                {
                    double rValue = ((double)(inImage[RR, i, j] - rMin) / (rMax - rMin)) * 255;
                    double gValue = ((double)(inImage[GG, i, j] - gMin) / (gMax - gMin)) * 255;
                    double bValue = ((double)(inImage[BB, i, j] - bMin) / (bMax - bMin)) * 255;
                    if (rValue > 255)
                    {
                        rValue = 255;
                    }
                    else if (rValue < 0)
                    {
                        rValue = 0;
                    }
                    if (gValue > 255)
                    {
                        gValue = 255;
                    }
                    else if (gValue < 0)
                    {
                        gValue = 0;
                    }
                    if (bValue > 255)
                    {
                        bValue = 255;
                    }
                    else if (bValue < 0)
                    {
                        bValue = 0;
                    }
                    outImage[RR, i, j] = (byte)rValue;
                    outImage[GG, i, j] = (byte)gValue;
                    outImage[BB, i, j] = (byte)bValue;
                }
            }
            displayImage();
        }
        void equalized()
        {
            if (inImage == null)
                return;
            outH = inH;
            outW = inW;
            outImage = new byte[RGB, outH, outW];
            //히스토그램 생성
            long[] rHist = new long[256];
            long[] rHistSum = new long[256];
            long[] gHist = new long[256];
            long[] gHistSum = new long[256];
            long[] bHist = new long[256];
            long[] bHistSum = new long[256];
            for (int i = 0; i < rHist.Length; i++)
            {
                rHist[i] = 0;
                rHistSum[i] = 0;
                gHist[i] = 0;
                gHistSum[i] = 0;
                bHist[i] = 0;
                bHistSum[i] = 0;
            }
            for (int i = 0; i < inH; i++)
            {
                for (int j = 0; j < inW; j++)
                {
                    rHist[inImage[RR, i, j]]++;
                    gHist[inImage[GG, i, j]]++;
                    bHist[inImage[BB, i, j]]++;
                }
            }
            //누적합 생성
            long copy = rHist[0];
            rHistSum[0] = copy;
            copy = gHist[0];
            gHistSum[0] = copy;
            copy = bHist[0];
            bHistSum[0] = copy;
            for (int i = 1; i < rHistSum.Length; i++)
            {
                rHistSum[i] = (rHistSum[i - 1] + rHist[i]);
                gHistSum[i] = (gHistSum[i - 1] + gHist[i]);
                bHistSum[i] = (bHistSum[i - 1] + bHist[i]);
            }
            //정규화된 누적합 생성
            for (int i = 0; i < inH; i++)
            {
                for (int j = 0; j < inW; j++)
                {
                    outImage[RR, i, j] = (byte)(rHistSum[inImage[RR, i, j]] / (double)(inH * inW) * 255);
                    outImage[GG, i, j] = (byte)(rHistSum[inImage[GG, i, j]] / (double)(inH * inW) * 255);
                    outImage[BB, i, j] = (byte)(rHistSum[inImage[BB, i, j]] / (double)(inH * inW) * 255);
                }
            }
            displayImage();
        }
        void undoImage()
        {
            if(undoList.Count < 2)
            {
                return;
            }
            redoList.Add(undoList[undoList.Count - 1]);
            undoList.RemoveAt(undoList.Count - 1);
            inImage = (byte[,,])undoList[undoList.Count - 1].Clone();
            isUndo = true;
            equal_image();
            isUndo = false;
        }
        void redoImage()
        {
            if (redoList.Count < 1)
            {
                return;
            }
            undoList.Add(redoList[redoList.Count - 1]);
            inImage = (byte[,,])undoList[undoList.Count - 1].Clone();
            redoList.RemoveAt(redoList.Count - 1);
            isUndo = true;
            equal_image();
            isUndo = false;
        }
    }
}
