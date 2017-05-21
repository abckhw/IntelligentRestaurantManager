﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using IntelligentRestaurantManager.Model;
using IntelligentRestaurantManager.BLL;
using IntelligentRestaurantManager.UI;

namespace IntelligentRestaurantManager
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Staff currentStaff = new Staff();
            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                currentStaff = loginForm.currentStaff;
                DiningArea diningArea = new DiningArea(currentStaff);
                loginForm.Close();
                if (currentStaff.Role == StaffRole.Manager)
                {
                    MessageBox.Show(string.Format("Welcome {0}! Your role is {1}", currentStaff.Name, currentStaff.Role));
                }
                else if (currentStaff.Role == StaffRole.Waiter)
                {
                    Application.Run(new TabelStatusForm(diningArea));
                }
                else if (currentStaff.Role == StaffRole.Cook)
                {
                    MessageBox.Show(string.Format("Welcome {0}! Your role is {1}", currentStaff.Name, currentStaff.Role));
                }
                else
                {
                    MessageBox.Show(string.Format("Welcome {0}! Your role is {1}. And you will see customer UI.", currentStaff.Name, currentStaff.Role));
                }
            }

            ////test db
            //IntelligentRestaurantManager.Model.Staff staff = new Model.Staff();
            //DAL.StaffService staffService = new DAL.StaffService();
            //staff = staffService.GetByName("manager1");
            //MessageBox.Show(staff.Password + staff.Role);
            ////test int[] to string
            //int[] tableIds = new int[] { 1, 2, 3, 4, 5 };

            //MessageBox.Show(string.Join(",", tableIds));
        }
    }
}
