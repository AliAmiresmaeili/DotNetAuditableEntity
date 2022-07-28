using DNTPersianUtils.Core;

namespace Common
{
    public static class PersianExtensions
    {
        /// تبدیلگر عدد به حروف	
        public static string ConvertNumberToText(this int value)
        {
            return value.NumberToText(Language.Persian);
        }

        /// تبدیلگر عدد به حروف	
        public static string ConvertNumberToText(this long value)
        {
            return value.NumberToText(Language.Persian);
        }

        //نمایش دوستانه‌ی یک تاریخ و ساعت انگلیسی به شمسی	
        public static string ConvertToFriendlyPersianDateTextify(this DateTime value)
        {
            return value.ToFriendlyPersianDateTextify(); //‫۱۰ روز قبل، سه شنبه ۲۱ دی ۱۳۹۵، ساعت ۱۰:۲۰
        }

        //نمایش فارسی روز دریافتی		
        public static string ConvertToPersianDateTextify(this DateTime value)
        {
            return value.ToPersianDateTextify(); //‫سه شنبه ۲۱ دی ۱۳۹۵
        }

        //تبدیل تاریخ میلادی به شمسی			
        public static string ConvertToLongPersianDateString(this DateTime value)
        {
            return value.ToLongPersianDateString(); //‫‫21 دی 1395
        }

        //تبدیل تاریخ میلادی به شمسی			
        public static string ConvertToShortPersianDateString(this DateTime value)
        {
            return value.ToShortPersianDateString(); //1395/10/21
        }

        //تبدیل تاریخ میلادی به شمسی			
        public static string ConvertToShortPersianDateTimeString(this DateTime value)
        {
            return value.ToShortPersianDateTimeString(); //1395/10/21 10:20
        }

        //تبدیل تاریخ و زمان رشته‌ای شمسی به میلادی با قالب‌های پشتیبانی شده‌ی 1395/12/30		
        public static DateTime? ConvertToGregorianDateTime(this string value)
        {
            return value.ToGregorianDateTime();
        }

        /// تعیین اعتبار تاریخ و زمان رشته‌ای شمسی		
        public static bool CheckIsValidPersianDateTime(this string value)
        {
            return value.IsValidPersianDateTime();//1395/12/30
        }

        /// بررسی اعتبار کد ملی			
        public static bool CheckIsValidIranianNationalCode(this string value)
        {
            return value.IsValidIranianNationalCode();//0010350829
        }

        /// بررسی اعتبار شناسه ملی حقوقی				
        public static bool CheckIsValidIranianNationalLegalCode(this string value)
        {
            return value.IsValidIranianNationalLegalCode();//14005893875
        }

        /// بررسی اعتبار شماره موبایل			
        public static bool CheckIsValidIranianMobileNumber(this string value)
        {
            return value.IsValidIranianMobileNumber();//09901464762
        }

        /// بررسی اعتبار شماره تلفن			
        public static bool CheckIsValidIranianPhoneNumber(this string value)
        {
            return value.IsValidIranianPhoneNumber();//37236445
        }

        /// بررسی اعتبار کد پستی				
        public static bool CheckIsValidIranianPostalCode(this string value)
        {
            return value.IsValidIranianPostalCode();//1619735744
        }

        /// بررسی اعتبار کد بانک شبا				
        public static bool CheckIsValidIranShebaNumber(this string value)
        {
            return value.IsValidIranShebaNumber(); //IR820540102680020817909002
        }

        /// بررسی اعتبار کد بانک شتاب				
        public static bool CheckIsValidIranShetabNumber(this string value)
        {
            return value.IsValidIranShetabNumber(); //6221061106498670
        }


    }
}
