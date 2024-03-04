using Microsoft.AspNetCore.Mvc;

namespace AIWebSite.Controllers
{
    public class LoanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult predict(MLModel.ModelInput modelInput)
        {
            var sortedScoresWithLabel = MLModel.PredictAllLabels(modelInput);
            return Json(sortedScoresWithLabel);
        }

        [HttpGet]
        public IActionResult WebApiPredict()
        {
            return View();
        }
    }
}
