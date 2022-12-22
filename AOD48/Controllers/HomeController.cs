using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AOD48.Models;
using AOD48.Services;
using Microsoft.Rest;
using System.Configuration;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Ajax.Utilities;


namespace AOD48.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public async Task<ActionResult> EmbedReport()
        {
            try
            {
                var embedResult = await EmbedService.GetEmbedParams(ConfigValidatorService.WorkspaceId, ConfigValidatorService.ReportId);
                return View(embedResult);
            }
            catch (HttpOperationException exc)
            {
                //m_errorMessage = string.Format("Status: {0} ({1})\r\nResponse: {2}\r\nRequestId: {3}", exc.Response.StatusCode, (int)exc.Response.StatusCode, exc.Response.Content, exc.Response.Headers["RequestId"].FirstOrDefault());
                return View(exc);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }
    }
}