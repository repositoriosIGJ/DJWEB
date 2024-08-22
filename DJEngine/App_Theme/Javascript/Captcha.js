//var newImage = new Image();

function Recargar() 
{   
    //newImage = new Image();
    //newImage.ImageUrl = "~/imgCaptcha.aspx"
    //document.getElementById("ctl00_MasterPage_ucCaptchaPersona_imgCaptcha").ImageUrl = newImage.ImageUrl;
    document.getElementById("ctl00_MasterPage_ucCaptchaPersona_imgCaptcha").scr = "~/imgCaptcha.aspx?fantasma=" + new Date().getSeconds();
}