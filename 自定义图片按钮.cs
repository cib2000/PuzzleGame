using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
namespace ImageGame
{
    class 自定义图片按钮:Button
    {
        private int 行;
        private int 列;
        private int 小图片宽度;
        private int 小图片高度;
        private int 第几张图片;
        private Bitmap 图片来源;

        public 自定义图片按钮(int 第几张图片, Bitmap 图片来源)
        {
            this.第几张图片 = 第几张图片;
            this.图片来源 = 图片来源;
            初始化();

            //修改按钮外观();
            修改按钮背景();

            //双击图片退出程序
            this.Click += (object sender, EventArgs e) =>
            {
                Application.Exit();
            };
        }  

        /// <summary>
        /// 
        /// </summary>
        private void 初始化()
        {
            小图片宽度 =  图片来源.Width / 3;
            小图片高度 =  图片来源.Height / 3;
            列 = 第几张图片 % 3 == 0 ? 2 : (第几张图片 % 3 - 1);
            行 = 第几张图片 > 6 ? 2 : (第几张图片 > 3 ? 1 : 0);
        }

        /// <summary>
        /// 
        /// </summary>
        private void 修改按钮外观()
        {            
            this.Width = 图片来源.Width;
            this.Height =图片来源.Height;
            this.BackgroundImage = 图片来源;
            this.Region = 创建小图片区域();                       
        }

        private void 修改按钮背景()
        {
            this.Width = 小图片宽度;
            this.Height = 小图片高度;
            this.Location = new Point(列 * 小图片宽度, 行 * 小图片高度);
            this.BackgroundImage = 创建小图片();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Region 创建小图片区域()
        {
            Region 小图片区域;
            GraphicsPath 小图片轮廓 = new GraphicsPath();
            小图片轮廓.AddRectangle(new Rectangle(列 * 小图片宽度, 行 * 小图片高度, 小图片宽度, 小图片高度));
            小图片区域 = new Region(小图片轮廓);
            小图片轮廓.Dispose();
            return 小图片区域;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Bitmap 创建小图片()
        {
            Bitmap 画布 = new Bitmap(小图片宽度, 小图片高度,PixelFormat.Format32bppRgb);
            Graphics 画图 = Graphics.FromImage(画布);

            //拷贝图片区域
            画图.DrawImage(图片来源, new Rectangle(0, 0, 小图片宽度, 小图片高度), new Rectangle(列 * 小图片宽度, 行 * 小图片高度, 小图片宽度, 小图片高度), GraphicsUnit.Pixel);
            return 画布;
        }


    }
}
