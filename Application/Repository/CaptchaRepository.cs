using Application.interfaces;
using Application.Model;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using SixLaborsCaptcha.Core;
using System.Text;

namespace Application.Repository
{
    public class CaptchaRepository : ICaptchaRepository
    {
        private readonly ISixLaborsCaptchaModule _sixLaborsCaptchaModule;

        public CaptchaRepository(ISixLaborsCaptchaModule sixLaborsCaptchaModule)
        {
            _sixLaborsCaptchaModule = sixLaborsCaptchaModule;
        }

        public Captcha GetCapthcaImage()
        {
            string key = Extensions.GetUniqueKey(6);
            var imgText = _sixLaborsCaptchaModule.Generate(key);
            string imageCaptcha = "";
            foreach(byte currentByte in imgText)
            {
                imageCaptcha += currentByte.ToString();
            }
            return new Captcha
            {
                captchaImage = imgText,
                captchaKey = key
            };
            
        }
    }
}
