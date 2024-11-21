using ShopApi.Utilities;

namespace ShopApi.Models;

public class Order
{
   public long Id { get; set; } 
   public long CustomerNumber {get;set;}
   public long ProductNumber { get; set; }
   public int Quantity {get;set;}
   public DateTime OrderDate {get;set;}
   public DateTime PaymentDate {get;set;}
   public PaymentStatus PaymentStatus {get;set;}
   public ReturnStatus ReturnStatus {get;set;}
   public long PaymentId {get;set;}
   public decimal Total {get;set;}
   
   public String GroupOrderId { get; set; } 
}