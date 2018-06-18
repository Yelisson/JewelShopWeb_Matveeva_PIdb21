﻿using JewelShopService.BindingModels;
using JewelShopService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unity;

namespace JewelShopWebView
{
    public partial class FormSavePrice : System.Web.UI.Page
    {
        readonly IReportService reportService = UnityConfig.Container.Resolve<IReportService>();

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("Content-Disposition", "filename=WebAdornmentPrice.docx");
            Response.ContentType = "application/vnd.ms-word";
            try
            {
                reportService.SaveAdornmentPrice(new ReportBindingModel
                {
                    fileName = "D:\\WebAdornmentPrice.docx"
                });
                Response.WriteFile("D:\\WebAdornmentPrice.docx");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ScriptAllert", "<script>alert('" + ex.Message + "');</script>");
            }
            Response.End();

        }
    }
}