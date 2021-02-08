
namespace Day015_01_color
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.파일ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.열기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.저장ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.화소점ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.동일이미지ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.밝게어둡게ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.그레이스케일ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.반전이미지ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.반전선택ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.이진화ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.기하학처리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.확대ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.축소ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.회전ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.영역처리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.엠보싱ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.블러링ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.샤프닝ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.미디언필터ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.모폴로지ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.erosionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dilationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.히스토그램ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.히스토그램그리기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.스트레칭ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.평활화ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.엔드인탐색ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.실행취소ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.다시실행ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일ToolStripMenuItem,
            this.화소점ToolStripMenuItem,
            this.기하학처리ToolStripMenuItem,
            this.영역처리ToolStripMenuItem,
            this.모폴로지ToolStripMenuItem,
            this.히스토그램ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1000, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 파일ToolStripMenuItem
            // 
            this.파일ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.열기ToolStripMenuItem,
            this.저장ToolStripMenuItem,
            this.종료ToolStripMenuItem,
            this.실행취소ToolStripMenuItem,
            this.다시실행ToolStripMenuItem});
            this.파일ToolStripMenuItem.Name = "파일ToolStripMenuItem";
            this.파일ToolStripMenuItem.Size = new System.Drawing.Size(64, 29);
            this.파일ToolStripMenuItem.Text = "파일";
            // 
            // 열기ToolStripMenuItem
            // 
            this.열기ToolStripMenuItem.Name = "열기ToolStripMenuItem";
            this.열기ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.열기ToolStripMenuItem.Text = "열기";
            this.열기ToolStripMenuItem.Click += new System.EventHandler(this.열기ToolStripMenuItem_Click);
            // 
            // 저장ToolStripMenuItem
            // 
            this.저장ToolStripMenuItem.Name = "저장ToolStripMenuItem";
            this.저장ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.저장ToolStripMenuItem.Text = "저장";
            this.저장ToolStripMenuItem.Click += new System.EventHandler(this.저장ToolStripMenuItem_Click);
            // 
            // 종료ToolStripMenuItem
            // 
            this.종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            this.종료ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.종료ToolStripMenuItem.Text = "종료";
            // 
            // 화소점ToolStripMenuItem
            // 
            this.화소점ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.동일이미지ToolStripMenuItem,
            this.밝게어둡게ToolStripMenuItem,
            this.그레이스케일ToolStripMenuItem,
            this.반전이미지ToolStripMenuItem,
            this.반전선택ToolStripMenuItem,
            this.이진화ToolStripMenuItem});
            this.화소점ToolStripMenuItem.Name = "화소점ToolStripMenuItem";
            this.화소점ToolStripMenuItem.Size = new System.Drawing.Size(82, 29);
            this.화소점ToolStripMenuItem.Text = "화소점";
            // 
            // 동일이미지ToolStripMenuItem
            // 
            this.동일이미지ToolStripMenuItem.Name = "동일이미지ToolStripMenuItem";
            this.동일이미지ToolStripMenuItem.Size = new System.Drawing.Size(228, 34);
            this.동일이미지ToolStripMenuItem.Text = "동일 이미지";
            this.동일이미지ToolStripMenuItem.Click += new System.EventHandler(this.동일이미지ToolStripMenuItem_Click);
            // 
            // 밝게어둡게ToolStripMenuItem
            // 
            this.밝게어둡게ToolStripMenuItem.Name = "밝게어둡게ToolStripMenuItem";
            this.밝게어둡게ToolStripMenuItem.Size = new System.Drawing.Size(228, 34);
            this.밝게어둡게ToolStripMenuItem.Text = "밝게 / 어둡게";
            this.밝게어둡게ToolStripMenuItem.Click += new System.EventHandler(this.밝게어둡게ToolStripMenuItem_Click);
            // 
            // 그레이스케일ToolStripMenuItem
            // 
            this.그레이스케일ToolStripMenuItem.Name = "그레이스케일ToolStripMenuItem";
            this.그레이스케일ToolStripMenuItem.Size = new System.Drawing.Size(228, 34);
            this.그레이스케일ToolStripMenuItem.Text = "그레이 스케일";
            this.그레이스케일ToolStripMenuItem.Click += new System.EventHandler(this.그레이스케일ToolStripMenuItem_Click);
            // 
            // 반전이미지ToolStripMenuItem
            // 
            this.반전이미지ToolStripMenuItem.Name = "반전이미지ToolStripMenuItem";
            this.반전이미지ToolStripMenuItem.Size = new System.Drawing.Size(228, 34);
            this.반전이미지ToolStripMenuItem.Text = "반전 이미지";
            this.반전이미지ToolStripMenuItem.Click += new System.EventHandler(this.반전이미지ToolStripMenuItem_Click);
            // 
            // 반전선택ToolStripMenuItem
            // 
            this.반전선택ToolStripMenuItem.Name = "반전선택ToolStripMenuItem";
            this.반전선택ToolStripMenuItem.Size = new System.Drawing.Size(228, 34);
            this.반전선택ToolStripMenuItem.Text = "반전 선택";
            this.반전선택ToolStripMenuItem.Click += new System.EventHandler(this.반전선택ToolStripMenuItem_Click);
            // 
            // 이진화ToolStripMenuItem
            // 
            this.이진화ToolStripMenuItem.Name = "이진화ToolStripMenuItem";
            this.이진화ToolStripMenuItem.Size = new System.Drawing.Size(228, 34);
            this.이진화ToolStripMenuItem.Text = "이진화";
            this.이진화ToolStripMenuItem.Click += new System.EventHandler(this.이진화ToolStripMenuItem_Click);
            // 
            // 기하학처리ToolStripMenuItem
            // 
            this.기하학처리ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.확대ToolStripMenuItem,
            this.축소ToolStripMenuItem,
            this.회전ToolStripMenuItem});
            this.기하학처리ToolStripMenuItem.Name = "기하학처리ToolStripMenuItem";
            this.기하학처리ToolStripMenuItem.Size = new System.Drawing.Size(124, 29);
            this.기하학처리ToolStripMenuItem.Text = "기하학 처리";
            // 
            // 확대ToolStripMenuItem
            // 
            this.확대ToolStripMenuItem.Name = "확대ToolStripMenuItem";
            this.확대ToolStripMenuItem.Size = new System.Drawing.Size(150, 34);
            this.확대ToolStripMenuItem.Text = "확대";
            this.확대ToolStripMenuItem.Click += new System.EventHandler(this.확대ToolStripMenuItem_Click);
            // 
            // 축소ToolStripMenuItem
            // 
            this.축소ToolStripMenuItem.Name = "축소ToolStripMenuItem";
            this.축소ToolStripMenuItem.Size = new System.Drawing.Size(150, 34);
            this.축소ToolStripMenuItem.Text = "축소";
            this.축소ToolStripMenuItem.Click += new System.EventHandler(this.축소ToolStripMenuItem_Click);
            // 
            // 회전ToolStripMenuItem
            // 
            this.회전ToolStripMenuItem.Name = "회전ToolStripMenuItem";
            this.회전ToolStripMenuItem.Size = new System.Drawing.Size(150, 34);
            this.회전ToolStripMenuItem.Text = "회전";
            this.회전ToolStripMenuItem.Click += new System.EventHandler(this.회전ToolStripMenuItem_Click);
            // 
            // 영역처리ToolStripMenuItem
            // 
            this.영역처리ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.엠보싱ToolStripMenuItem,
            this.블러링ToolStripMenuItem,
            this.샤프닝ToolStripMenuItem,
            this.미디언필터ToolStripMenuItem});
            this.영역처리ToolStripMenuItem.Name = "영역처리ToolStripMenuItem";
            this.영역처리ToolStripMenuItem.Size = new System.Drawing.Size(106, 29);
            this.영역처리ToolStripMenuItem.Text = "영역 처리";
            // 
            // 엠보싱ToolStripMenuItem
            // 
            this.엠보싱ToolStripMenuItem.Name = "엠보싱ToolStripMenuItem";
            this.엠보싱ToolStripMenuItem.Size = new System.Drawing.Size(210, 34);
            this.엠보싱ToolStripMenuItem.Text = "엠보싱";
            this.엠보싱ToolStripMenuItem.Click += new System.EventHandler(this.엠보싱ToolStripMenuItem_Click);
            // 
            // 블러링ToolStripMenuItem
            // 
            this.블러링ToolStripMenuItem.Name = "블러링ToolStripMenuItem";
            this.블러링ToolStripMenuItem.Size = new System.Drawing.Size(210, 34);
            this.블러링ToolStripMenuItem.Text = "블러링";
            this.블러링ToolStripMenuItem.Click += new System.EventHandler(this.블러링ToolStripMenuItem_Click);
            // 
            // 샤프닝ToolStripMenuItem
            // 
            this.샤프닝ToolStripMenuItem.Name = "샤프닝ToolStripMenuItem";
            this.샤프닝ToolStripMenuItem.Size = new System.Drawing.Size(210, 34);
            this.샤프닝ToolStripMenuItem.Text = "샤프닝";
            this.샤프닝ToolStripMenuItem.Click += new System.EventHandler(this.샤프닝ToolStripMenuItem_Click);
            // 
            // 미디언필터ToolStripMenuItem
            // 
            this.미디언필터ToolStripMenuItem.Name = "미디언필터ToolStripMenuItem";
            this.미디언필터ToolStripMenuItem.Size = new System.Drawing.Size(210, 34);
            this.미디언필터ToolStripMenuItem.Text = "미디언 필터";
            this.미디언필터ToolStripMenuItem.Click += new System.EventHandler(this.미디언필터ToolStripMenuItem_Click);
            // 
            // 모폴로지ToolStripMenuItem
            // 
            this.모폴로지ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.erosionToolStripMenuItem,
            this.dilationToolStripMenuItem,
            this.openingToolStripMenuItem,
            this.closingToolStripMenuItem});
            this.모폴로지ToolStripMenuItem.Name = "모폴로지ToolStripMenuItem";
            this.모폴로지ToolStripMenuItem.Size = new System.Drawing.Size(100, 29);
            this.모폴로지ToolStripMenuItem.Text = "모폴로지";
            // 
            // erosionToolStripMenuItem
            // 
            this.erosionToolStripMenuItem.Name = "erosionToolStripMenuItem";
            this.erosionToolStripMenuItem.Size = new System.Drawing.Size(184, 34);
            this.erosionToolStripMenuItem.Text = "Erosion";
            this.erosionToolStripMenuItem.Click += new System.EventHandler(this.erosionToolStripMenuItem_Click);
            // 
            // dilationToolStripMenuItem
            // 
            this.dilationToolStripMenuItem.Name = "dilationToolStripMenuItem";
            this.dilationToolStripMenuItem.Size = new System.Drawing.Size(184, 34);
            this.dilationToolStripMenuItem.Text = "Dilation";
            this.dilationToolStripMenuItem.Click += new System.EventHandler(this.dilationToolStripMenuItem_Click);
            // 
            // openingToolStripMenuItem
            // 
            this.openingToolStripMenuItem.Name = "openingToolStripMenuItem";
            this.openingToolStripMenuItem.Size = new System.Drawing.Size(184, 34);
            this.openingToolStripMenuItem.Text = "Opening";
            this.openingToolStripMenuItem.Click += new System.EventHandler(this.openingToolStripMenuItem_Click);
            // 
            // closingToolStripMenuItem
            // 
            this.closingToolStripMenuItem.Name = "closingToolStripMenuItem";
            this.closingToolStripMenuItem.Size = new System.Drawing.Size(184, 34);
            this.closingToolStripMenuItem.Text = "Closing";
            this.closingToolStripMenuItem.Click += new System.EventHandler(this.closingToolStripMenuItem_Click);
            // 
            // 히스토그램ToolStripMenuItem
            // 
            this.히스토그램ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.히스토그램그리기ToolStripMenuItem,
            this.스트레칭ToolStripMenuItem,
            this.평활화ToolStripMenuItem,
            this.엔드인탐색ToolStripMenuItem});
            this.히스토그램ToolStripMenuItem.Name = "히스토그램ToolStripMenuItem";
            this.히스토그램ToolStripMenuItem.Size = new System.Drawing.Size(118, 29);
            this.히스토그램ToolStripMenuItem.Text = "히스토그램";
            // 
            // 히스토그램그리기ToolStripMenuItem
            // 
            this.히스토그램그리기ToolStripMenuItem.Name = "히스토그램그리기ToolStripMenuItem";
            this.히스토그램그리기ToolStripMenuItem.Size = new System.Drawing.Size(264, 34);
            this.히스토그램그리기ToolStripMenuItem.Text = "히스토그램 그리기";
            this.히스토그램그리기ToolStripMenuItem.Click += new System.EventHandler(this.히스토그램그리기ToolStripMenuItem_Click);
            // 
            // 스트레칭ToolStripMenuItem
            // 
            this.스트레칭ToolStripMenuItem.Name = "스트레칭ToolStripMenuItem";
            this.스트레칭ToolStripMenuItem.Size = new System.Drawing.Size(264, 34);
            this.스트레칭ToolStripMenuItem.Text = "스트레칭";
            this.스트레칭ToolStripMenuItem.Click += new System.EventHandler(this.스트레칭ToolStripMenuItem_Click);
            // 
            // 평활화ToolStripMenuItem
            // 
            this.평활화ToolStripMenuItem.Name = "평활화ToolStripMenuItem";
            this.평활화ToolStripMenuItem.Size = new System.Drawing.Size(264, 34);
            this.평활화ToolStripMenuItem.Text = "평활화";
            this.평활화ToolStripMenuItem.Click += new System.EventHandler(this.평활화ToolStripMenuItem_Click);
            // 
            // 엔드인탐색ToolStripMenuItem
            // 
            this.엔드인탐색ToolStripMenuItem.Name = "엔드인탐색ToolStripMenuItem";
            this.엔드인탐색ToolStripMenuItem.Size = new System.Drawing.Size(264, 34);
            this.엔드인탐색ToolStripMenuItem.Text = "엔드-인 탐색";
            this.엔드인탐색ToolStripMenuItem.Click += new System.EventHandler(this.엔드인탐색ToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 508);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 18, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1000, 32);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(183, 25);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 37);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(268, 162);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // 실행취소ToolStripMenuItem
            // 
            this.실행취소ToolStripMenuItem.Name = "실행취소ToolStripMenuItem";
            this.실행취소ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.실행취소ToolStripMenuItem.Text = "실행 취소";
            this.실행취소ToolStripMenuItem.Click += new System.EventHandler(this.실행취소ToolStripMenuItem_Click);
            // 
            // 다시실행ToolStripMenuItem
            // 
            this.다시실행ToolStripMenuItem.Name = "다시실행ToolStripMenuItem";
            this.다시실행ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.다시실행ToolStripMenuItem.Text = "다시 실행";
            this.다시실행ToolStripMenuItem.Click += new System.EventHandler(this.다시실행ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 540);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "컬러영상처리";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 파일ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 열기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 저장ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 종료ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 화소점ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 동일이미지ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 밝게어둡게ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 그레이스케일ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem 반전이미지ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 반전선택ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 이진화ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 기하학처리ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 확대ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 축소ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 회전ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 영역처리ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 엠보싱ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 블러링ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 샤프닝ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 모폴로지ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem erosionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dilationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 미디언필터ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 히스토그램ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 히스토그램그리기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 스트레칭ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 평활화ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 엔드인탐색ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 실행취소ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 다시실행ToolStripMenuItem;
    }
}

