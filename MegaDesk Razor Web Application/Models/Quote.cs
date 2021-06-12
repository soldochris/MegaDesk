using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MegaDesk_Razor_Web_Application.Models
{

    public class Quote
    {
        private double totalPrice;
        public int ID { get; set; }
        public string CustomerName { get; set; }

        [Required]
        [Range(24, 96)]
        public int DeskWidth { get; set; }

        [Required]
        [Range(12, 48)]
        public int DeskHeight { get; set; }

        public int MaterialOptions { get; set; }

        public int NumberDrawers { get; set; }

        [Required]
        [Range(0, 7)]
        public int ProductionTime { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }


        [Display(Name = "Total Price")]
        public double TotalPrice
        {
            get
            {
                totalPrice = totalPrice == 0 ? getTotalPrice() : totalPrice;
                return totalPrice;
            }
            set => totalPrice = value;
        }

        [NotMapped]
        public double SurfaceArea => DeskWidth * DeskHeight;

        public double getTotalPrice()
        {
            double basePrice = 200;
            double rushPrice = getRushPrice();
            double surfacePrice = getSurfacePrice() + MaterialOptions;
            double drawersPrice = getDrawersPrice();

            return basePrice + rushPrice + surfacePrice + drawersPrice;
        }

        public double getSurfacePrice()
        {
            return SurfaceArea > 1000 ? SurfaceArea - 1000 : 0;
        }

        public double getDrawersPrice()
        {
            return NumberDrawers * 50;
        }

        public double getRushPrice()
        {
            switch (ProductionTime)
            {
                case 0:
                    return 0;
                case 3 when SurfaceArea < 1000:
                    return 60;
                case 3 when SurfaceArea >= 1000 && SurfaceArea <= 2000:
                    return 70;
                case 5 when SurfaceArea < 1000:
                    return 40;
                case 5 when SurfaceArea >= 1000 && SurfaceArea <= 2000:
                    return 50;
                default:
                    {
                        switch (SurfaceArea)
                        {
                            case < 1000:
                                return 30;
                            case >= 1000 and <= 2000:
                                return 35;
                            default:
                                return 40;
                        }
                    }
            }
        }

    }
}
