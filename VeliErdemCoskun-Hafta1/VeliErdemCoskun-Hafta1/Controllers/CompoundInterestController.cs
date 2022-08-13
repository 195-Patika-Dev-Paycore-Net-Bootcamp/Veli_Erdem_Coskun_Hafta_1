using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;


namespace VeliErdemCoskun_Hafta1.Controllers
{
    public class Interest
    {
        public double TotalBalance { get; set; }    //Toplam Para
        public double InterestAmount { get; set; }  //Faiz Miktarı
      
    }

    [Route("api/[controller]")]
    [ApiController]
    public class CompoundInterestController : ControllerBase
    {
        
        //Get Methodu İle Hesaplama
        [HttpGet("GetCalculation")]

        public ActionResult GetCalculation([FromQuery]double FirstAmount, double InterestRate, int Maturity)    //Request Body
        {
            if (FirstAmount < 0 || InterestRate < 0 || Maturity < 0)    //Girilen Değerlerin Negatif Sayı Olması Durumunda Hata Mesajı Döndürüldü
            {
                return BadRequest("Please enter a positive number!");
            }
            else
            {
                Interest result = new();    //Interest Classından result Adında Yeni Bir Object Üretme
                result.TotalBalance = FirstAmount * Math.Pow((1 + InterestRate), Maturity); // Vade Sonundaki Toplam Tutar Hesabı
                result.InterestAmount = result.TotalBalance - FirstAmount;  //Faiz Tutarı Hesabı
                return Ok(result);  //Toplam Tutar ve Faiz Tutarı Döndürüldü
            }
        }



    }
}
