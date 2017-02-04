using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mclauncher
{
    class readjson
    {
        public ArrayList IndexOfAll(string input,string x)//完成
        {
            ArrayList temp1 = new ArrayList();
            int count = -1;
            do//do while 循环
            {
                temp1.Add(input.IndexOf(x, count + 1));
                count = Convert.ToInt32(temp1[temp1.Count - 1]);
            }
            while (count != -1);
            temp1.RemoveAt(temp1.Count - 1);
            return temp1;
        }
        public ArrayList IndexOfAll(string input, string x,int StartIndex,int EndIndex)//完成
        {
            input = input.Substring(StartIndex, EndIndex - StartIndex + 1);
            ArrayList temp1 = new ArrayList();
            int count = -1;
            do//do while 循环
            {
                temp1.Add(input.IndexOf(x, count + 1) + StartIndex);
                count = Convert.ToInt32(temp1[temp1.Count - 1]) - StartIndex;
            }
            while (count != -1);
            temp1.RemoveAt(temp1.Count - 1);
            return temp1;
        }
        public int analysis(string input,string start,string end)//返回找到的与第一个start的end的位置
        {
            ArrayList endlocation = IndexOfAll(input, end);
            int temp = 0;//计分板
            foreach(object each in endlocation)
            {
                temp++;
                if (IndexOfAll(input.Substring(0, Convert.ToInt32(each) + 1),start).Count==temp)
                {
                    return Convert.ToInt32(each);//返回找到的第一个
                }
            }
            return -1;//没有找到
        }
    }
}
