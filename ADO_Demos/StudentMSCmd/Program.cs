using System;

namespace StudentMSCmd
{
    class Program
    {
        //主菜单选择
        static int select = 0;
        //程序运行控制
        static bool exit = true;

        static void Main(string[] args)
        {
            Console.Title = "Student 校务数据管理平台 ----- 功能测试模块  版本：v1.0";
            do
            {
                Console.Clear();
                Console.WriteLine("\nStudent 校务数据管理平台 ----- 功能测试模块\n");
                Console.WriteLine("=============================================\n");
                Console.WriteLine("1.读取数据表\t\n");
                Console.WriteLine("0.退出程序\n");
                Console.WriteLine("=============================================\n");
                Console.Write("请选择：");
                select = Convert.ToInt32(Console.ReadLine());

                switch (select)
                {
                    case 0:
                        exit = false;
                        break;
                    case 1:
                        Console.Clear();
                        Console.WriteLine("\n主菜单 > 读取数据表");
                        Console.WriteLine("\n=============================================\n");
                        Console.WriteLine("1.Studnet 学生表\t2.Teacher 教师表\n");
                        Console.WriteLine("3.classInfo 班级表\t4.Course 课程表\n");
                        Console.WriteLine("5.SC_Mapping 成绩表\t6.system_users 登录用户表\n");
                        Console.WriteLine("\n=============================================\n");
                        Console.Write("请选择：");
                        select = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 2:

                        break;
                    case 3:

                        break;
                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n输入的参数有误!!请重新输入...\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("按任意键继续");
                        Console.ReadLine();
                        break;
                }
            } while (exit == true);
            //退出模块
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n程序退出，感谢您的使用 *^_^* ...\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("按任意键继续");
            Console.ReadLine();
        }
    }
}
