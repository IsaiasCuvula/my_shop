using ShopApi.Utilities;

namespace ShopApi.Models;

public class Sales
{
   public long Id { get; set; } 
   public int CustomerNumber {get;set;}
   public int ProductNumber {get;set;}
   public DateTime OrderDate {get;set;}
   public DateTime PaymentDate {get;set;}
   public PaymentStatus PaymentStatus {get;set;}
   public ReturnStatus ReturnStatus {get;set;}
}