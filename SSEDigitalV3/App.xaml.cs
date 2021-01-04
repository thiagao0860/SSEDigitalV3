using SSEDigitalV3.DataCore;
using SSEDigitalV3.ExcelIntegration;
using SSEDigitalV3.GlobalTools;
using SSEDigitalV3.MainDBConnector;
using SSEDigitalV3.NewSSEInterface;
using SSEDigitalV3.UserDBConnector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SSEDigitalV3
{
    /// <summary>
    /// Interação lógica para App.xaml
    /// </summary>
    public partial class    App : Application
    {
        public static string KEY_MAIN_OPTION = "main_option";
        public static string KEY_USER_TAG = "user_tag";

        private SQLiteUserConnector connector;
        public App()
        {
            
            connector = new SQLiteUserConnector();
            
            SSEMainDBConnector mainDBConnector = new SSEMainDBConnector();
            /*
            for (int i = 500; i < 600; i++)
            {
                SSEDBWrapper sSEBean = GetSSEFromDeprecatedExcel.getInstance().findDBById(i.ToString());
                mainDBConnector.insertSSE(sSEBean, sSEBean.id);
                Console.WriteLine(sSEBean.id + " inserted");
                //(new PrinterTools(sSEBean)).printSSE();
            }
            */
            
            if (MainConstants.getInstance().version_enabled == 1)
            {
                (new SSEdigital()).ShowDialog();
            }
            if (MainConstants.getInstance().version_enabled == 2)
            {
                Intent intent = new Intent();
                SQLiteUserConnector db = new SQLiteUserConnector();
                Int32 index = db.GetUserIDbyMAC(MACTriger.getUniqueCode());
                if (index > 0)
                {
                    if (MainConstants.getInstance().loged_User != null)
                    {
                        (new MainWindow(MainConstants.getInstance().loged_User)).ShowDialog();
                        return;
                    }
                    else
                    {
                        intent.putValue("user_id", index.ToString());
                        (new MainWindow(ref intent)).ShowDialog();
                        return;
                    }
                }
                if (index == SQLiteUserConnector.NULL_MAC_CODE)
                {
                    (new SSEdigital()).ShowDialog();
                    return;
                }
                Info info_request = new Info(ref intent);
                info_request.ShowDialog();
                string returned_value = intent.getString(App.KEY_MAIN_OPTION);
                if (returned_value != null)
                {
                    if (returned_value.Equals(Info.USE_V1_OPTION))
                    {
                        if (intent.getString("dont_ask").Equals("true"))
                        {
                            db.InsertNullMAC(MACTriger.getUniqueCode());
                            Console.WriteLine(MACTriger.getUniqueCode());
                        }
                        (new SSEdigital()).ShowDialog();
                    }
                    else if (returned_value.Equals(Info.NEW_USER_CREATED_OPTION))
                    {
                        if (MainConstants.getInstance().loged_User != null)
                        {
                            (new MainWindow(MainConstants.getInstance().loged_User)).ShowDialog();
                        }
                        else
                        {
                            index = db.GetUserIDbyMAC(MACTriger.getUniqueCode());
                            intent.putValue("user_id", index.ToString());
                            (new MainWindow(ref intent)).ShowDialog();
                        }
                    }
                    else if (returned_value.Equals(Info.USER_IN_OPTION))
                    {
                        if (MainConstants.getInstance().loged_User != null)
                        {
                            (new MainWindow(MainConstants.getInstance().loged_User)).ShowDialog();
                        }
                        else
                        {
                            index = db.GetUserIDbyMAC(MACTriger.getUniqueCode());
                            intent.putValue("user_id", index.ToString());
                            (new MainWindow(ref intent)).ShowDialog();
                        }
                    }
                   
                }
            }
            
        }
    }

}
