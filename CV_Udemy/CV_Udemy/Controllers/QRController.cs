using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;

namespace CV_Udemy.Controllers
{
    public class QRController : Controller
    {
        // GET: QR
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string code)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator CreateCode = new QRCodeGenerator();
                QRCodeGenerator.QRCode qrCode = CreateCode.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                using (Bitmap image = qrCode.GetGraphic(10))
                {
                    image.Save(ms, ImageFormat.Png);
                    ViewBag.CoderQR = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }
            }

            return View();
        }
    }
}