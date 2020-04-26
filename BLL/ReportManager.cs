using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

using DAL;
using Models;

namespace BLL
{
    public class ReportManager
    {
        ReportService objReportService = new ReportService();
        #region 1-第一个报表业务逻辑方法
        /// <summary>
        /// 获取报表所需数据
        /// </summary>
        /// <param name="projectId">传入需要的项目编号参数</param>
        /// <returns>返回列表</returns>
        public static List<Report1_PR> GetReport1(string projectId)
        {
          SqlDataReader ReportData = ReportService.GetReport1(projectId);
            List<Report1_PR> ReportDataList = new List<Report1_PR>();
            while (ReportData.Read())
            {
                ReportDataList.Add(new Report1_PR()
                {
                    BaseProjectName = ReportData["ProjectName"].ToString(),
                    ProjectRequestID = ReportData["BugID"].ToString(),
                    ProjectRequestName = ReportData["BugTitle"].ToString(),
                    StatusName= ReportData["ProgressStatusName"].ToString(),
                    DateCreated = Convert.ToDateTime( ReportData["DateCreated"])
                });
            }
            ReportData.Close();
            return ReportDataList;
        }

        /// <summary>
        /// 获得第一个报表所需的HTML
        /// </summary>
        /// <param name="reportDataList">报表所需的数据</param>
        /// <returns>返回第一个报表所需的HTML</returns>
        public static StringBuilder GetReportByHTML(List<Report1_PR> reportDataList)
        {
            if (reportDataList.Count == 0)
                return null;

            //写报表头部
            StringBuilder sbReportHTML = new StringBuilder(@"<table class='report_table' style='width:100%; text-align:left' >");
            sbReportHTML.Append("<tr><th>项目名称</th><th>任务编号</th><th>任务名称</th><th>任务状态</th></tr>");
            sbReportHTML.Append("<tbody>");

            for (int i = 0; i < reportDataList.Count; i++)
            {
                sbReportHTML.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td>", reportDataList[i].BaseProjectName, reportDataList[i].ProjectRequestID, reportDataList[i].ProjectRequestName, reportDataList[i].StatusName);
            }

            sbReportHTML.AppendFormat("</tbody></table>");

            return sbReportHTML;
        }

        #endregion

        #region 2-第二个报表业务逻辑方法
        /// <summary>
        /// 提供报表下拉列表数据
        /// </summary>
        /// <returns></returns>
        protected List<Report2_Project> GetReport2_Project()
        {
            SqlDataReader ReportData = objReportService.GetReport2_Project();
            List<Report2_Project> ReportDataList = new List<Report2_Project>();
            while (ReportData.Read())
            {
                ReportDataList.Add( new Report2_Project()
                {
                    ProjectID = ReportData["ProjectID"].ToString(),
                    ProjectName = ReportData["ProjectName"].ToString()
                });
            }
            ReportData.Close();
            return ReportDataList;
        }

        public string BindChoices()
        {
            StringBuilder ChoiceHtml = new StringBuilder();
            List<Report2_Project> ProjectList = new ReportManager().GetReport2_Project();
            if (ProjectList.Count==0)
            {
                return string.Empty;
            }
           
            foreach (Report2_Project item in ProjectList)
            {
                ChoiceHtml.AppendFormat("<option value=\"{0}\">{1}</option>", item.ProjectID,item.ProjectName);
            }
            return ChoiceHtml.ToString();
        }

        protected static List<Report2_TaskInfo> GetReport2_ReportData(string multiSelectProjectChoice)
        {
            SqlDataReader ReportData = ReportService.GetReport2_ReportData(multiSelectProjectChoice);
            List<Report2_TaskInfo> ReportDataList = new List<Report2_TaskInfo>();

            while (ReportData.Read())
            {
                ReportDataList.Add(new Report2_TaskInfo()
                {
                   ProjectID = ReportData["ProjectID"].ToString(),
                   ProjectName = ReportData["ProjectName"].ToString(),
                   BugID = ReportData["BugID"].ToString(),
                   BugTitle = ReportData["BugTitle"].ToString(),
                   StatusName = ReportData["ProgressStatusName"].ToString()
                });
            }
            ReportData.Close();
            return ReportDataList;
        }

        /// <summary>
        /// 获取第二个报表的HTML
        /// </summary>
        /// <param name="multiSelectProjectChoice"></param>
        /// <returns></returns>
        public static  string GetReport2_HTML(string multiSelectProjectChoice)
        {
            List<Report2_TaskInfo> reportDataList = GetReport2_ReportData(multiSelectProjectChoice);
            if (reportDataList.Count == 0)
                return string.Empty;

            //写报表头部
            StringBuilder sbReportHTML = new StringBuilder(@"<table class='report_table' style='width:100%; text-align:left' >");
            sbReportHTML.Append("<tr><th>项目名称</th><th>任务编号</th><th>任务名称</th><th>任务状态</th></tr>");
            sbReportHTML.Append("<tbody>");

            foreach (Report2_TaskInfo item in reportDataList)
            {
                sbReportHTML.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td>", item.ProjectName, item.BugID, item.BugTitle, item.StatusName);
            }

            sbReportHTML.AppendFormat("</tbody></table>");

            return sbReportHTML.ToString();
        }
        #endregion

        #region 3-第3个报表业务逻辑方法
        protected List<Report3> GetReport3_Project()
        {
            SqlDataReader ReportData = objReportService.GetReport3_Project();
            List<Report3> ReportDataList = new List<Report3>();
            while (ReportData.Read())
            {
                ReportDataList.Add(new Report3()
                {
                    ProjectID = ReportData["ProjectID"].ToString(),
                    ProjectName = ReportData["ProjectName"].ToString()
                });
            }
            ReportData.Close();
            return ReportDataList;
        }


        public string BindChoicesWithNone()
        {
            StringBuilder ChoiceHtml = new StringBuilder();
            List<Report3> ProjectList = new ReportManager().GetReport3_Project();
            if (ProjectList.Count == 0)
            {
                return string.Empty;
            }
            //加入空值
            ProjectList.Insert(0,new Report3()
            {
                ProjectID = null,
                ProjectName = ""

            });

            foreach (Report3 item in ProjectList)
            {
                ChoiceHtml.AppendFormat("<option value=\"{0}\">{1}</option>", item.ProjectID, item.ProjectName);
            }
           
            return ChoiceHtml.ToString();
        }

        protected static List<Report3> GetReport3_ReportData(string multiSelectProjectChoice)
        {
            SqlDataReader ReportData = ReportService.GetReport3_ReportData(multiSelectProjectChoice);
            List<Report3> ReportDataList = new List<Report3>();
           
            while (ReportData.Read())
            {
                ReportDataList.Add(new Report3()
                {
                    ProjectID = ReportData["ProjectID"].ToString(),
                    ProjectName = ReportData["ProjectName"].ToString(),
                    BugID = ReportData["BugID"].ToString(),
                    BugTitle = ReportData["BugTitle"].ToString(),
                    StatusName = ReportData["ProgressStatusName"].ToString()
                });
            }
            ReportData.Close();
            return ReportDataList;
        }

        /// <summary>
        /// 获取第二个报表的HTML
        /// </summary>
        /// <param name="multiSelectProjectChoice"></param>
        /// <returns></returns>
        public static string GetReport3_HTML(string multiSelectProjectChoice)
        {
            List<Report3> reportDataList = GetReport3_ReportData(multiSelectProjectChoice);
            if (reportDataList.Count == 0)
                return string.Empty;

            //写报表头部
            StringBuilder sbReportHTML = new StringBuilder(@"<table class='report_table' style='width:100%; text-align:left' >");
            sbReportHTML.Append("<tr><th>项目名称</th><th>任务编号</th><th>任务名称</th><th>任务状态</th></tr>");
            sbReportHTML.Append("<tbody>");

            foreach (Report3 item in reportDataList)
            {
                sbReportHTML.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td>", item.ProjectName, item.BugID, item.BugTitle, item.StatusName);
            }

            sbReportHTML.AppendFormat("</tbody></table>");

            return sbReportHTML.ToString();
        }

        #endregion

        #region 4-第4个报表业务逻辑方法
        /// <summary>
        /// 获取第4个报表所需要的数据集合
        /// </summary>
        /// <param name="startDate">查询的起始时间</param>
        /// <param name="endDate">查询的结束时间</param>
        /// <returns></returns>
        public static List<Report4> GetReport4_Data(DateTime startDate, DateTime endDate)
        {
            string projectID = "563";
            SqlDataReader reportDataReader = ReportService.GetReport4_Data(projectID, startDate, endDate);
            List<Report4> reportDataList = new List<Report4>();
            while (reportDataReader.Read())
            {
                reportDataList.Add(new Report4()
                {
                    ProjectID= reportDataReader["ProjectID"].ToString(),
                    ProjectName = reportDataReader["ProjectName"].ToString(),
                    BugID = reportDataReader["BugID"].ToString(),
                    BugTitle = reportDataReader["BugTitle"].ToString(),
                    ProgressStatusName = reportDataReader["ProgressStatusName"].ToString()
                });
            }
            reportDataReader.Close();
            return reportDataList;

        }

        public static string GetReport4_HTML(DateTime startDate, DateTime endDate)
        {
            List<Report4> reportDataList =  ReportManager.GetReport4_Data( startDate,  endDate);

            if (reportDataList.Count == 0)
                return string.Empty;

            //写报表头部
            StringBuilder sbReportHTML = new StringBuilder(@"<table class='report_table' style='width:100%; text-align:left' >");
            sbReportHTML.Append("<tr><th>项目名称</th><th>任务编号</th><th>任务名称</th><th>任务状态</th></tr>");
            sbReportHTML.Append("<tbody>");

            foreach (Report4 item in reportDataList)
            {
                sbReportHTML.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td>", item.ProjectName, item.BugID, item.BugTitle, item.ProgressStatusName);
            }

            sbReportHTML.AppendFormat("</tbody></table>");

            return sbReportHTML.ToString();
        }

        #endregion

        #region 5，6-第5,6个报表业务逻辑方法
        /// <summary>
        /// 获取报表5,6所需的下拉列表框数据
        /// </summary>
        /// <returns></returns>
        protected List<Report5> GetReport5_Project()
        {
            SqlDataReader ReportData = objReportService.GetReport5_Project();
            List<Report5> ReportDataList = new List<Report5>();
            while (ReportData.Read())
            {
                ReportDataList.Add(new Report5()
                {
                    ProjectID = ReportData["ProjectID"].ToString(),
                    ProjectName = ReportData["ProjectName"].ToString()
                });
            }
            ReportData.Close();
            return ReportDataList;
        }
        /// <summary>
        /// 获取报表5,6所需的根据筛选条件过滤出来的数据
        /// </summary>
        /// <param name="multiSelectProjectChoice"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static List<Report5> GetReport5_Data(string multiSelectProjectChoice, DateTime startDate, DateTime endDate)
        {
            SqlDataReader reportDataReader = ReportService.GetReport5_Data(multiSelectProjectChoice, startDate, endDate);
            List<Report5> reportDataList = new List<Report5>();
            while (reportDataReader.Read())
            {
                reportDataList.Add(new Report5()
                {
                    ProjectID = reportDataReader["ProjectID"].ToString(),
                    ProjectName = reportDataReader["ProjectName"].ToString(),
                    BugID = reportDataReader["BugID"].ToString(),
                    BugTitle = reportDataReader["BugTitle"].ToString(),
                    ProgressStatusName = reportDataReader["ProgressStatusName"].ToString()
                });
            }
            reportDataReader.Close();
            return reportDataList;
        }

        /// <summary>
        /// 获得报表5,6根据筛选条件以及报表数据生成的HTML数据
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="multiSelectProjectChoice"></param>
        /// <returns></returns>
        public static string GetReport5_HTML(DateTime startDate, DateTime endDate, string multiSelectProjectChoice)
        {

            List<Report5> reportDataList = ReportManager.GetReport5_Data(multiSelectProjectChoice,startDate, endDate);

            if (reportDataList.Count == 0)
                return string.Empty;

            //写报表头部
            StringBuilder sbReportHTML = new StringBuilder(@"<table class='report_table' style='width:100%; text-align:left' >");
            sbReportHTML.Append("<tr><th>项目名称</th><th>任务编号</th><th>任务名称</th><th>任务状态</th></tr>");
            sbReportHTML.Append("<tbody>");

            foreach (Report4 item in reportDataList)
            {
                sbReportHTML.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td>", item.ProjectName, item.BugID, item.BugTitle, item.ProgressStatusName);
            }

            sbReportHTML.AppendFormat("</tbody></table>");

            return sbReportHTML.ToString();

        }

        #endregion

        #region 7-第7个报表业务逻辑方法
        /// <summary>
        /// 获取报表需要的数据，返回列表集合
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        protected static List<Report4> GetReport7_Data(Report7_Params param)
        {
            SqlDataReader reportDataReader = ReportService.GetReport7_Data(param);
            List<Report4> reportDataList = new List<Report4>();
            while (reportDataReader.Read())
            {
                reportDataList.Add(new Report4()
                {
                    ProjectID = reportDataReader["ProjectID"].ToString(),
                    ProjectName = reportDataReader["ProjectName"].ToString(),
                    BugID = reportDataReader["BugID"].ToString(),
                    BugTitle = reportDataReader["BugTitle"].ToString(),
                    ProgressStatusName = reportDataReader["ProgressStatusName"].ToString()
                });
            }
            reportDataReader.Close();
            return reportDataList;
        }

        public static string GetReport7_HTML(Report7_Params param)
        {
            List<Report4> reportDataList = ReportManager.GetReport7_Data(param);
            if (reportDataList.Count == 0)
                return string.Empty;

            //写报表头部
            StringBuilder sbReportHTML = new StringBuilder(@"<table class='report_table' style='width:100%; text-align:left' >");
            sbReportHTML.Append("<tr><th>项目名称</th><th>任务编号</th><th>任务名称</th><th>任务状态</th></tr>");
            sbReportHTML.Append("<tbody>");

            foreach (Report4 item in reportDataList)
            {
                sbReportHTML.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td>", item.ProjectName, item.BugID, item.BugTitle, item.ProgressStatusName);
            }

            sbReportHTML.AppendFormat("</tbody></table>");
            return sbReportHTML.ToString();
        }
        #endregion

        #region 8- 第8个报表业务逻辑方法
        /// <summary>
        /// 获取报表8的列表数据
        /// </summary>
        /// <returns>返回实体数据列表</returns>
        public List<Report8_TaskType> GetReport8()
        {
            SqlDataReader objReaderlist = objReportService.GetReport8();
            List<Report8_TaskType> reportdatalist = new List<Report8_TaskType>();
            while (objReaderlist.Read())
            {
                reportdatalist.Add(new Report8_TaskType()
                {
                    BugTypeID = objReaderlist["CrntBugTypeID"].ToString(),
                    TypeName = objReaderlist["TypeName"].ToString(),
                    BugNo = objReaderlist["BugNo"].ToString()
                });

            }
            objReaderlist.Close();
            return reportdatalist;
        }



        #endregion

        #region 9 - 第9个报表业务逻辑方法
        /// <summary>
        /// 获取报表9需要的数据列表集合
        /// </summary>
        /// <returns></returns>
        public List<Report9> GetReport9_Data()
        {
            SqlDataReader ReportData = objReportService.GetReport9();
            List<Report9> ReportDataList = new List<Report9>();
            while (ReportData.Read())
            {
                ReportDataList.Add(new Report9()
                {
                  CrntBugTypeID = ReportData["CrntBugTypeID"].ToString(),
                  BugTypeName = ReportData["TypeName"].ToString(),
                  BugNo = ReportData["BugNo"].ToString()
                });
            }
            ReportData.Close();
            return ReportDataList;

        }

        #endregion

        #region 10- 第10个报表业务逻辑方法
        public List<Report10> GetReport10_Data()
        {
            SqlDataReader ReportData = objReportService.GetReport10();
            List<Report10> ReportDataList = new List<Report10>();
            while (ReportData.Read())
            {
                ReportDataList.Add(new Report10()
                {
                    DateCreated = Convert.ToDateTime(ReportData["DateCreated"]),
                    BugCounts = ReportData["BugCounts"].ToString()
                });
            }
            ReportData.Close();
            return ReportDataList;
        }

        #endregion

        #region 11- 第11个报表业务逻辑方法
        public List<Report11> GetReport11_Data()
        {
            SqlDataReader ReportData = objReportService.GetReport11();
            List<Report11> ReportDataList = new List<Report11>();
            while (ReportData.Read())
            {
                ReportDataList.Add(new Report11()
                {
                    BugTypeID = ReportData["CrntBugTypeID"].ToString(),
                    TypeName = ReportData["TypeName"].ToString(),
                    BugNo = ReportData["BugNo"].ToString()
                });
            }
            ReportData.Close();
            return ReportDataList;
        }

        #endregion

        #region 12 - 第12个报表业务逻辑方法
        public static List<Report12> GetReport12_Data(string multiSelectFieldChoice)
        {
            //定义接收报表12所需的sqldatareader数据
            SqlDataReader objReader = null;
            try
            {
                 objReader = ReportService.GetReport12(multiSelectFieldChoice);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            List<Report12> reportDataList = new List<Report12>();
            if (objReader != null)
            {
                while (objReader.Read())
                {
                    reportDataList.Add(new Report12()
                    {
                        ProjectName = objReader["ProjectName"].ToString(),
                        ProgressStatusName = objReader["ProgressStatusName"].ToString(),
                        BugNo = objReader["BugNo"].ToString()
                    });
                }
            }
            objReader.Close();
            return reportDataList;
        }

        public static string GetReport12_HTML(string selectedProjectsStr)
        {
            //获取报表12所需的数据
            try
            {
                List<Report12> reportDataList = GetReport12_Data(selectedProjectsStr);
                //拼成所需的HTML
    
    
                if (reportDataList.Count == 0)
                    return String.Empty;
                else
                {
                    string strCharts = "[";

                    foreach (Report12 item in reportDataList)
                    {
                        strCharts += "{ \"name\" : \"" + item.ProgressStatusName + "\", \"data\" : " + item.BugNo + "},";
                    }

                    strCharts = strCharts.Substring(0, strCharts.Length - 1);
                    strCharts += "]";

                    return strCharts;
                }

            }
            catch (Exception ex)
            {

                throw new Exception("调用静态方法public static List<Report12> GetReport12_Data(string multiSelectFieldChoice)获取报表12所需的数据出错"+ex.Message); ;
            }
           
        }
        #endregion

        #region 13-第13个报表业务逻辑方法

        /// <summary>
        /// 获取报表所需列表集合 返回list<Report13>
        /// </summary>
        /// <param name="selectProjectStr">选择的项目</param>
        /// <returns>返回数据列表</returns>
        protected static List<Report13> GetReport13_Data(string selectProjectStr)
        {
            //1. 获取sqldatareader
            SqlDataReader objReader = null;
            try
            {
                 objReader = ReportService.GetReport13(selectProjectStr);
            }
            catch (Exception ex)
            {

                throw new Exception("调用报表13数据访问方法GetReport13出错"+ex.Message); 
            }

            //2. 定义泛型列表集合
            List<Report13> reportDataList = new List<Report13>();

            //3. 遍历sqldatareader，封装数据，插入到集合中
            if (objReader!=null)
            {
                while (objReader.Read())
                {
                    reportDataList.Add(new Report13()
                    {
                        ProjectName = objReader["ProjectName"].ToString(),
                        ProgressStatusName = objReader["ProgressStatusName"].ToString(),
                        BugNo = objReader["BugNo"].ToString(),
                        SecondNo = objReader["SecondNo"].ToString()
                    });
                }
                
            }
            objReader.Close();//关闭连接
            return reportDataList;   //4. 返回数据
        }


        /// <summary>
        ///  获取报表所需的HTML
        /// </summary>
        /// <param name="selectProjectStr">选择的项目</param>
        /// <returns>返回报表的HTML</returns>
        public static string GetReport13_HTML(string selectProjectStr)
        {
            //获取报表数据
        
            List<Report13> reportDataList = GetReport13_Data(selectProjectStr);
            //组合HTML

            if (reportDataList.Count == 0)
                return String.Empty;
            else
            {
                string strCharts = "[";

                foreach (Report13 item in reportDataList)
                {
                    // 判断柱形图是0的列，则不显示
                    if (item.BugNo == "0" && item.SecondNo != "0")
                    {
                        strCharts += "{ \"name\" : \"" + item.ProgressStatusName + "\", \"data2\" : " + item.SecondNo + " },";
                    }
                    else if (item.BugNo == "0" && item.SecondNo == "0")
                    {
                        strCharts += "{ \"name\" : \"" + item.ProgressStatusName + "\" },";
                    }
                    else if (item.BugNo != "0" && item.SecondNo == "0")
                    {
                        strCharts += "{ \"name\" : \"" +item.ProgressStatusName + "\", \"data1\" : " + item.BugNo + " },";
                    }
                    else
                    {
                        strCharts += "{ \"name\" : \"" + item.ProgressStatusName + "\", \"data1\" : " + item.BugNo + ", \"data2\" : " + item.SecondNo + " },";
                    }
                }

                strCharts = strCharts.Substring(0, strCharts.Length - 1);
                strCharts += "]";

                return strCharts;
            }

        }
        #endregion

        #region 14-第14个报表业务逻辑方法

        /// <summary>
        /// 获取报表所需列表集合 返回list<Report14>
        /// </summary>
        /// <param name="selectProjectStr">选择的项目</param>
        /// <returns>返回数据列表</returns>
        protected static List<Report14> GetReport14_Data(string selectProjectStr)
        {
            //1. 获取sqldatareader
            SqlDataReader objReader = null;
            try
            {
                objReader = ReportService.GetReport14(selectProjectStr);
            }
            catch (Exception ex)
            {

                throw new Exception("调用报表14数据访问方法GetReport14出错" + ex.Message);
            }

            //2. 定义泛型列表集合
            List<Report14> reportDataList = new List<Report14>();

            //3. 遍历sqldatareader，封装数据，插入到集合中
            if (objReader != null)
            {
                while (objReader.Read())
                {
                    reportDataList.Add(new Report14()
                    {
                        ProjectName = objReader["ProjectName"].ToString(),
                        ProgressStatusName = objReader["ProgressStatusName"].ToString(),
                        BugNo = objReader["BugNo"].ToString(),
                        SecondNo = objReader["SecondNo"].ToString()
                    });
                }

            }
            objReader.Close();//关闭连接
            return reportDataList;   //4. 返回数据
        }


        /// <summary>
        ///  获取报表所需的HTML
        /// </summary>
        /// <param name="selectProjectStr">选择的项目</param>
        /// <returns>返回报表的HTML</returns>
        public static string GetReport14_HTML(string selectProjectStr)
        {
            //获取报表数据

            List<Report14> reportDataList = GetReport14_Data(selectProjectStr);
            //组合HTML

            if (reportDataList.Count == 0)
                return String.Empty;
            else
            {
                string strCharts = "[";

                foreach (Report14 item in reportDataList)
                {
                    // 判断柱形图是0的列，则不显示
                    if (item.BugNo == "0" && item.SecondNo != "0")
                    {
                        strCharts += "{ \"name\" : \"" + item.ProgressStatusName + "\", \"data2\" : " + item.SecondNo + " },";
                    }
                    else if (item.BugNo == "0" && item.SecondNo == "0")
                    {
                        strCharts += "{ \"name\" : \"" + item.ProgressStatusName + "\" },";
                    }
                    else if (item.BugNo != "0" && item.SecondNo == "0")
                    {
                        strCharts += "{ \"name\" : \"" + item.ProgressStatusName + "\", \"data1\" : " + item.BugNo + " },";
                    }
                    else
                    {
                        strCharts += "{ \"name\" : \"" + item.ProgressStatusName + "\", \"data1\" : " + item.BugNo + ", \"data2\" : " + item.SecondNo + " },";
                    }
                }

                strCharts = strCharts.Substring(0, strCharts.Length - 1);
                strCharts += "]";

                return strCharts;
            }

        }
        #endregion

        #region 15-第15个报表业务逻辑方法
        //获取报表15列表数据
        private static List<Report15> GetReport15_Data(string selectProjectStr)
        {

            //1. 获取sqldatareader
            SqlDataReader objReader = null;
            try
            {
                objReader = ReportService.GetReport15(selectProjectStr);
            }
            catch (Exception ex)
            {

                throw new Exception("调用报表15数据访问方法GetReport15出错" + ex.Message);
            }

            //2. 定义泛型列表集合
            List<Report15> reportDataList = new List<Report15>();

            //3. 遍历sqldatareader，封装数据，插入到集合中
            if (objReader != null)
            {
                while (objReader.Read())
                {
                    reportDataList.Add(new Report15()
                    {
                       BugTypeName = objReader["BugTypeName"].ToString(),
                       BugNo = objReader["BugNo"].ToString()
                    });
                }

            }
            objReader.Close();//关闭连接
            return reportDataList;   //4. 返回数据
        }

        //获取报表15的HTML
        public static string GetReport15_HTML(string selectProjectStr)
        {

            //获取报表数据

            List<Report15> reportDataList = GetReport15_Data(selectProjectStr);
            //组合HTML

            if (reportDataList.Count == 0)
                return String.Empty;
            else
            {
                string strCharts = "[";

                foreach (Report15 item in reportDataList)
                {
                    strCharts += "{ \"name\" : \"" + item.BugTypeName + "\", \"data\" : " + item.BugNo + "},";
                }

                strCharts = strCharts.Substring(0, strCharts.Length - 1);
                strCharts += "]";

                return strCharts;
            }
        }
        #endregion

        #region 16-第16个报表业务逻辑方法
        //1. 获取报表的数据列表结合
        public static List<Report16> GetReport16_Data(string selectProjectStr)
        {
            //1. 获取sqldatareader
            SqlDataReader objReader = null;
            try
            {
                objReader = ReportService.GetReport16(selectProjectStr);
                //2.定义report16泛型列表结合
                List<Report16> reportDataList = new List<Report16>();
                //3. 遍历查询，封装，插入集合
                if (objReader!=null)
                {
                    while (objReader.Read())
                    {
                        reportDataList.Add(new Report16()
                        {
                            BugTypeName = objReader["BugTypeName"].ToString(),
                            BugNo = objReader["BugNo"].ToString(),
                            SecondNo = objReader["SecondNo"].ToString()
                        });

                    }
                }
                return reportDataList;
            }
            catch (Exception ex)
            {

                throw new Exception("执行方法 public static List<Report16> GetReport16_Data出错"+ex.Message);
            }
           

        }

        //2. 获取报表的HTML
        public static string GetReport16_HTML(string selectProjectStr)
        {
            //获取报表数据

            List<Report16> reportDataList = GetReport16_Data(selectProjectStr);
            //组合HTML
            if (reportDataList.Count == 0)
                return String.Empty;
            else
            {
                string strCharts = "[";

                foreach (Report16 item in reportDataList)
                {
                    // 判断柱形图是0的列，则不显示
                    if (item.BugNo == "0" && item.SecondNo != "0")
                    {
                        strCharts += "{ \"name\" : \"" + item.BugTypeName + "\", \"data2\" : " + item.SecondNo + " },";
                    }
                    else if (item.BugNo == "0" && item.SecondNo == "0")
                    {
                        strCharts += "{ \"name\" : \"" + item.BugTypeName + "\" },";
                    }
                    else if (item.BugNo != "0" && item.SecondNo == "0")
                    {
                        strCharts += "{ \"name\" : \"" + item.BugTypeName + "\", \"data1\" : " + item.BugNo + " },";
                    }
                    else
                    {
                        strCharts += "{ \"name\" : \"" + item.BugTypeName + "\", \"data1\" : " + item.BugNo + ", \"data2\" : " + item.SecondNo + " },";
                    }
                }

                strCharts = strCharts.Substring(0, strCharts.Length - 1);
                strCharts += "]";

                return strCharts;
            }
        }
        #endregion

        #region 17-第17个报表业务逻辑方法
        /// <summary>
        /// 获取报表18所需的列表数据
        /// </summary>
        /// <param name="selectProjectStr"></param>
        /// <returns></returns>
        private static List<Report17> GetReport17_Data(string selectProjectStr)
        {
            //获取sqldatareader数据
            SqlDataReader objReader = null;
            try
            {
                objReader = ReportService.GetReport17(selectProjectStr);
                //定义泛型集合列表
                List<Report17> reportDataList = new List<Report17>();

                //遍历循环，封装，插入列表
                if (objReader!=null)
                {
                    while (objReader.Read())
                    {
                        reportDataList.Add(new Report17()
                        {
                            BugTypeName= objReader["BugTypeName"].ToString(),
                            BugNo = objReader["BugNo"].ToString(),
                            SecondNo = objReader["SecondNo"].ToString()
                        });
                    }
                }
                //返回
                objReader.Close();
                return reportDataList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            

        }
        /// <summary>
        /// 获取报表17所需的HTML
        /// </summary>
        /// <param name="selectProjectStr"></param>
        /// <returns></returns>
        public static string GetReport17_HTML(string selectProjectStr)
        {
            //获取报表列表数据
            List<Report17> reportDataList = GetReport17_Data(selectProjectStr);

            //组装


            if (reportDataList.Count == 0)
                return String.Empty;
            else
            {
                string strCharts = "[";

                foreach (Report17 item in reportDataList)
                {
                    // 判断柱形图是0的列，则不显示
                    if (item.BugNo == "0" && item.SecondNo != "0")
                    {
                        strCharts += "{ \"name\" : \"" + item.BugTypeName + "\", \"data2\" : " + item.SecondNo + " },";
                    }
                    else if (item.BugNo == "0" && item.SecondNo == "0")
                    {
                        strCharts += "{ \"name\" : \"" + item.BugTypeName + "\" },";
                    }
                    else if (item.BugNo != "0" && item.SecondNo == "0")
                    {
                        strCharts += "{ \"name\" : \"" + item.BugTypeName + "\", \"data1\" : " + item.BugNo + " },";
                    }
                    else
                    {
                        strCharts += "{ \"name\" : \"" + item.BugTypeName + "\", \"data1\" : " + item.BugNo + ", \"data2\" : " + item.SecondNo + " },";
                    }
                }

                strCharts = strCharts.Substring(0, strCharts.Length - 1);
                strCharts += "]";

                return strCharts;
            }

        }

        #endregion

        #region 18-第18个报表业务逻辑方法
        //获取列表数据
        private static List<Report18> GetReport18_Data(string selectProjetStr)
        {
            SqlDataReader objReader = null;
            try
            {
                objReader = ReportService.GetReport18(selectProjetStr);
                List<Report18> reportDataList = new List<Report18>();
                if (objReader!=null)
                {
                    while (objReader.Read())
                    {
                        reportDataList.Add(new Report18()
                        {
                            DateCreated = Convert.ToDateTime( objReader["DateCreated"]),
                            BugCounts = objReader["BugCounts"].ToString()
                        }
                        );
                    }
                }
                objReader.Close();
                return reportDataList;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //获取HTML
        public static string GetRport18_HTML(string selectProjetStr)
        {
            List<Report18> reportDataList = GetReport18_Data(selectProjetStr);


            if (reportDataList.Count == 0)
                return String.Empty;
            else
            {
                string strCharts = "[";

                foreach (Report18 item in reportDataList)
                {
                    strCharts += "{ \"name\" : \"" + item.DateCreated + "\", \"data\" : " + item.BugCounts + "},";
                }

                strCharts = strCharts.Substring(0, strCharts.Length - 1);
                strCharts += "]";

                return strCharts;
            }
        }
        #endregion

        #region 19 -第19个报表业务逻辑方法
        private static List<Report19> GetReport19_Data(string selectProjectStr)
        {
            //获取sqldatareader
            SqlDataReader objReader = null;
            try
            {
                objReader = ReportService.GetReport19(selectProjectStr);
                List<Report19> reportDataList = new List<Report19>();
                if (objReader!=null)
                {
                    while (objReader.Read())
                    {
                        reportDataList.Add(new Report19()
                        {
                            DateCreated = Convert.ToDateTime(objReader["DateCreated"]),
                            BugCounts= objReader["BugCounts"].ToString(),
                            SecondNo = objReader["SecondNo"].ToString()

                        });
                    }

                }
                objReader.Close();
                return reportDataList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            //定义列表结合

            //遍历，封装，插入

            //返回
        }

        public static string GetReport19_HTML(string selectProjectStr)
        {
            //报表列表数据
            List<Report19> reportDataList = GetReport19_Data(selectProjectStr);


            if (reportDataList.Count == 0)
                return String.Empty;
            else
            {
                string strCharts = "[";

                foreach (Report19 item in reportDataList)
                {
                    strCharts += "{ \"name\" : \"" + item.DateCreated + "\", \"data1\" : " + item.BugCounts + ", \"data2\" : " + item.SecondNo + " },";
                }

                strCharts = strCharts.Substring(0, strCharts.Length - 1);
                strCharts += "]";

                return strCharts;
            }
        }
        #endregion

        #region 20- 第20个报表业务逻辑方法
        //获取报表列表数据
        private static List<Report20> GetReport20_Data(string selectProjectStr)
        {
            //获取sqldatareader
            SqlDataReader objReader = null;
            try
            {
                objReader = ReportService.GetReport20(selectProjectStr);
                //定义列表集合
                List<Report20> reportDataList = new List<Report20>();
                //遍历循环，封装，插入
                if (objReader!= null)
                {
                    while (objReader.Read())
                    {
                        reportDataList.Add(new Report20()
                        {
                            ProjectName = objReader["ProjectName"].ToString(),
                            ProgressStatusName = objReader["ProgressStatusName"].ToString(),
                            BugNo = objReader["BugNo"].ToString(),
                            BugPercent = objReader["BugPercent"].ToString()
                        });
                    }
                }
                objReader.Close();//关闭连接
                return reportDataList; //返回
            }
            catch (Exception ex)
            {

                throw ex;
            }
         

           

           
        }
        //获取报表HTML数据
        public static string GetReport20_HTML(string selectProjectStr)
        {
            List<Report20> reportDataList = GetReport20_Data(selectProjectStr);

            if (reportDataList.Count == 0)
                return String.Empty;
            else
            {
                string strCharts = "[";

                foreach (Report20 item in reportDataList)
                {
                    //strCharts += "{ \"name\" : \"" + dr["ProgressStatusName"].ToString() + "\", \"data\" : " + dr["BugNo"].ToString() + "},";
                    strCharts += "{ \"name\" : \"" + item.ProgressStatusName + "\", \"data1\" : " + item.BugNo + ", \"data2\" : " + item.BugPercent + " },";
                }

                strCharts = strCharts.Substring(0, strCharts.Length - 1);
                strCharts += "]";

                return strCharts;
            }
        }
        #endregion

        #region 21- 第21个报表业务逻辑类
        /// <summary>
        /// 获取报表8的列表数据
        /// </summary>
        /// <returns>返回实体数据列表</returns>
        public List<Report21_TaskType> GetReport21()
        {
            SqlDataReader objReaderlist = objReportService.GetReport21();
            List<Report21_TaskType> reportdatalist = new List<Report21_TaskType>();
            while (objReaderlist.Read())
            {
                reportdatalist.Add(new Report21_TaskType()
                {
                    BugTypeID = objReaderlist["CrntBugTypeID"].ToString(),
                    TypeName = objReaderlist["TypeName"].ToString(),
                    BugNo = objReaderlist["BugNo"].ToString()
                });

            }
            objReaderlist.Close();
            return reportdatalist;
        }
        #endregion

        #region 22-统计烽火工时报表业务逻辑方法
        /// <summary>
        /// 获取烽火总结报表所需要的数据集合
        /// </summary>
        /// <param name="startDate">查询的起始时间</param>
        /// <param name="endDate">查询的结束时间</param>
        /// <returns></returns>
        public static List<ReportFH> GetReport_Data_FH(DateTime startDate, DateTime endDate)
        {
            string projectID = "100";
            SqlDataReader reportDataReader = ReportService.GetReport_Data_FH(projectID, startDate, endDate);
            List<ReportFH> reportDataList = new List<ReportFH>();
            while (reportDataReader.Read())
            {
                reportDataList.Add(new ReportFH()
                {
                    User = reportDataReader["Worker"].ToString(),
                    WorkDays = reportDataReader["WorkDays"].ToString(),
                    WorkHours = reportDataReader["WorkHours"].ToString(),
                    PersonID= reportDataReader["PersonID"].ToString(),
                    TotalPoints = reportDataReader["TotalPoints"].ToString() == "" ? "0" : reportDataReader["TotalPoints"].ToString()
                });
            }
            reportDataReader.Close();
            return reportDataList;

        }

        public static string GetReport_HTML_FH(DateTime startDate, DateTime endDate)
        {
            List<ReportFH> reportDataList = ReportManager.GetReport_Data_FH(startDate, endDate);

            if (reportDataList.Count == 0)
                return string.Empty;

            //写报表头部
            StringBuilder sbReportHTML = new StringBuilder(@"<table class='report_table' style='width:100%; text-align:left' >");
            sbReportHTML.Append("<tr><th>员工</th><th>工作天数</th><th>工作小时</th><th>完成点数</th></tr>");
            sbReportHTML.Append("<tbody>");

            foreach (ReportFH item in reportDataList)
            {
                StringBuilder link = new StringBuilder();
                link.AppendFormat("<a href=\"ReportFHDetail.aspx?UserID={0}\" target =\"view_window\">{1}</a>", item.PersonID,item.User);
                sbReportHTML.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td>", link.ToString(), item.WorkDays, item.WorkHours,item.TotalPoints);
            }

            sbReportHTML.AppendFormat("</tbody></table>");

            return sbReportHTML.ToString();
        }


        public static ReportSummary GetReport_Summary_FH(DateTime startDate, DateTime endDate)
        {
            string projectID = "100";
            SqlDataReader reportDataReader = ReportService.GetReport_Data_FH(projectID, startDate, endDate);
            List<ReportFH> reportDataList = new List<ReportFH>();
            ReportSummary reportSummary = new ReportSummary();
            while (reportDataReader.Read())
            {
                reportDataList.Add(new ReportFH()
                {
                    User = reportDataReader["Worker"].ToString(),
                    WorkDays = reportDataReader["WorkDays"].ToString(),
                    WorkHours = reportDataReader["WorkHours"].ToString(),
                    PersonID = reportDataReader["PersonID"].ToString(),
                    TotalPoints = reportDataReader["TotalPoints"].ToString()=="" ? "0" : reportDataReader["TotalPoints"].ToString()
                });
                //reportSummary.TotalWorkDays = reportSummary.TotalWorkDays + Convert.ToDouble(reportDataReader["WorkDays"]);
                //reportSummary.TotalWorkHours = reportSummary.TotalWorkHours + Convert.ToDouble(reportDataReader["WorkHours"]);
                //reportSummary.TotalPoints = reportSummary.TotalPoints + Convert.ToDouble(reportDataReader["TotalPoints"]);
            }
            reportDataReader.Close();

            reportSummary.TotalWorkDays = reportDataList.Sum(s => Convert.ToDouble(s.WorkDays));
            reportSummary.TotalWorkHours = reportDataList.Sum(s => Convert.ToDouble(s.WorkHours));
            reportSummary.TotalPoints = reportDataList.Sum(s => Convert.ToDouble(s.TotalPoints));
            return reportSummary;
        }


        #endregion

        #region 23-统计烽火工时报表业务逻辑方法

        public static List<ReportFHDetail> GetReportDetail_Data_FH(string userID)
        {
          
            SqlDataReader reportDataReader = ReportService.GetReportDetail_FH(userID);
            List<ReportFHDetail> reportDataList = new List<ReportFHDetail>();
            while (reportDataReader.Read())
            {
                reportDataList.Add(new ReportFHDetail()
                {
                   PersonID=userID,
                   BugID= reportDataReader["BugID"].ToString(),
                   BugTitle = reportDataReader["BugTitle"].ToString(),
                   Status = reportDataReader["status"].ToString(),
                   TimeSpent = reportDataReader["TimeSpent"].ToString(),
                   TimeRemaining = reportDataReader["TimeRemain"].ToString(),
                   Points = reportDataReader["SpecificationPoint"].ToString(),
                   Desc=reportDataReader["ProblemDescription"].ToString()
                });
            }
            reportDataReader.Close();
            return reportDataList;

        }

        public static StringBuilder GetReportDetail_HTML_FH(string userID)
        {
            List<ReportFHDetail> reportDataList = ReportManager.GetReportDetail_Data_FH(userID);

            if (reportDataList.Count == 0)
                return new StringBuilder();

            //写报表头部
            StringBuilder sbReportHTML = new StringBuilder(@"<table class='report_table' style='width:100%; text-align:left' >");
            sbReportHTML.Append("<tr><th>任务编号</th><th>任务标题</th><th>处理状态</th><th>已花时间</th><th>剩余时间</th><th>点数</th></tr>");
            sbReportHTML.Append("<tbody>");

            foreach (ReportFHDetail item in reportDataList)
            {
                sbReportHTML.AppendFormat("<tr><td>{0}</td><td id=\"Title\">{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td>", item.BugID, item.BugTitle, item.Status, item.TimeSpent,item.TimeRemaining,item.Points);
            }

            sbReportHTML.AppendFormat("</tbody></table>");

            return sbReportHTML;
        }

        public static string GetUserName(string userID)
        {
            return ReportService.GetUserName(userID);
        }


        #endregion

        #region 刷新烽火目录
        public static bool FH_Refresh(string folderID)
        {
            try
            {
                return ReportService.FH_Refresh_Tree(folderID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }


        #endregion

        #region 24-统计内部工时报表业务逻辑方法
        /// <summary>
        /// 获取烽火总结报表所需要的数据集合
        /// </summary>
        /// <param name="startDate">查询的起始时间</param>
        /// <param name="endDate">查询的结束时间</param>
        /// <returns></returns>
        public static List<ReportFH> GetReport_Data_Internal(DateTime startDate, DateTime endDate)
        {
            string projectID = "100";
            SqlDataReader reportDataReader = ReportService.GetReport_Data_Internal(projectID, startDate, endDate);
            List<ReportFH> reportDataList = new List<ReportFH>();
            while (reportDataReader.Read())
            {
                reportDataList.Add(new ReportFH()
                {
                    User = reportDataReader["Worker"].ToString(),
                    WorkDays = reportDataReader["WorkDays"].ToString(),
                    WorkHours = reportDataReader["WorkHours"].ToString(),
                    PersonID = reportDataReader["PersonID"].ToString(),
                    TotalPoints = reportDataReader["TotalPoints"].ToString() == "" ? "0" : reportDataReader["TotalPoints"].ToString()
                });
            }
            reportDataReader.Close();
            return reportDataList;

        }

        public static string GetReport_HTML_Internal(DateTime startDate, DateTime endDate)
        {
            List<ReportFH> reportDataList = ReportManager.GetReport_Data_Internal(startDate, endDate);

            if (reportDataList.Count == 0)
                return string.Empty;

            //写报表头部
            StringBuilder sbReportHTML = new StringBuilder(@"<table class='report_table' style='width:100%; text-align:left' >");
            sbReportHTML.Append("<tr><th>员工</th><th>工作天数</th><th>工作小时</th><th>完成点数</th></tr>");
            sbReportHTML.Append("<tbody>");

            foreach (ReportFH item in reportDataList)
            {
                StringBuilder link = new StringBuilder();
                link.AppendFormat("<a href=\"ReportInternalDetail.aspx?UserID={0}&StartDate={1}&EndDate={2}\" target =\"view_window\">{3}</a>", item.PersonID, startDate,endDate, item.User);
                sbReportHTML.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td>", link.ToString(), item.WorkDays, item.WorkHours, item.TotalPoints);
            }

            sbReportHTML.AppendFormat("</tbody></table>");

            return sbReportHTML.ToString();
        }


        public static ReportSummary GetReport_Summary_Internal(DateTime startDate, DateTime endDate)
        {
            string projectID = "100";
            SqlDataReader reportDataReader = ReportService.GetReport_Data_Internal(projectID, startDate, endDate);
            List<ReportFH> reportDataList = new List<ReportFH>();
            ReportSummary reportSummary = new ReportSummary();
            while (reportDataReader.Read())
            {
                reportDataList.Add(new ReportFH()
                {
                    User = reportDataReader["Worker"].ToString(),
                    WorkDays = reportDataReader["WorkDays"].ToString(),
                    WorkHours = reportDataReader["WorkHours"].ToString(),
                    PersonID = reportDataReader["PersonID"].ToString(),
                    TotalPoints = reportDataReader["TotalPoints"].ToString() == "" ? "0" : reportDataReader["TotalPoints"].ToString()
                });
                //reportSummary.TotalWorkDays = reportSummary.TotalWorkDays + Convert.ToDouble(reportDataReader["WorkDays"]);
                //reportSummary.TotalWorkHours = reportSummary.TotalWorkHours + Convert.ToDouble(reportDataReader["WorkHours"]);
                //reportSummary.TotalPoints = reportSummary.TotalPoints + Convert.ToDouble(reportDataReader["TotalPoints"]);
            }
            reportDataReader.Close();

            reportSummary.TotalWorkDays = reportDataList.Sum(s => Convert.ToDouble(s.WorkDays));
            reportSummary.TotalWorkHours = reportDataList.Sum(s => Convert.ToDouble(s.WorkHours));
            reportSummary.TotalPoints = reportDataList.Sum(s => Convert.ToDouble(s.TotalPoints));
            return reportSummary;
        }


        public static List<ReportFHDetail> GetReportDetail_Data_Internal(string userID, DateTime startDate, DateTime endDate)
        {
            SqlDataReader projectsReader = ReportService.GetReportDetail_Internal_Projects(userID, startDate, endDate);
            List<ReportInternalDetail> projects = new List<ReportInternalDetail>();
            while (projectsReader.Read())
            {
                projects.Add(new ReportInternalDetail() {
                    ProjectID= projectsReader["ProjectID"].ToString(),
                    Counts=projectsReader["count"].ToString()
                });
            }

            List<ReportFHDetail> reportDataList = new List<ReportFHDetail>();
            foreach (var item in projects)
            {

                SqlDataReader reportDataReader = ReportService.GetReportDetail_Internal(userID, startDate, endDate,item.ProjectID);

                while (reportDataReader.Read())
                {
                    reportDataList.Add(new ReportFHDetail()
                    {
                        PersonID = userID,
                        ProjectID=item.ProjectID,
                        BugID = reportDataReader["BugID"].ToString(),
                        BugTitle = reportDataReader["BugTitle"].ToString(),
                        Status = reportDataReader["status"].ToString(),
                        TimeSpent = reportDataReader["TimeSpent"].ToString(),
                        TimeRemaining = reportDataReader["TimeRemain"].ToString(),
                        Points = reportDataReader["SpecificationPoint"].ToString(),
                        Desc = reportDataReader["ProblemDescription"].ToString()
                    });
                }
                reportDataReader.Close();
            }



            return reportDataList;

        }

        public static StringBuilder GetReportDetail_HTML_Internal(string userID, DateTime startDate, DateTime endDate)
        {
            List<ReportFHDetail> reportDataList = ReportManager.GetReportDetail_Data_Internal(userID, startDate, endDate);

            if (reportDataList.Count == 0)
                return new StringBuilder();

            //写报表头部
            StringBuilder sbReportHTML = new StringBuilder(@"<table class='report_table' style='width:100%; text-align:left' >");
            sbReportHTML.Append("<tr><th>任务编号</th><th>任务标题</th><th>处理状态</th><th>已花时间</th><th>剩余时间</th><th>点数</th></tr>");
            sbReportHTML.Append("<tbody>");

            foreach (ReportFHDetail item in reportDataList)
            {
                sbReportHTML.AppendFormat("<tr><td>{0}</td><td id=\"Title\">{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td>", item.BugID, item.BugTitle, item.Status, item.TimeSpent, item.TimeRemaining, item.Points);
            }

            sbReportHTML.AppendFormat("</tbody></table>");

            return sbReportHTML;
        }



        #endregion
    }
}
