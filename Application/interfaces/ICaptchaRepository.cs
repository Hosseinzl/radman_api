using Application.Model;

namespace Application.interfaces
{
    public interface ICaptchaRepository
    {
        Captcha GetCapthcaImage();
    }
}
